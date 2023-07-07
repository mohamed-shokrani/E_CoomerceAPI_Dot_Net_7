﻿namespace API.Helper
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, int count , IReadOnlyList<T> date)
        {
            PageIndex = pageIndex;
            Count = count;
            PageSize = pageSize;
            Date = date;
        }

        public int PageIndex { get; set; }   

       public int Count { get; set; }   
        public int PageSize { get; set; }
       public IReadOnlyList<T> Date { get; set; } 
     
    }
}
