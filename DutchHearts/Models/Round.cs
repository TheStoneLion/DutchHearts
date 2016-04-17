using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DutchHearts.Models
{
    public class Round
    {
        public int RoundID { get; set; }
        public int SequenceNumber { get; set; }
        public virtual int ScoreID { get; set; }

        public int GamePhaseID { get; set; }
        public GamePhase CurrentGamePhase { get; set; }
    }
}