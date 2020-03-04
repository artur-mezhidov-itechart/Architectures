using System;
using EquipmentManagement.Infrastructura.Queries.Contracts;
using EquipmentManagement.Infrastructura.Queries.Exceptions;

namespace EquipmentManagement.Infrastructura.Queries
{
    public abstract class QueryHandlerBase<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        protected abstract TResult OnHandling(TQuery query);

        public TResult Handle(TQuery query)
        {
            try
            {
                TResult result = OnHandling(query);

                if (result == null)
                {
                    throw new QueryResultNotFoundException(GetType(), query);
                }

                return result;
            }
            catch (Exception exception)
            {
                throw new QueryOnHandlingException(typeof(TQuery), GetType(), exception);
            }
        }
    }
}
