using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetFlixPrac.Models
{
    public class CustomeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }

        public MembershipType MembershipType { get; set; }

        [ForeignKey("MembershipType")]
        public int MembershipTypeId { get; set; }
    }
}