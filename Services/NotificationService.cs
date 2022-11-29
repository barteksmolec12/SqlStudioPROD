using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace SqlStudioPROD {
    public class NotificationService : INotificationService {

        private Notifier notifier { get; set; }
        public NotificationService() {

        }
       
        public void AddNotificaton(NotificationsType notificationType, int notificationTime, string notificationMessage) {

            try {
                notifier = new Notifier(cfg => {
                    cfg.PositionProvider = new WindowPositionProvider(
                        parentWindow: Application.Current.MainWindow,
                        corner: Corner.BottomRight,
                        offsetX: 10,
                        offsetY: 10);

					cfg.DisplayOptions.TopMost = false; // set the option to show notifications under other windows

					cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                        notificationLifetime: TimeSpan.FromSeconds(notificationTime),
                        maximumNotificationCount: MaximumNotificationCount.FromCount(2));
                    
                    cfg.Dispatcher = Application.Current.MainWindow.Dispatcher;
                });

                switch (notificationType) {
                   
                    case NotificationsType.Succes:
                       
                        notifier.ShowSuccess(notificationMessage);
                        break;

                    case NotificationsType.Information:
                        notifier.ShowInformation(notificationMessage);
                        break;

                    case NotificationsType.Warning:

                        notifier.ShowWarning(notificationMessage);
                        break;


                    case NotificationsType.Error:
                        notifier.ShowError(notificationMessage);
                        break;

                    default:
                        //notification type is not supported
                        break;
                }
            } catch (Exception) {

               
            }
          

        }
    }
}
