namespace app.web.infrastructure
{
    public class RequestCommand : IProcessOneSpecificTypeOfRequest
    {
        RequestCriteria criteria;
        IEncapsulateUserFunctionality application_functionality;

        public RequestCommand(RequestCriteria criteria, IEncapsulateUserFunctionality application_functionality)
        {
            this.criteria = criteria;
            this.application_functionality = application_functionality;
        }

        public void process(IContainRequestDetails request)
        {
            application_functionality.process(request);
        }

        public bool can_handle(IContainRequestDetails request)
        {
            return criteria(request);
        }
    }
}