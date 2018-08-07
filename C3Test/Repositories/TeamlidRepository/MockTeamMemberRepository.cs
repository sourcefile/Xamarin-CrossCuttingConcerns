using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using C3Test.Models;

namespace C3Test.Repositories.TeamlidRepository
{
    public class MockTeamMemberRepository : ITeamMemberRepository
    {
        private readonly List<TeamMember> _dummyData;

        public MockTeamMemberRepository()
        {
            _dummyData = new List<TeamMember>
            {
                new TeamMember { Name = "Mike Zuidhoek", Specialization = "Nagging", WantsCoffee = true },
                new TeamMember { Name = "Patrick van Roekel", Specialization = "Overlord", WantsCoffee = false },
                new TeamMember { Name = "Joline Davidse", Specialization = "Business handling", WantsCoffee = true }
            };
        }

        public Task<List<TeamMember>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return _dummyData;
            });
        }

        public Task StoreAsync(TeamMember teamlid)
        {
            return Task.Run(() =>
            {
                _dummyData.Add(teamlid);
            });
        }
    }
}
