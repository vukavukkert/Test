using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SumInterface.Core;
using SumInterface.Properties;


namespace SumInterface.MVVM.View
{
    public class ApplicationViewModel : ObservableObject
    {
        #region X parametr
        private double _x;
        public double X
        {
            get { return _x; }
            set
            {
                _x = value; 
                OnPropertyChanged("X");
            }
        }
        #endregion

        #region eps parametr
        private double _eps;
        public double Eps
        {
            get { return _eps; }
            set
            {
                _eps = value; 
                OnPropertyChanged("Eps");
            }
        }
        #endregion

        #region CalculationList
        private ObservableCollection<double> _list;
        public ObservableCollection<double> List
        {
            get { return _list; }
            set
            {
                _list = value; 
                OnPropertyChanged("List");
            }
        }
        #endregion

        private RelayCommand _calculate;

        public RelayCommand Calculate
        {
            get { return _calculate ?? (_calculate = new RelayCommand(obj =>
            {
                
            },
                (obj) => X != null && Eps != null)); }
        }

        public ApplicationViewModel()
        {

        }
    }
}
