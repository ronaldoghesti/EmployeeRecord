using ER.Domain.Notifications;
using System.Collections.Generic;

namespace ER.Domain.Interfaces
{
    public interface INotifier
    {
        bool HasNotifications();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
