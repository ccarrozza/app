using System.Collections.Generic;
using app.models;

namespace app.tasks
{
    public interface IFindProducts
    {
        IEnumerable<ProductItem> get_the_main_departments();
        IEnumerable<ProductItem> get_all_the_products(ProductItem parent_department);
    }
}
