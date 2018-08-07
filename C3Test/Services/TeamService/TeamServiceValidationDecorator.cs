using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using C3Test.Models;

namespace C3Test.Services.TeamService
{
    public class TeamServiceValidationDecorator : ITeamService
    {
        private readonly ITeamService _innerService;

        public TeamServiceValidationDecorator(ITeamService innerService)
        {
            _innerService = innerService;
        }

        public Task AddTeamMemberAsync(TeamMember newMember)
        {
            if(string.IsNullOrWhiteSpace(newMember.Specialization))
            {
                throw new ArgumentException("Team members need a specialization!");
            }

            return _innerService.AddTeamMemberAsync(newMember);
        }

        public Task<List<TeamMember>> GetTeamAsync()
        {
            return _innerService.GetTeamAsync();
        }
    }
}
