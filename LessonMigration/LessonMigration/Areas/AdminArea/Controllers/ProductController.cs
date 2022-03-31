using LessonMigration.Data;
using LessonMigration.Models;
using LessonMigration.Utilities.Pagination;
using LessonMigration.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMigration.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {

        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1, int take = 10)
        {
            var products = await _context.Products
                .Include(m => m.Category)
                .Include(m => m.Images)
                .Skip((page- 1)*take)
                .Take(take)
                .AsNoTracking()
                .OrderByDescending(m => m.Id)
                .ToListAsync();

            var productsVM = GetMapDatas(products);

            int count = await GetPageCount(take);

            Paginate<ProductListVM> result = new Paginate<ProductListVM>(productsVM, page, count);

            return View(result);
        }

        private async Task<int> GetPageCount(int take)
        {
            var count = await _context.Products.CountAsync();

            return (int)Math.Ceiling((decimal)count / take); //yuvarlaq edir;decimala kast edirik!!!
        }


        //private async Task<int> GetPageCount(int take)
        //{
        //    var count = await _context.Products.CountAsync();

        //    return (int)Math.Ceiling((decimal)count / take);
        //}

        private List<ProductListVM> GetMapDatas(List<Product> products)
        {
            List<ProductListVM> productList = new List<ProductListVM>();

            foreach (var product in products)
            {
                ProductListVM newProduct = new ProductListVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.Images.Where(m=>m.IsMain).FirstOrDefault()?.Image,
                    CategoryName = product.Category.Name,
                    Count = product.Count,
                    Price = product.Price
                };

                productList.Add(newProduct);
            }

            return productList;
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _context.Categories.Where(m => !m.IsDeleted).ToListAsync();
            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();
        }
    }
}
