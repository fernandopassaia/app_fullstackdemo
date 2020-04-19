using AppFullStackDemo.Domain.Enums;
using Flunt.Notifications;
using System;

namespace AppFullStackDemo.Domain.Entities
{
    //Note: I'm using a package called "FluentValidator" that allow to Add Domain Notifications. So all my validations will
    //be at my Domain, based on Contracts and i will have methods to add, get, see if my Entitie is valid. You'll see.

    public abstract class EntityBase : Notifiable
    {
        public EntityBase()
        {
            CreatedBy = Id.ToString();
            UpdatedBy = Id.ToString();
            CreatedIn = DateTime.Now;
            UpdatedIn = DateTime.Now;
            Status = ECommonStatus.Active;
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

        public void Remove()
        {
            Status = ECommonStatus.Removed;
        }
    }
}