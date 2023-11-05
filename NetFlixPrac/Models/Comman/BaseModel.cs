using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFlixPrac.Models.Comman
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public BaseModel()
        {
            this.IsActive = true;
        }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}