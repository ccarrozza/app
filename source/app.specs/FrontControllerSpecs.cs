 using Machine.Specifications;
 using app.web.infrastructure;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(FrontController))]  
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<IProcessRequests,
                                            FrontController>
        {
        
        }

   
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                command_registry = depends.on<IFindCommandsThatCanProcessRequests>();

                request = fake.an<IContainRequestDetails>();
                command_that_can_process_specific_type_of_request = fake.an<IProcessOneSpecificTypeOfRequest>();

                command_registry.setup(x => x.get_the_command_that_can_process(request)).Return(command_that_can_process_specific_type_of_request);
            };

            Because b = () =>
                sut.process(request);

            It should_delegate_the_processing_to_the_command_that_can_process_the_request = () =>
                command_that_can_process_specific_type_of_request.received(x => x.process(request));

            static IProcessOneSpecificTypeOfRequest command_that_can_process_specific_type_of_request;
            static IContainRequestDetails request;
            static IFindCommandsThatCanProcessRequests command_registry;
        }
    }
}
