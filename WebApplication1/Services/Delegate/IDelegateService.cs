namespace WebApplication1.Services.Delegate
{
    public interface IDelegateService
    {
        string Introduction(string name, Func<string, string, string> callback);
        string Hello(string firstname, string role);
        string Bye(string firstname, string role);
        List<string> NotifyAll(string name);
    }

}
