using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class OperationParts
    {
        public short idOperationParts { get; set; }
        public Nullable<short> idAssemblyInstructionsDetail { get; set; }
        public Nullable<short> idReference { get; set; }
        public Nullable<short> NumberOfPieces { get; set; }

        public virtual AssemblyInstructionsDetail AssemblyInstructionsDetail { get; set; }
        public virtual References Reference { get; set; }
    }
}