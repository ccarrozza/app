using System.Web;

namespace app.web.infrastructure
{
    public interface ICreateRequests
    {
        object create_request_from(HttpContext original_http_context);
    }
}