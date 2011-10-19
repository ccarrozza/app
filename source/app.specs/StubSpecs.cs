using Machine.Specifications;
using app.web.infrastructure;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(Stub))]
    public class StubSpecs
    {
        public abstract class concern : Observes
        {
        }

        public class when_getting_an_instance_of_a_stub : concern
        {
            Because b = () =>
                result = Stub.with<SomeStub>();

            It should_return_an_instance_of_the_stub_type_requested = () =>
                result.ShouldBeAn<SomeStub>();

            static SomeStub result;
        }
    }

    public class SomeStub
    {
    }
}