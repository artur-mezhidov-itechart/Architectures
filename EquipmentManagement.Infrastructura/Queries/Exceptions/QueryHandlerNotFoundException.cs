using System;

namespace EquipmentManagement.Infrastructura.Queries.Exceptions
{
    public class QueryHandlerNotFoundException : QueryExceptionBase
    {
        public Type ResultType { get; }

        public QueryHandlerNotFoundException(Type queryType, Type resultType, Exception innerException) : base(queryType, innerException)
        {
            ResultType = resultType;
        }
    }
}
