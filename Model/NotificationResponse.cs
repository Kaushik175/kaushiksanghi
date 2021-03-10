using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderPlacementSystem.Model
{
    public class NotificationResponse
    {
        public NotificationResponse()
        {
            this.NotificationStatus = NotificationStatus.Failed;
        }

        public virtual string ResponseId { get; set; }

        public Exception Exception { get; set; }

        public NotificationStatus NotificationStatus { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; }
    }

    public enum NotificationStatus
    {
        NotSent = 0,
        Sent = 1,
        Failed = 2
    }

    public enum DeliveryStatus
    {
        None = 0,
        Pending = 1,
        Delivered = 2,
        Bounced = 3,
        PartiallyBounced = 4
    }
}
