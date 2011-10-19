namespace app.web.infrastructure
{
    public interface IProcessOneSpecificTypeOfRequest
    {
        void process(IContainRequestDetails request);
        bool can_handle(IContainRequestDetails request);
    }
}