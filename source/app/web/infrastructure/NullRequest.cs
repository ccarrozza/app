using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.infrastructure
{
    public class NullRequest : IProcessOneSpecificTypeOfRequest
    {
        public void process(IContainRequestDetails request)
        {
        }

        public bool can_handle(IContainRequestDetails request)
        {
            return false;
        }
    }
}
