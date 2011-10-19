 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using app.web.infrastructure;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(CommandRegistry))]  
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<IFindCommandsThatCanProcessRequests,
                                            CommandRegistry>
        {
        
        }

   
        public class when_finding_a_command_that_can_process_a_request : concern
        {

            public class and_it_has_the_command:when_finding_a_command_that_can_process_a_request
            {
                Establish c = () =>
                {
                    all_the_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessOneSpecificTypeOfRequest>()).ToList();
                    request = fake.an<IContainRequestDetails>();
                    the_command_that_can_process_the_request = fake.an<IProcessOneSpecificTypeOfRequest>();


                    the_command_that_can_process_the_request.setup(x => x.can_handle(request)).Return(true);

                    all_the_commands.Add(the_command_that_can_process_the_request);

                    depends.on<IEnumerable<IProcessOneSpecificTypeOfRequest>>(all_the_commands);
                };

                Because b = () =>
                    result = sut.get_the_command_that_can_process(request);


                It should_return_the_command_that_can_process_the_request = () =>
                    result.ShouldEqual(the_command_that_can_process_the_request);


                static IProcessOneSpecificTypeOfRequest result;
                static IProcessOneSpecificTypeOfRequest the_command_that_can_process_the_request;
                static IContainRequestDetails request;
                static IList<IProcessOneSpecificTypeOfRequest> all_the_commands;
            }
        }
    }
}
