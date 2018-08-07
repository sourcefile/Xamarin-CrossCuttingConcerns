using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.Service.Dreams;
using Autofac;
using C3Test.Models;
using C3Test.Services.NavigationService;
using C3Test.Services.TeamService;
using Xamarin.Forms;

namespace C3Test.ViewModels
{
    public class TeamOverviewViewModel : BaseViewModel
    {
        private readonly ITeamService _teamService;
        private readonly INavigationService<Page> _navigationService;

        private Command _refreshCommand;
        public Command RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new Command(async() => {
                    IsRefreshing = true;
                    var records = await _teamService.GetTeamAsync();
                    TeamMembers = new ObservableCollection<TeamMember>(records);
                    IsRefreshing = false;

                }));
            }
        }

        private Command _openAddMemberPageCommand;
        public Command OpenAddMemberPageCommand
        {
            get
            {
                return _openAddMemberPageCommand ?? (_openAddMemberPageCommand = new Command(async() => {
                    var nextScreen = App.Container.Resolve<AddTeamMemberViewModel>();
                    await _navigationService.PushPageModal(nextScreen);
                }));
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<TeamMember> _teamMembers;
        public ObservableCollection<TeamMember> TeamMembers
        {
            get { return _teamMembers; }
            set
            {
                _teamMembers = value;
                RaisePropertyChanged();
            }
        }
        public TeamOverviewViewModel(ITeamService teamService, INavigationService<Page> navigationService)
        {
            _teamService = teamService;
            _navigationService = navigationService;
        }
    }
}
