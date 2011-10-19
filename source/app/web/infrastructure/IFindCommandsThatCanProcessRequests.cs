namespace app.web.infrastructure
{
    public interface IFindCommandsThatCanProcessRequests
    {
        IProcessOneSpecificTypeOfRequest get_the_command_that_can_process(IContainRequestDetails request);
    }
}