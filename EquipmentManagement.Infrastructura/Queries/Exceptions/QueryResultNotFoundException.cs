using System;

namespace EquipmentManagement.Infrastructura.Queries.Exceptions
{
    public class QueryResultNotFoundException : QueryExceptionBase
    {
        public object Query { get; }

        public QueryResultNotFoundException(Type queryType, object query) : base(queryType)
        {
            Query = query;
        }
    }
}
