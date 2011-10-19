namespace app.web.infrastructure
{
    public class FrontController : IProcessRequests
    {
        IFindCommandsThatCanProcessRequests command_registry;

        public FrontController(IFindCommandsThatCanProcessRequests command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(IContainRequestDetails request)
        {
            command_registry.get_the_command_that_can_process(request).process(request);
        }
    }
}