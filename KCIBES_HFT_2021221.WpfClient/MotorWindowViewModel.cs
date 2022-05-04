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
    public class MotorWindowViewModel : ObservableRecipient
    {
        public RestCollection<Motor> Motor { get; set; }

        private Motor selectedMotor;

        public Motor SelectedMotor
        {
            get { return selectedMotor; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref selectedMotor, new Motor()
                    {
                        Id = value.Id,
                        Type = value.Type
                    });
                    OnPropertyChanged();
                    (DeleteMotorCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateMotorCommand as RelayCommand).NotifyCanExecuteChanged();
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
        public ICommand CreateMotorCommand { get; set; }

        public ICommand DeleteMotorCommand { get; set; }

        public ICommand UpdateMotorCommand { get; set; }
        public MotorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Motor = new RestCollection<Motor>("http://localhost:17873/", "motor", "hub");

                CreateMotorCommand = new RelayCommand(() =>
                {
                    if (SelectedMotor != null)
                    {
                        Motor.Add(new Motor()
                        {
                            Type = selectedMotor.Type
                        });
                        Thread.Sleep(170);
                        Motor.Update(Motor.First());
                    }
                });

                UpdateMotorCommand = new RelayCommand(() =>
                {
                    if (SelectedMotor.Id != 0)
                    {
                        try
                        {
                            Motor.Update(SelectedMotor);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        OnPropertyChanged("SelectedMotor");
                    }
                }, () => SelectedMotor.Id != 0);

                DeleteMotorCommand = new RelayCommand(() =>
                {
                    if (SelectedMotor.Type != null)
                    {
                        Motor.Delete(SelectedMotor.Id);
                        selectedMotor = new Motor();
                        OnPropertyChanged("SelectedMotor");
                    }
                },
               () => SelectedMotor.Id != 0);
                SelectedMotor = new Motor();
            }
        }
    }
}
