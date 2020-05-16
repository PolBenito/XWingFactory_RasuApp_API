using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class ReferenceTypes
    {
        public short idReferenceType { get; set; }
        public string codeReferenceType { get; set; }
        public string descReferenceType { get; set; }
        
        public virtual ICollection<References> References { get; set; }
    }
}