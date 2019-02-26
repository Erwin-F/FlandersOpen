namespace FlandersOpen.Application.Core
{
    public class ConnectionStrings
    {
        public ConnectionStrings(string value)
        {
            Default = value;
        }

        public string Default { get; }
    }
}
