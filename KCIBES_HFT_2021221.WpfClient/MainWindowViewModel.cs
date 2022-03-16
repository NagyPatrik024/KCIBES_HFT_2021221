using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KCIBES_HFT_2021221.WpfClient
{
    public class MainWindowViewModel 
    {
        public ICommand DriverCommand { get; set; }
        public ICommand MotorCommand { get; set; }
        public ICommand TeamCommand { get; set; }

        public MainWindowViewModel()
        {
            DriverCommand = new RelayCommand(
                () => new DriverWindow().ShowDialog()
                ); 

            MotorCommand = new RelayCommand(
                () => new MotorWindow().ShowDialog()
                );

            TeamCommand = new RelayCommand(
                () => new TeamWindow().ShowDialog()
                );
        }
    }
}
