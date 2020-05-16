using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class LOPDetails
    {
        public short idLOPDetail { get; set; }
        public short idLOP { get; set; }
        public short idReference { get; set; }
        public Nullable<short> Quantity { get; set; }
        
        public virtual ICollection<FinalProduct> FinalProducts { get; set; }
        public virtual ICollection<IntermediateProduct> IntermediateProducts { get; set; }
        public virtual LOP LOP { get; set; }
    }
}