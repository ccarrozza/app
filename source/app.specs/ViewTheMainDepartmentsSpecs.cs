 using Machine.Specifications;
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
            };

            Because b = () =>
                sut.process(request);

            It should_get_the_main_departments = () =>
                department_repository.received(x => x.get_the_main_departments());

            static IFindDepartments department_repository;
            static IContainRequestDetails request;
        }
    }
}
