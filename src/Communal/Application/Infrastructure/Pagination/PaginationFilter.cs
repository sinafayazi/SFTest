namespace Communal.Application.Infrastructure.Pagination
{
    public class PaginationFilter
    {
        private const int MinPageNumber = 1;
        private const int MaxPageSize = 200;

        protected PaginationFilter(int page, int pageSize)
        {
            Page = page > 0 ? page : MinPageNumber;
            PageSize = pageSize is > 0 and <= MaxPageSize ? pageSize : MaxPageSize;
        }

        public int Page { get; }
        public int PageSize { get; }
    }
}