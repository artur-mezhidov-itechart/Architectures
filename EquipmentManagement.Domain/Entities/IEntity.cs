﻿namespace EquipmentManagement.Domain.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
