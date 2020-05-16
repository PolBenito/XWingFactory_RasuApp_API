using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class References
    {
        public short idReference { get; set; }
        public string codeReference { get; set; }
        public string descReference { get; set; }
        public string Photo { get; set; }
        public string VideoExplode { get; set; }
        public short idReferenceType { get; set; }
        
        public virtual ICollection<AssemblyInstructions> AssemblyInstructions { get; set; }
        public virtual ICollection<OperationParts> OperationParts { get; set; }
        public virtual ReferenceTypes ReferenceType { get; set; }
        public virtual ICollection<Structure> Structures { get; set; }
        public virtual ICollection<Structure> Structures1 { get; set; }
    }
}