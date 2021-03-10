using OnlineOrderPlacementSystem.Model;

namespace OnlineOrderPlacementSystem.Contracts
{
    public interface INotificationContract
    {
        NotificationResponse Send(Email notification);
    }
}