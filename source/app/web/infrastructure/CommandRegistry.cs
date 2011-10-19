using System.Collections.Generic;
using System.Linq;

namespace app.web.infrastructure
{
    public class CommandRegistry : IFindCommandsThatCanProcessRequests
    {
        IEnumerable<IProcessOneSpecificTypeOfRequest> all_the_commands;
        IProcessOneSpecificTypeOfRequest command_to_use_when_a_command_cant_be_found;

        public CommandRegistry(IEnumerable<IProcessOneSpecificTypeOfRequest> all_the_commands, IProcessOneSpecificTypeOfRequest command_to_use_when_a_command_cant_be_found)
        {
            this.all_the_commands = all_the_commands;
            this.command_to_use_when_a_command_cant_be_found = command_to_use_when_a_command_cant_be_found;
        }

        public IProcessOneSpecificTypeOfRequest get_the_command_that_can_process(IContainRequestDetails request)
        {
            return all_the_commands.First(x => x.can_handle(request));
        }
    }
}