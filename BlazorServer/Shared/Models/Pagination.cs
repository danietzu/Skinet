using System.Collections.Generic;

namespace BlazorServer.Shared.Models
{
    public class Pagination
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<Product> Data { get; set; }
    }
}