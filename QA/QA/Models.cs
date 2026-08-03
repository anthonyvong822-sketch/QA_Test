using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA
{
    public class ProductListResponse
    {
        public int ResponseCode { get; set; }
        public ProductDetails[] Products { get; set; }
    }

    public class ProductDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Brand { get; set; }
        public CategoryDetails Category { get; set; }
    }

    public class CategoryDetails
    {
        public string Usertype { get; set; }
        public string Category { get; set; }
    }
}
