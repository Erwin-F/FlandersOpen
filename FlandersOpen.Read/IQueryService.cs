namespace FlandersOpen.Read
{
    public interface IQueryService
    {
        T Dispatch<T>(IQuery<T> query);
    }
}
