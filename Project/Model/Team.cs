using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Team
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }

        public int TotalPoints => (Wins * 3) + (1 * Loses);
        public int GamesPlayed => Wins + Loses;

        public List<Player> Players { get; set; } = new List<Player>();
    }

    public class Player
    {
        public int PlayerId { get; set; }

        public int TeamId {get; set; }
        public string? Name { get; set; }
        public int TotalPoints { get; set; }
        public int GamesPlayed { get; set; }
        public string? Position { get; set; }

        public double PointsPerGame => GamesPlayed > 0 ? Math.Round((double)TotalPoints / GamesPlayed, 2) : 0;

    }
}