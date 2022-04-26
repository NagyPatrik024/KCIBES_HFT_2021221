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
    public class DriverWindowViewModel : ObservableRecipient
    {

        public RestCollection<Driver> Driver { get; set; }
        public RestCollection<Motor> Motor { get; set; }
        public RestCollection<Team> Team { get; set; }

        private Driver selectedDriver;

        public Driver SelectedDriver
        {
            get { return selectedDriver; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref selectedDriver, new Driver()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Age = value.Age,
                        MotorId = value.MotorId - 1,
                        TeamId = value.TeamId - 1,
                        Wins = value.Wins
                    });
                    OnPropertyChanged();
                    (DeleteDriverCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateDriverCommand as RelayCommand).NotifyCanExecuteChanged();
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
        public ICommand CreateDriverCommand { get; set; }

        public ICommand DeleteDriverCommand { get; set; }

        public ICommand UpdateDriverCommand { get; set; }
        public DriverWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Driver = new RestCollection<Driver>("http://localhost:17873/", "driver", "hub");
                Motor = new RestCollection<Motor>("http://localhost:17873/", "motor", "hub");
                Team = new RestCollection<Team>("http://localhost:17873/", "team", "hub");

                CreateDriverCommand = new RelayCommand(() =>
                    {
                        if (SelectedDriver.Name != null && SelectedDriver.MotorId != null && SelectedDriver.TeamId != null)
                        {
                            Driver.Add(new Driver()
                            {
                                Name = selectedDriver.Name,
                                Age = selectedDriver.Age,
                                MotorId = selectedDriver.MotorId + 1,
                                TeamId = selectedDriver.TeamId + 1,
                                Wins = selectedDriver.Wins
                            });
                        }
                    });

                UpdateDriverCommand = new RelayCommand(() =>
                {
                    if (SelectedDriver.Id != 0)
                    {
                        try
                        {
                            Driver.Update(new Driver()
                            {
                                Id = SelectedDriver.Id,
                                Name = SelectedDriver.Name,
                                Age = SelectedDriver.Age,
                                MotorId = SelectedDriver.MotorId + 1,
                                TeamId = SelectedDriver.TeamId + 1,
                                Wins = SelectedDriver.Wins
                            });
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        OnPropertyChanged("SelectedDriver");
                    }
                },
                () => SelectedDriver.Id != 0);

                DeleteDriverCommand = new RelayCommand(() =>
                {
                    if (SelectedDriver.Id != 0)
                    {
                        Driver.Delete(SelectedDriver.Id);
                        selectedDriver = new Driver();
                        OnPropertyChanged("SelectedDriver");
                    }

                },

               () => SelectedDriver.Id != 0);
                SelectedDriver = new Driver();
            }
        }
    }
}






