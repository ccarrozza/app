namespace app.web.infrastructure
{
    public class Stub
    {
        public static ICreateRequests with<T>()
        {
            return new T();
        }
    }
}