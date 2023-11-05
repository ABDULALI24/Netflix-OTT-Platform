using NetFlixPrac.Models.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFlixPrac.Models
{
    public class MembershipType :BaseModel
    {
        public MembershipType()
        {
            this.IsActive = true;
        }
        public string Name { get; set; }
        public int DurationInMonth { get; set; }
    }
}