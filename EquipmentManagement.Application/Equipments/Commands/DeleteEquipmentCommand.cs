using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Equipments.Commands
{
    public class DeleteEquipmentCommand : CommandBase
    {
        public int Id { get; }

        public DeleteEquipmentCommand(int id)
        {
            Id = id;
        }
    }
}
