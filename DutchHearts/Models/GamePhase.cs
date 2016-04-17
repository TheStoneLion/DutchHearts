using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutchHearts.Models
{
    [Flags]
    enum enumGamePhase
    {
        Brengen,
        Halen,
        Einde
    }
    public class GamePhase
    {
        public int GamePhaseID { get; set; }

        [Required]
        [EnumDataType(typeof(enumGamePhase))]
        public string Phase { get; set; }
    }
}