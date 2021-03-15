using System.Collections.Generic;

namespace TesteDesenvolvedor.Services.Utils
{
    public class PageList<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }       
        public string SortDirections { get; set; }
        public List<T> List { get; set; }

        public PageList(){}

        public PageList(int currentPage, int pageSize, string sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortDirections = sortDirections;
        }

        public PageList(int currentPage, string sortDirections) : this(currentPage, 10, sortDirections){}

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }

    }
}