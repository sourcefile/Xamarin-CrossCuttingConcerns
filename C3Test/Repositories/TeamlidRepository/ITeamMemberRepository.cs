using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using C3Test.Models;

namespace C3Test.Repositories.TeamlidRepository
{
    /// <summary>
    /// Team member repository.
    /// CRUD actions for TeamMembers
    /// </summary>
    public interface ITeamMemberRepository
    {
        Task<List<TeamMember>> GetAllAsync();
        Task StoreAsync(TeamMember teamlid);
    }
}
