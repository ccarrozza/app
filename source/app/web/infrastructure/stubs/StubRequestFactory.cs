using System.Web;

namespace app.web.infrastructure.stubs
{
    public class StubRequestFactory : ICreateRequests
    {
        public IContainRequestDetails create_request_from(HttpContext original_http_context)
        {
            return new StubRequest();
        }

        class StubRequest : IContainRequestDetails
        {
        }
    }
}