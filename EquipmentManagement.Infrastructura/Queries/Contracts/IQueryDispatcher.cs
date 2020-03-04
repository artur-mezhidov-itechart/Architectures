namespace EquipmentManagement.Infrastructura.Queries.Contracts
{
    public interface IQueryDispatcher
    {
        TResult Execute<TResult>(IQuery<TResult> query);
    }
}
