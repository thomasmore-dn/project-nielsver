using webAPI.Models;

namespace webAPI.dto
{
    public class TeamUpdateDto
    {
        
        public string TeamName { get; set; }
        
        public int Wins { get; set; }

        public int Losses { get; set; }

        public List<Player> Players {get; set;}

    }
}