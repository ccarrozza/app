 using System.Collections.Generic;
 using Machine.Specifications;
 using app.models;
 using app.tasks;
 using app.web.application.catalogbrowsing;
 using app.web.infrastructure;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ViewTheMainDepartments))]  
    public class ViewTheMainDepartmentsSpecs
    {
        public abstract class concern : Observes<IEncapsulateUserFunctionality,
                                            ViewTheMainDepartments>
        {
        
        }

   
        public class when_run : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestDetails>();
                department_repository = depends.on<IFindDepartments>();
                report_engine = depends.on<IDisplayInformation>();
                the_main_departments = new List<DepartmentItem> {new DepartmentItem()};

                department_repository.setup(x => x.get_the_main_departments()).Return(the_main_departments);
            };

            Because b = () =>
                sut.process(request);


            It should_tell_the_report_engine_to_display_the_departments = () =>
                report_engine.received(x => x.display(the_main_departments));


            static IFindDepartments department_repository;
            static IContainRequestDetails request;
            static IDisplayInformation report_engine;
            static IEnumerable<DepartmentItem> the_main_departments;
        }
    }
}
