using System;
using System.Web;

namespace app.web.infrastructure
{
    public class ASPHandler : IHttpHandler
    {
        IProcessRequests front_controller;
        private ICreateRequests request_factory;

        public ASPHandler(IProcessRequests front_controller, ICreateRequests request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext httpContext)
        {
            object new_request = request_factory.create_request_from(httpContext);
            front_controller.process(new_request);
        }

        public bool IsReusable
        {
            get { throw new System.NotImplementedException(); }
        }
    }

}