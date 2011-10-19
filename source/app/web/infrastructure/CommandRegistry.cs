using System.Collections.Generic;

namespace app.web.infrastructure
{
    public class CommandRegistry : IFindCommandsThatCanProcessRequests
    {
        IEnumerable<IProcessOneSpecificTypeOfRequest> all_the_commands;

        public CommandRegistry(IEnumerable<IProcessOneSpecificTypeOfRequest> all_the_commands)
        {
            this.all_the_commands = all_the_commands;
        }

        public IProcessOneSpecificTypeOfRequest get_the_command_that_can_process(IContainRequestDetails request)
        {
            throw new System.NotImplementedException();
        }
    }
}