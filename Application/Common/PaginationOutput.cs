namespace Application.Common
{
    public class PaginationOutput<T> where T : class
    {
        public List<T> Data { get; set; } = new List<T>();
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
    }
}
