namespace app.web.infrastructure
{
    public interface IProcessOneSpecificTypeOfRequest : IEncapsulateUserFunctionality
    {
        bool can_handle(IContainRequestDetails request);
    }
}