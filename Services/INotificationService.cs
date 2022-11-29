using System;
using System.Collections.Generic;
using System.Text;

namespace SqlStudioPROD {
    public interface INotificationService {
        void AddNotificaton(NotificationsType notificationType,int notificationTime,string notificationMessage);
    }
}
