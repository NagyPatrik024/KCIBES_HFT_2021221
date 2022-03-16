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

        private Driver selectedDriver;

        public Driver SelectedDriver
        {
            get { return selectedDriver; }
            set
            {
                if (value != null)
                {
                    selectedDriver = new Driver()
                    {
                        Name = value.Name,
                        Age = value.Age,
                        Motor = value.Motor,
                        MotorId = value.MotorId,
                        Team = value.Team,
                        TeamId = value.TeamId,
                        Id = value.Id,
                        Wins = value.Wins
                    };
                    OnPropertyChanged();
                    (DeleteDriverCommand as RelayCommand).NotifyCanExecuteChanged();
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
                Driver = new RestCollection<Driver>("http://localhost:17873/", "driver");

                CreateDriverCommand = new RelayCommand(() =>
                {
                    Driver.Add(new Driver()
                    {
                        Name = selectedDriver.Name,
                        Age = selectedDriver.Age,
                        Motor = selectedDriver.Motor,
                        MotorId = selectedDriver.MotorId,
                        Team = selectedDriver.Team,
                        TeamId = selectedDriver.TeamId,
                        Wins = selectedDriver.Wins
                    });
                });

                UpdateDriverCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Driver.Update(SelectedDriver);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });

                DeleteDriverCommand = new RelayCommand(() =>
                {
                    Driver.Delete(SelectedDriver.Id);
                },
               () =>
               {
                   return SelectedDriver != null;
               });
                SelectedDriver = new Driver();
            }
        }
    }
}






