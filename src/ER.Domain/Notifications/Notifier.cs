using ER.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ER.Domain.Notifications
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notificacoes;

        public Notifier()
        {
            _notificacoes = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notificacoes.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notificacoes;
        }

        public bool HasNotifications()
        {
            return _notificacoes.Any();
        }
    }
}
