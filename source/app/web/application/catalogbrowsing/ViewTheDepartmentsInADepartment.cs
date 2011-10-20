using app.models;
using app.tasks;
using app.tasks.stubs;
using app.web.infrastructure;
using app.web.infrastructure.stubs;

namespace app.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsInADepartment:IEncapsulateUserFunctionality
    {
        IFindDepartments department_repository;
        IDisplayInformation report_engine;

        public ViewTheDepartmentsInADepartment():this(Stub.with<StubDepartmentRepository>(),
            Stub.with<StubReportEngine>())
        {
        }

        public ViewTheDepartmentsInADepartment(IFindDepartments department_repository, IDisplayInformation report_engine)
        {
            this.department_repository = department_repository;
            this.report_engine = report_engine;
        }

        public void process(IContainRequestDetails request)
        {
            report_engine.display(department_repository.get_all_the_departments_in(request.map<DepartmentItem>()));
        }
    }
}