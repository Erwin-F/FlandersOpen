namespace FlandersOpen.Infrastructure
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
