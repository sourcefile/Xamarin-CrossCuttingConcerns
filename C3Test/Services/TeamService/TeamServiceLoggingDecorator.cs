using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using C3Test.Models;

namespace C3Test.Services.TeamService
{
    public class TeamServiceLoggingDecorator : ITeamService
    {
        private readonly ITeamService _innerService;

        public TeamServiceLoggingDecorator(ITeamService innerService)
        {
            _innerService = innerService;
        }

        public async Task AddTeamMemberAsync(TeamMember newMember)
        {
            Debug.WriteLine($"Begin adding member {newMember.Name}");
            await _innerService.AddTeamMemberAsync(newMember);
            Debug.WriteLine($"Finished adding member {newMember.Name}");
        }

        public async Task<List<TeamMember>> GetTeamAsync()
        {
            Debug.WriteLine("Begin retrieving Team");
            var result = await _innerService.GetTeamAsync();
            Debug.WriteLine($"Fetched team containing {result.Count} members");
            return result;
        }
    }
}
