using AutoMapper;
using webAPI.dto;
using webAPI.Models;

namespace webAPI.Mappings
{
    public class TeamsProfile:Profile
    {
        public TeamsProfile()
        {
            CreateMap<Team, TeamsReadDto>();
            CreateMap<TeamWriteDto, Team>();
            CreateMap<TeamUpdateDto, Team>();
        }
    }
}