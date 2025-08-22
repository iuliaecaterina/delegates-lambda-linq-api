namespace WebApplication1.Services.Delegate
{
    public class DelegateService : IDelegateService
    {
        public string Introduction(string name, Func<string, string, string> callback)
        {
            return callback(name, "Student");
        }

        public string Hello(string firstname, string role)
        {
            return $"Hello, {firstname}! You are a {role}.";
        }

        public string Bye(string firstname, string role)
        {
            return $"Goodbye, {firstname}. Role: {role}.";
        }

        public List<string> NotifyAll(string name)
        {
            List<string> messages = new();

            MyDelegate d1 = Hello;
            MyDelegate d2 = Bye;

            MyDelegate multicast = d1 + d2;

            foreach (var del in multicast.GetInvocationList())
            {
                var method = (MyDelegate)del;
                messages.Add(method(name, "Student"));
            }

            return messages;
        }

        public delegate string MyDelegate(string firstname, string role);
    }
}
