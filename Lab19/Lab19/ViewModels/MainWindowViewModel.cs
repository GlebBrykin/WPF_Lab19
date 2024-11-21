using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Lab19.Models;

namespace Lab19.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private double __radius;

        private double __length;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public MainWindowViewModel()
        {
            this.CalcLengthCommand = new RelayCommand(
                (object obj) =>
                {
                    this.Length = MyMath.CalcLengthUsingRadius(this.Radius);
                },
                (object obj) =>
                {
                    return this.Radius > 0;
                }
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double Radius
        {
            get
            {
                return this.__radius;
            }
            set
            {
                this.__radius = value;
                this.OnPropertyChanged();
            }
        }

        public double Length
        {
            get
            {
                return this.__length;
            }
            set
            {
                this.__length = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand CalcLengthCommand
        {
            get;
            private set;
        }

    }
}
