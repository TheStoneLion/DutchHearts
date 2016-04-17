using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutchHearts.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}