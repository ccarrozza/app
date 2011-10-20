using System.Collections.Generic;
using app.models;

namespace app.tasks
{
    public interface IFindDepartments
    {
        IEnumerable<DepartmentItem> get_the_main_departments();
        IEnumerable<DepartmentItem> get_all_the_departments_in(DepartmentItem parent_department);
    }
}