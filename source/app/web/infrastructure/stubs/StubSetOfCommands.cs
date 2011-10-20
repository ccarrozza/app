using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.infrastructure.stubs
{
    public class StubSetOfCommands : IEnumerable<IProcessOneSpecificTypeOfRequest>
    {
        public IEnumerator<IProcessOneSpecificTypeOfRequest> GetEnumerator()
        {
            yield return new RequestCommand(x => true,
                                            new ViewTheMainDepartments());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}