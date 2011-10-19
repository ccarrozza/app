 using Machine.Specifications;
 using app.web.infrastructure;
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
        
            It should_ = () =>        
                result
                
        }
    }
}
