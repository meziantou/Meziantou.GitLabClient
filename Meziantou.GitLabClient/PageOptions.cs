namespace Meziantou.GitLab
{
    public class PageOptions
    {
        public PageOptions()
        {
        }

        public PageOptions(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public OrderBy OrderBy { get; set; }
    }
}
