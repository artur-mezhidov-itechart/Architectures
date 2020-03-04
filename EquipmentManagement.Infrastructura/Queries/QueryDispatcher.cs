using System;
using Microsoft.Extensions.DependencyInjection;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Infrastructura.Queries.Exceptions;

namespace EquipmentManagement.Infrastructura.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public virtual TResult Execute<TResult>(IQuery<TResult> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            dynamic handler;

            try
            {
                Type handlerType = GetHandlerType(query);

                handler = serviceProvider.GetRequiredService(handlerType);
            }
            catch (Exception exception)
            {
                throw new QueryHandlerNotFoundException(query.GetType(), typeof(TResult), exception);
            }

            try
            {
                return handler.Handle((dynamic)query);
            }
            catch (QueryOnHandlingException exception)
            {
                // TODO: Logging
                throw exception;
            }
        }

        private Type GetHandlerType<TResult>(IQuery<TResult> query)
        {
            return typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        }
    }
}
