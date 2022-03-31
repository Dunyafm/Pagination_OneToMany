﻿using System.Collections.Generic;

namespace LessonMigration.Utilities.Pagination
{
    public class Paginate<T> //Butun yerlerde classlar ucun istifade etmek ucun generic yazmaliyiq!!!
    {

        public Paginate(List<T> datas, int currentPage, int totalPage)
        {
            Datas = datas;
            CurrentPage = currentPage;
            TotalPage = totalPage;

        }

        public List<T> Datas { get; set; }
        public int CurrentPage { get; set; } //hal hazirda hansi seyfe oldugunu gosterir!!!!
        public int TotalPage { get; set; }







}   }
    //{
    //    public Paginate(List<T> datas, int currentPage, int totalPage) // methoda hal hazirda hansi seyfededi onu gondermeliyik,umumi seyfeler nece ededi onu yazmaliyiq!!
    //    {
    //        Datas = datas;
    //        CurrentPage = currentPage;
    //        TotalPage = totalPage;
    //    }
    //    public List<T> Datas { get; set; }
    //    public int CurrentPage { get; set; }
    //    public int TotalPage { get; set; }

    //    public bool HasPrevious 
    //    {
    //        get
    //        {
    //            return CurrentPage > 1;
    //        }
    //    }


    //    public bool HasNext
    //    {
    //        get
    //        {
    //            return CurrentPage < TotalPage;
    //        }
    //    }

    //}
   