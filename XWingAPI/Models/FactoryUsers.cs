using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XWingAPI.Models
{
    public class FactoryUsers
    {
        public short idUser { get; set; }
        public string UserName { get; set; }
        public short idUserType { get; set; }
        public string password { get; set; }
    }
}