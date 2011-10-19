namespace app.web.infrastructure
{
    public class Stub
    {
        public static TheStub with<TheStub>() where TheStub : new()
        {
            return new TheStub();
        }
    }
}