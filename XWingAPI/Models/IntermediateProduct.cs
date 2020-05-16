using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class IntermediateProduct
    {
        public short idIntermediateProduct { get; set; }
        public short idReference { get; set; }
        public short idLOPDetail { get; set; }
        public string ReferenceCode { get; set; }
        public short idStatus { get; set; }
        public short idUser { get; set; }
        
        public virtual ICollection<FinalProductDetails> FinalProductDetails { get; set; }
        public virtual LOPDetails LOPDetail { get; set; }
        public virtual Status Status { get; set; }
    }
}