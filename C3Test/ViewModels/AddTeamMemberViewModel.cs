using System;
using System.Diagnostics;
using C3Test.Models;
using C3Test.Services.NavigationService;
using C3Test.Services.TeamService;
using Xamarin.Forms;

namespace C3Test.ViewModels
{
    public class AddTeamMemberViewModel : BaseViewModel
    {
        private readonly ITeamService _teamService;
        private readonly INavigationService<Page> _navigationService;
        private TeamMember _member;

        public string Name
        {
            get { return _member.Name; }
            set
            {
                _member.Name = value;
                RaisePropertyChanged();
            }
        }

        public string Specialization
        {
            get { return _member.Specialization; }
            set 
            {
                _member.Specialization = value;
                RaisePropertyChanged();
            }
        }

        public bool WantsCoffee
        {
            get { return _member.WantsCoffee; }
            set
            {
                _member.WantsCoffee = value;
                RaisePropertyChanged();
            }
        }

        private Command _saveCommand;
        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(async () =>
                {
                    try
                    {
                        await _teamService.AddTeamMemberAsync(_member);
                    }
                    catch(ArgumentException)
                    {
                        Debug.WriteLine("Looks like this isn't valid...");
                    }
                    finally
                    {
                        await _navigationService.PopCurrentPageModal();
                    }
                }));
            }
        }
        public AddTeamMemberViewModel(ITeamService teamService, INavigationService<Page> navigationService)
        {
            _teamService = teamService;
            _navigationService = navigationService;
            _member = new TeamMember();
        }
    }
}

