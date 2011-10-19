using System.Collections;
using System.Collections.Generic;

namespace app.web.infrastructure.stubs
{
    public class StubSetOfCommands : IEnumerable<IProcessOneSpecificTypeOfRequest>
    {
        public IEnumerator<IProcessOneSpecificTypeOfRequest> GetEnumerator()
        {
            yield return new StubCommand(true);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}