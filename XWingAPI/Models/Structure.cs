using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class Structure
    {
        public short idStructure { get; set; }
        public Nullable<short> idReferenceFinal { get; set; }
        public Nullable<short> idReferencePart { get; set; }
        public Nullable<short> NumberOfParts { get; set; }

        public virtual References Reference { get; set; }
        public virtual References Reference1 { get; set; }
    }
}