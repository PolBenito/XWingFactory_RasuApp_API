using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class StockMovements
    {
        public short idStockMovement { get; set; }
        public short idStockMovementTypes { get; set; }
        public Nullable<short> Quantity { get; set; }
        public Nullable<short> idDocument { get; set; }
    }
}