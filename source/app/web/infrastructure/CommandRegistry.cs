using System.Collections.Generic;
using System.Linq;

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
            return all_the_commands.First(x => x.can_handle(request));
        }
    }
}