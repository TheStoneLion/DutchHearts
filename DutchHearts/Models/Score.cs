using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DutchHearts.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public virtual int PlayerID { get; set; }
        public int Value { get; set; }
    }
}