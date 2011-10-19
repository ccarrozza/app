namespace app.web.infrastructure
{
    public interface IProcessRequests
    {
        void process(IContainRequestDetails a_new_request);
    }
}