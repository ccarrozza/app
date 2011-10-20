using System.Collections.Generic;
using System.Linq;
using app.models;

namespace app.tasks.stubs
{
    public class StubProductRepository:IFindProducts
    {
        public IEnumerable<ProductItem> get_the_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new ProductItem{name = x.ToString("Product 0")});
        }

        public IEnumerable<ProductItem> get_all_the_products(ProductItem parent_department)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductItem> get_all_the_departments_in(DepartmentItem parent_department)
        {
            return Enumerable.Range(1, 100).Select(x => new ProductItem { name = x.ToString("Product item 0") });
        }
    }
}