using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class OrdersDetail
    {
        public short idOrderDetail { get; set; }
        public Nullable<short> idOrder { get; set; }
        public Nullable<short> idPlanet { get; set; }
        public Nullable<short> idReference { get; set; }
        public Nullable<short> Quantity { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }

        public virtual Orders Order { get; set; }
    }
}