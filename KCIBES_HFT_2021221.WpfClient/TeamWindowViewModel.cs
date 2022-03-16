using KCIBES_HFT_2021221.Models;
using KCIBES_HFT_2021221.WpfClient.RestCollection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KCIBES_HFT_2021221.WpfClient
{
    public class TeamWindowViewModel : ObservableRecipient
    {
        public RestCollection<Team> Team { get; set; }

        private Team selectedTeam;

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                    selectedTeam = new Team()
                    {
                        Id = value.Id,
                        Motor = value.Motor,
                        Name = value.Name,
                        MotorId = value.MotorId,
                        Team_Chief = value.Team_Chief
                    };
                    OnPropertyChanged();
                    (DeleteTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ICommand CreateTeamCommand { get; set; }

        public ICommand DeleteTeamCommand { get; set; }

        public ICommand UpdateTeamCommand { get; set; }
        public TeamWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Team = new RestCollection<Team>("http://localhost:17873/", "team", "hub");

                CreateTeamCommand = new RelayCommand(() =>
                {
                    Team.Add(new Team()
                    {
                        Id = SelectedTeam.Id,
                        Motor = SelectedTeam.Motor,
                        Name = SelectedTeam.Name,
                        MotorId = SelectedTeam.MotorId,
                        Team_Chief = SelectedTeam.Team_Chief
                    });
                });

                UpdateTeamCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Team.Update(SelectedTeam);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });

                DeleteTeamCommand = new RelayCommand(() =>
                {
                    Team.Delete(SelectedTeam.Id);
                },
               () =>
               {
                   return SelectedTeam != null;
               });
                SelectedTeam = new Team();
            }
        }
    }
}
