using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class Status
    {
        public short idStatus { get; set; }
        public string codeStatus { get; set; }
        public string descStatus { get; set; }
        
        public virtual ICollection<FinalProduct> FinalProducts { get; set; }
        public virtual ICollection<IntermediateProduct> IntermediateProducts { get; set; }
    }
}