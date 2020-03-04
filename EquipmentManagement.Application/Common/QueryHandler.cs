using EquipmentManagement.Domain.Data;
using EquipmentManagement.Infrastructura.Queries;
using EquipmentManagement.Infrastructura.Queries.Contracts;

namespace EquipmentManagement.Application.Common
{
    public abstract class QueryHandler<TQuery, TResult> : QueryHandlerBase<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        protected DataContext DataContext { get; }

        protected QueryHandler(DataContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}
