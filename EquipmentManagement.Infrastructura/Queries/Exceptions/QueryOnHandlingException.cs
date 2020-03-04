using System;

namespace EquipmentManagement.Infrastructura.Queries.Exceptions
{
    public class QueryOnHandlingException : QueryExceptionBase
    {
        public Type QueryHandlerType { get; set; }

        public QueryOnHandlingException(Type queryType, Type queryHandlerType, Exception innerException) : base(queryType, innerException)
        {
            QueryHandlerType = queryHandlerType;
        }
    }
}
