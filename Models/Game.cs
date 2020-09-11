using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudaciaBallAPI.Models
{
    public class Game
    {
        public int idGame { get; set; }
        public int scoreBlue { get; set; }
        public int scoreRed { get; set; }
        public int fk_idPlayerBlue { get; set; }
        public int fk_idPlayerRed { get; set; }
        public DateTime gameDate { get; set; }
    }
}