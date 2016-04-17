using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DutchHearts.Models
{
    public class GameOfHearts
    {
        public int GameOfHeartsID { get; set; }

        public int PlayerID { get; set; }
        public virtual List<Player> Players { get; set; }

        public int RoundID { get; set; }
        public virtual List<Round> Rounds { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime GameDate { get; set; }

        public int GamePhaseID { get; set; }
        public GamePhase CurrentGamePhase { get; set; }
    }
}