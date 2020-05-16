using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class LOP
    {
        public short idLOP { get; set; }
        public short idOrder { get; set; }

        public virtual Orders Order { get; set; }
        public virtual ICollection<LOPDetails> LOPDetails { get; set; }
    }
}