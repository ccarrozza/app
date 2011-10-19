using Machine.Specifications;
using app.web.infrastructure;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(RequestCommand))]
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<IProcessOneSpecificTypeOfRequest,
                                            RequestCommand>
        {
        }

        public class when_determining_if_it_can_process_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestDetails>();
                depends.on<RequestCriteria>(x => true);
            };

            Because b = () =>
                result = sut.can_handle(request);

            It should_make_the_determination_by_leveraging_its_request_specification = () =>
                result.ShouldBeTrue();

            static bool result;
            static IContainRequestDetails request;
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestDetails>();
                application_behaviour = depends.on<IEncapsulateUserFunctionality>();
            };

            Because b = () =>
                sut.process(request);

            It should_delegate_the_processing_to_the_application_specific_functionality = () =>
                application_behaviour.received(x => x.process(request));

            static IEncapsulateUserFunctionality application_behaviour;
            static IContainRequestDetails request;
        }
    }
}