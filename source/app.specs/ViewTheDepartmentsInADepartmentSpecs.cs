using System.Collections.Generic;
using Machine.Specifications;
using app.models;
using app.tasks;
using app.web.application.catalogbrowsing;
using app.web.infrastructure;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ViewTheDepartmentsInADepartment))]
    public class ViewTheDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<IEncapsulateUserFunctionality,
                                            ViewTheDepartmentsInADepartment>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestDetails>();
                department_repository = depends.on<IFindDepartments>();
                the_departments_in_the_department = new List<DepartmentItem> {new DepartmentItem()};
                report_engine = depends.on<IDisplayInformation>();
                parent_department = new DepartmentItem();

                request.setup(x => x.map<DepartmentItem>()).Return(parent_department);

                department_repository.setup( x => x.get_all_the_departments_in(parent_department)).Return(the_departments_in_the_department);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_report_engine_to_display_the_departments_within_a_department = () =>
                report_engine.received(x => x.display(the_departments_in_the_department));

            static IDisplayInformation report_engine;
            static IContainRequestDetails request;
            static IFindDepartments department_repository;
            static DepartmentItem parent_department;
            static IEnumerable<DepartmentItem> the_departments_in_the_department;
        }
    }
}