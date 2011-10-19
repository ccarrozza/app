 using Machine.Specifications;
 using app.web.infrastructure;
 using app.web.infrastructure.stubs;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(Stub))]  
    public class StubSpecs
    {
        public abstract class concern : Observes<Stub>
        {
        
        }

   
        public class when_getting_an_instance_of_a_stub : concern
        {
           Because b = () =>
                result = sut.with<StubRequestFactory>();

            It should_return_a_stub_request_instance = () =>
                result.ShouldBeOfType<StubRequestFactory>();

           static StubRequestFactory result;
        }
    }
}
