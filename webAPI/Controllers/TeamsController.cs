using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webAPI.dto;
using webAPI.Models;
using webAPI.Repositories;


namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {

        private readonly IRepo _repo;
        private readonly IMapper _map;

        public TeamsController(IRepo repo, IMapper map) {
            _repo = repo;
            _map = map;
        }

        [HttpGet]
        public ActionResult GetAllTeams() {
            return Ok(_map.Map<IEnumerable<TeamsReadDto>>(_repo.GetAllTeams()));
        }
        
        [HttpGet("{id}", Name ="GetTeamById")]
        public ActionResult GetTeamById(int id) {
            
            return Ok(_map.Map<TeamsReadDto>(_repo.GetTeamById(id)));
        }

        [HttpPost]
        public ActionResult AddTeam(TeamWriteDto t){
            var Team = _map.Map<Team>(t);
            _repo.AddTeam(Team);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetTeamById), new {id= Team.TeamId}, Team);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTeam(int id, TeamUpdateDto t){
            var teamToUpdate = _repo.GetTeamById(id);
            if (teamToUpdate == null) {
                return NotFound();
            }

            _map.Map(t, teamToUpdate);
            
            _repo.UpdateTeam(teamToUpdate);

            _repo.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteTeam(int id) {
            var teamToDelete = _repo.GetTeamById(id);
            if (teamToDelete == null) {
                return NotFound();
            }
            _repo.DeleteTodo(teamToDelete);
            _repo.SaveChanges();
            
            return Ok();

        }



    }
}