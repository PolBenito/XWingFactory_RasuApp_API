using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class FinalProductDetails
    {
        public short idFinalProductDetail { get; set; }
        public short idFinalProduct { get; set; }
        public short idIntermediateProduct { get; set; }

        public virtual FinalProduct FinalProduct { get; set; }
        public virtual IntermediateProduct IntermediateProduct { get; set; }
    }
}