 using Machine.Specifications;
 using app.web.infrastructure;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
    [Subject(typeof(ViewTheDepartmentsInADepartment))]  
    public class ViewTheDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<IEncapsulateUserFunctionality,
                                            ViewTheDepartmentsInADepartment>
        {
        
        }

   
        public class when_run : concern
        {
        
            It first_observation = () =>        
                
        }
    }
}
