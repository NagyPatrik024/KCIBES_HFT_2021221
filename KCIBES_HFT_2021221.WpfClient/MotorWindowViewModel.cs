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
                    selectedMotor = new Motor()
                    {
                        Id = value.Id,
                        Type = value.Type
                    };
                    OnPropertyChanged();
                    (DeleteMotorCommand as RelayCommand).NotifyCanExecuteChanged();
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
                    Motor.Add(new Motor()
                    {
                        Type = selectedMotor.Type
                    });
                });

                UpdateMotorCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Motor.Update(SelectedMotor);
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });

                DeleteMotorCommand = new RelayCommand(() =>
                {
                    Motor.Delete(SelectedMotor.Id);
                },
               () =>
               {
                   return SelectedMotor != null;
               });
                SelectedMotor = new Motor();
            }
        }
    }
}
