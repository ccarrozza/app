using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.infrastructure;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ViewTheProductsInADepartment))]
    public class ViewTheProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<IEncapsulateUserFunctionality,
                                            ViewTheProductsInADepartment>
        {
        }

        public class when_run : concern
        {
            It first_observation = () => 
        }
    }
}