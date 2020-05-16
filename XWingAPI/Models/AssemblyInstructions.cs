using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class AssemblyInstructions
    {
        public short idAssemblyInstructions { get; set; }
        public Nullable<short> idreference { get; set; }
        public byte[] Instructions { get; set; }

        public virtual References Reference { get; set; }
        public virtual ICollection<AssemblyInstructionsDetail> AssemblyInstructionsDetails { get; set; }
    }
}