using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using C3Test.Models;
using C3Test.Repositories.TeamlidRepository;

namespace C3Test.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly ITeamMemberRepository _repository;

        public TeamService(ITeamMemberRepository repository)
        {
            _repository = repository;
        }

        public Task AddTeamMemberAsync(TeamMember newMember)
        {
            return _repository.StoreAsync(newMember);
        }

        public Task<List<TeamMember>> GetTeamAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
