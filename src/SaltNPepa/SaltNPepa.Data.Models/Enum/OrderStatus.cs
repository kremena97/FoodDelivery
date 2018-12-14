using System;
using System.Collections.Generic;
using System.Text;

namespace SaltNPepa.Data.Models.Enum
{
    public enum OrderStatus
    {
        AwaitingАpproval = 1,
        Approved = 2,
        CookingProcess = 3,
        QualityCheck = 4,
        Delivery = 5,
        Delivered = 6
    }
}
