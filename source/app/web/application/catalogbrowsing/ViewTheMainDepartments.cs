using app.tasks;
using app.web.infrastructure;

namespace app.web.application.catalogbrowsing
{
    public class ViewTheMainDepartments : IEncapsulateUserFunctionality
    {
        IFindDepartments department_finder;

        public ViewTheMainDepartments(IFindDepartments department_finder){
            this.department_finder = department_finder;
        }

        public void process(IContainRequestDetails request)
        {
           department_finder.get_the_main_departments(); 
        }
    }
}
