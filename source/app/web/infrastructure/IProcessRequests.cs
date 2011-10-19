namespace app.web.infrastructure
{
    public interface IProcessRequests
    {
        void process(IContainRequestDetails request);
    }
}