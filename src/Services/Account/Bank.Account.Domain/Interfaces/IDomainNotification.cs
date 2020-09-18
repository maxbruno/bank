using FluentValidation.Results;
using System.Collections.Generic;
using Bank.Account.Domain.Notifications;

namespace Bank.Account.Domain.Interfaces
{
    public interface IDomainNotification
    {
        IReadOnlyCollection<NotificationMessage> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message);
        void AddNotifications(IEnumerable<NotificationMessage> notifications);
        void AddNotifications(ValidationResult validationResult);
    }
}