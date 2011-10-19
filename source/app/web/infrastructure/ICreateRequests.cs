using System.Web;

namespace app.web.infrastructure
{
    public interface ICreateRequests
    {
        IContainRequestDetails create_request_from(HttpContext original_http_context);
    }
}