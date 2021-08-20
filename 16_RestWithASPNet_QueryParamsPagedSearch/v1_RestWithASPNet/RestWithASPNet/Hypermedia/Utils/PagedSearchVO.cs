using RestWithASPNet.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Hypermedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportsHyperMedia
    {

        public int CurrentPage { get; set; }

        public int PagedSize { get; set; }

        public int TotalResult { get; set; }

        public string SortFields { get; set; }

        public string SortDirections { get; set; }

        public Dictionary<string,Object> Filters { get; set; }

        public List<T> List { get; set; }

        public PagedSearchVO()
        {
        }

        public PagedSearchVO(int currentPage, int pagedSize, string sortFields, string sortDirections)
        {
            CurrentPage = currentPage;
            PagedSize = pagedSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public PagedSearchVO(int currentPage, int pagedSize, string sortFields, string sortDirections, Dictionary<string, object> filters)
        {
            CurrentPage = currentPage;
            PagedSize = pagedSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
            Filters = filters;
        }

        public PagedSearchVO(int currentPage, string sortFields, string sortDirections) : this(currentPage, 10,sortFields, sortDirections)
        {}

        public int GetCurrentPage()
        {

            return CurrentPage == 0 ? 2 : CurrentPage;

        }

        public int GetPagedSize()
        {

            return PagedSize == 0 ? 10 : PagedSize;

        }

    }
}
