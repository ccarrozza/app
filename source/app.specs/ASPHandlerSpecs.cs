using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.infrastructure;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ASPHandler))]
    public class ASPHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            ASPHandler>
        {
        }

        public class when_processing_an_incoming_http_context : concern
        {
            Establish c = () =>
            {
                front_controller = depends.on<IProcessRequests>();
                request_factory = depends.on<ICreateRequests>();

                original_http_context = ObjectFactory.web.create_http_context();

                a_new_request = fake.an<IContainRequestDetails>();

                request_factory.setup(x => x.create_request_from(original_http_context)).Return(a_new_request);
            };

            Because b = () =>
                sut.ProcessRequest(original_http_context);

            It should_delegate_the_processing_of_a_new_request_to_the_front_controller = () =>
                front_controller.received(x => x.process(a_new_request));

            static IProcessRequests front_controller;
            static IContainRequestDetails a_new_request;
            static HttpContext original_http_context;
            static ICreateRequests request_factory;
        }
    }
}