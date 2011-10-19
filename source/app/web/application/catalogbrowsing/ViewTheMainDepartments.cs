using app.tasks;
using app.web.infrastructure;

namespace app.web.application.catalogbrowsing
{
    public class ViewTheMainDepartments : IEncapsulateUserFunctionality
    {
        IFindDepartments department_repository;

        public ViewTheMainDepartments(IFindDepartments department_repository)
        {
            this.department_repository = department_repository;
        }

        public void process(IContainRequestDetails request)
        {
            department_repository.get_the_main_departments();
        }
    }
}