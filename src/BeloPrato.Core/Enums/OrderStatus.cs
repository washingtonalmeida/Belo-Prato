using System;
using System.Collections.Generic;
using System.Text;

namespace BeloPrato.Core.Enums
{
    public enum OrderStatus
    {
        Draft = 0,
        Requested = 1,
        Declined = 2,
        InPreparation = 3,
        Canceled = 4,
        Prepared = 5,
        Finished = 6
    }
}
