using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class AssemblyInstructionsDetail
    {
        public short idAssemblyInstructionsDetail { get; set; }
        public short idAssemblyInstructions { get; set; }
        public string CodeOperation { get; set; }
        public string DescOperation { get; set; }
        public Nullable<short> NumberOfUsers { get; set; }
        public Nullable<short> OperationOrder { get; set; }

        public virtual AssemblyInstructions AssemblyInstruction { get; set; }
        public virtual ICollection<OperationParts> OperationParts { get; set; }
    }
}