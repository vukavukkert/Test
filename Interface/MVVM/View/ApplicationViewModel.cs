using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Interface.Core;
using Microsoft.Win32;
using SumSeriesLib;
using System.Windows;

namespace Interface.MVVM.View
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
        private ObservableCollection<string> _list;
        public ObservableCollection<string> List
        {
            get
            {
                if (_list == null)
                {
                    return new ObservableCollection<string>();
                }
                return _list;

            }
            set
            {
                _list = value;
                OnPropertyChanged("List");
            }
        }
        #endregion
        #region Calculate
        private RelayCommand? _calculate;
        public RelayCommand CalculateX
        {
            get
            {
                return _calculate ?? (_calculate = new RelayCommand(obj =>
                    {
                        List = Calculation.CalculateSumSeries(X, Eps);
                    },
                    (obj) => Calculation.Module(X) < 1 || Eps  > 0));
            }
        }
        #endregion

        #region Clear
        private RelayCommand? _clear;
        public RelayCommand Clear
        {
            get
            {
                return _clear ?? (_clear = new RelayCommand(obj =>
                    {
                        List.Clear();
                        X = 0;
                        Eps = 0;
                    },
                    (obj) => true));
            }
        }
        #endregion

        #region MyRegion

        private RelayCommand? _save;
        public RelayCommand Save
        {
            get
            {
                return _save ?? (_save = new RelayCommand(obj =>
                    {
                        SaveFileDialog SaveFile = new SaveFileDialog();
                        if (SaveFile.ShowDialog() == true)
                            File.WriteAllLines(SaveFile.FileName +".txt", List.Select(item => item.ToString()));
                        Window dialogWindow = new Window();
                        MessageBox.Show("Сохранено успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    },
                    (obj) => List.Count >0));
            }
        }

        #endregion

        public ApplicationViewModel()
        {

        }
    }
}
