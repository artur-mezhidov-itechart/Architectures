using System;

namespace EquipmentManagement.Infrastructura.Queries.Exceptions
{
    public abstract class QueryExceptionBase : Exception
    {
        public Type QueryType { get; }

        protected QueryExceptionBase(Type queryType) : this(queryType, null)
        {
        }

        protected QueryExceptionBase(Type queryType, Exception innerException) : base(innerException.Message, innerException)
        {
            QueryType = queryType;
        }
    }
}
