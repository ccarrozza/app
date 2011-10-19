using System.Web;

namespace app.web.infrastructure.stubs
{
    public class StubCommand : IProcessOneSpecificTypeOfRequest
    {
        bool handle;

        public StubCommand(bool can_handle)
        {
            this.handle = can_handle;
        }

        public StubCommand():this(false)
        {
        }

        public void process(IContainRequestDetails request)
        {
            HttpContext.Current.Response.Write("Front Controller Works");
        }

        public bool can_handle(IContainRequestDetails request)
        {
            return handle;
        }
    }
}