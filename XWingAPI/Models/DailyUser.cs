using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XWingAPI.Models
{
    public class DailyUser
    {
        public short idDailyUser { get; set; }
        public short idUser { get; set; }
        public short idAssemblyInstructions { get; set; }

        public virtual FactoryUsers FactoryUser { get; set; }
        public virtual AssemblyInstructions AssemblyInstruction { get; set; }
    }
}
