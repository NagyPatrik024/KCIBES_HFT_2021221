using KCIBES_HFT_2021221.Models;
using KCIBES_HFT_2021221.WpfClient.RestCollection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KCIBES_HFT_2021221.WpfClient
{
    public class TeamWindowViewModel : ObservableRecipient
    {
        public RestCollection<Team> Team { get; set; }
        public RestCollection<Motor> Motor { get; set; }

        private Team selectedTeam;

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref selectedTeam, new Team()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        MotorId = value.MotorId - 1,
                        Team_Chief = value.Team_Chief
                    });
                    OnPropertyChanged();
                    (DeleteTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateTeamCommand as RelayCommand).NotifyCanExecuteChanged();
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
                Motor = new RestCollection<Motor>("http://localhost:17873/", "motor", "hub");

                CreateTeamCommand = new RelayCommand(() =>
                {
                    if (SelectedTeam.MotorId != null && SelectedTeam.Name != null && SelectedTeam.Team_Chief != null)
                    {
                        Team.Add(new Team()
                        {
                            Name = SelectedTeam.Name,
                            MotorId = SelectedTeam.MotorId + 1,
                            Team_Chief = SelectedTeam.Team_Chief
                        });
                        Thread.Sleep(170);
                        Team.Update(Team.First());
                    }
                });

                UpdateTeamCommand = new RelayCommand(() =>
                {
                    if (SelectedTeam.Id != 0)
                    {
                        try
                        {
                            Team.Update(new Team()
                            {
                                Id = SelectedTeam.Id,
                                Name = SelectedTeam.Name,
                                MotorId = SelectedTeam.MotorId + 1,
                                Team_Chief = SelectedTeam.Team_Chief
                            });
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        OnPropertyChanged("SelectedTeam");
                    }
                },
                () => SelectedTeam.Id != 0);

                DeleteTeamCommand = new RelayCommand(() =>
                {
                    Team.Delete(SelectedTeam.Id);
                    selectedTeam = new Team();
                    OnPropertyChanged("SelectedTeam");
                },
               () => SelectedTeam.Id != 0);
                SelectedTeam = new Team();
            }
        }
    }
}
