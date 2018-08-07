using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using C3Test.Models;

namespace C3Test.Services.TeamService
{
    /// <summary>
    /// Team service.
    /// Responsible for business logic concerning a team.
    /// </summary>
    public interface ITeamService
    {
        Task<List<TeamMember>> GetTeamAsync();
        Task AddTeamMemberAsync(TeamMember newMember);
    }
}
