using webAPI.Models;

namespace webAPI.dto
{
    public class TeamsReadDto
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }
        
        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Points
        {
            get { return Wins * 3 + Losses; }

        }
        public int Games
        {
            get { return Wins + Losses; }

        }
        public List<Player> Players {get; set;}
    }
}