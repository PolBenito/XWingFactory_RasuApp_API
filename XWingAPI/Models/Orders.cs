using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class Orders
    {
        public short idOrder { get; set; }
        public string codeOrder { get; set; }
        public Nullable<System.DateTime> dateOrder { get; set; }
        public virtual ICollection<LOP> LOPs { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}