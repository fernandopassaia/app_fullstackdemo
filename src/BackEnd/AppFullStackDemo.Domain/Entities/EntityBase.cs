using AppFullStackDemo.Domain.Enums;
using Flunt.Notifications;
using System;

namespace AppFullStackDemo.Domain.Entities
{
    // Note: I'm using a strategy called "FluentValitation" or "Validation by Contract", so basically this base-class is inheriting from "Notifiable"
    // (this one comes from Flunt, a package to validate strings, dates...) and all my "Entities" will have a "Validate()" method to validate if the
    // Entity is in a Valid state. I could also "extend" it by Validating the Commands, but, in this case I'll not increase too much keeping on entities.

    public abstract class EntityBase : Notifiable, IEquatable<EntityBase>
    {
        public EntityBase()
        {
            CreatedBy = Id.ToString();
            UpdatedBy = Id.ToString();
            CreatedIn = DateTime.Now;
            UpdatedIn = DateTime.Now;
            Activate();
        }

        public string CreatedBy { get; private set; }

        public DateTime CreatedIn { get; private set; }

        public Guid Id { get; private set; } = new Guid();

        public ECommonStatus Status { get; private set; }

        public string UpdatedBy { get; private set; }

        public DateTime UpdatedIn { get; private set; }

        public void Activate()
        {
            Status = ECommonStatus.Active;
        }

        public void AwaitingAuthorization()
        {
            Status = ECommonStatus.AwaitingAuthorization;
        }

        public void Created()
        {
            Status = ECommonStatus.Created;
        }

        public void Deactivate()
        {
            Status = ECommonStatus.Inactive;
        }

        public bool Equals(EntityBase other)
        {
            return Id == other.Id;
        }

        public void Remove()
        {
            Status = ECommonStatus.Removed;
        }
    }
}