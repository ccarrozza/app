using System.Web;
using app.models;

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
            public InputModel map<InputModel>()
            {
                object department = new DepartmentItem();
                return (InputModel) department;
            }
        }
    }
}