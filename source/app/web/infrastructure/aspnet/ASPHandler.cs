using System.Web;
using app.web.infrastructure.stubs;

namespace app.web.infrastructure.aspnet
{
    public class ASPHandler : IHttpHandler
    {
        IProcessRequests front_controller;
        ICreateRequests request_factory;

        public ASPHandler():this(new FrontController(),Stub.with<StubRequestFactory>())
        {
        }

        public ASPHandler(IProcessRequests front_controller, ICreateRequests request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext http_context)
        {
            front_controller.process(request_factory.create_request_from(http_context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}