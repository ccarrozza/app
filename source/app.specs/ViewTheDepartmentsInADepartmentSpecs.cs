 using Machine.Specifications;
 using app.models;
 using app.tasks;
 using app.web.infrastructure;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

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
            private Establish c = () =>
                                      {
                                          request = fake.an<IContainRequestDetails>();
                                          department_repository = depends.on<IFindDepartments>();
                                          report_engine = depends.on<IDisplayInformation>();
                                          the_department = new DepartmentItem();

                                          department_repository.setup(
                                              x => x.get_a_single_department(the_department.name)).Return(the_department);
                                      };

            Because b = () =>
                sut.process(request);

            It should_tell_the_report_engine_to_display_the_departments_within_a_department = () =>
                report_engine.received(x => x.display(details_of_a_single_department));

            static IDisplayInformation report_engine;
            static DepartmentItem details_of_a_single_department;
            static IContainRequestDetails request;
            static IFindDepartments department_repository;
            private static DepartmentItem the_department;
        }
    }
}
