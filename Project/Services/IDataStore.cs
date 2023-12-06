using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public interface IDataStore
    {
        List<Team> TeamList { get; set; }
        Task<List<Team>> GetAllTeamsAsync();
        void AddTeamAsync(Team team);
        void DeleteTeamAsync(Team team);

        void UpdateTeamAsync(Team team);
        Task<Team> GetTeamAsync(Team team);
    }
}
