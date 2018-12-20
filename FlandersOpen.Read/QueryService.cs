using System;

namespace FlandersOpen.Read
{
    public sealed class QueryService : IQueryService
    {
        private readonly IServiceProvider _provider;

        public QueryService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }
    }
}
