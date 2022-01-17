
using LabControllerSim.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LabControllerSim.Modules.ObjectModels.Models
{
    public class SingleReservoirModel : ObservableObject
    {
        private double _waterLevel =0;
        public double WaterLevel
        {
            get { return _waterLevel; }
            set { ConvertedWaterLevel = (_waterLevel + 1)/-1000; OnPropertyChange(ref _waterLevel, value); }
        }

        private double _convertedWaterLevel=0.001;
        public double ConvertedWaterLevel
        {
            get { return _convertedWaterLevel; }
            set {  OnPropertyChange(ref _convertedWaterLevel, value); }
        }

        private double _temperatureLevel = 0;
        public double TemperatureLevel
        {
            get { return Math.Round(_temperatureLevel,2); }
            set { OnPropertyChange(ref _temperatureLevel, value); ConvertedTemperatureLevel =  (_temperatureLevel + 1) / -100;}
        }

        private double _convertedTemperatureLevel = 0.01;
        public double ConvertedTemperatureLevel
        {
            get { return _convertedTemperatureLevel; }
            set { OnPropertyChange(ref _convertedTemperatureLevel, value); }
        }
        private Visibility _z1WaterVisibility = Visibility.Hidden;
        public Visibility Z1WaterVisibility { get { return _z1WaterVisibility; } set { OnPropertyChange(ref _z1WaterVisibility, value); } }
        private Visibility _z2WaterVisibility = Visibility.Hidden;
        public Visibility Z2WaterVisibility { get { return _z2WaterVisibility; } set { OnPropertyChange(ref _z2WaterVisibility, value); } }
        private Visibility _z3WaterVisibility = Visibility.Hidden;
        public Visibility Z3WaterVisibility { get { return _z3WaterVisibility; } set { OnPropertyChange(ref _z3WaterVisibility, value); } }


        private Brush _x1Background;
        public Brush X1Background { get { return _x1Background; } set { OnPropertyChange(ref _x1Background, value); } }

        private Brush _x2Background;
        public Brush X2Background { get { return _x2Background; } set { OnPropertyChange(ref _x2Background, value); } }

        private Brush _x3Background;
        public Brush X3Background { get { return _x3Background; } set { OnPropertyChange(ref _x3Background, value); } }

        private Brush _tBackground;
        public Brush TBackground { get { return _tBackground; } set { OnPropertyChange(ref _tBackground, value); } }

        private Brush _gBackground;
        public Brush GBackground { get { return _gBackground; } set { OnPropertyChange(ref _gBackground, value); } }

        private Brush _z1Background;
        public Brush Z1Background { get { return _z1Background; } set { OnPropertyChange(ref _z1Background, value); } }

        private Brush _z2Background;
        public Brush Z2Background { get { return _z2Background; } set { OnPropertyChange(ref _z2Background, value); } }
        private Brush _z3Background;
        public Brush Z3Background { get { return _z3Background; } set { OnPropertyChange(ref _z3Background, value); } }

        private Brush _mBackground;
        public Brush MBackground { get { return _mBackground; } set { OnPropertyChange(ref _mBackground, value); } }
        private Brush _wBackground;
        public Brush WBackground { get { return _wBackground; } set { OnPropertyChange(ref _wBackground, value); } }

        private int _z1 = 0, _z2 = 0, _z3 = 0, _g = 0, _m = 0, _x1 = 0, _x2 = 0, _x3 = 0, _t = 0, _w = 0;
        Brush yellowBrush = new SolidColorBrush(Colors.Yellow);
        Brush greenBrush = new SolidColorBrush(Colors.LightGreen);
        Brush whiteBrush = new SolidColorBrush(Colors.White);
        public int Z1 { get { return _z1; } set { OnPropertyChange(ref _z1, value); Z1Background = _z1 == 1 ? greenBrush : whiteBrush; Z1WaterVisibility = _z1 == 1 ? Visibility.Visible : Visibility.Hidden; } }
        public int Z2 { get { return _z2; } set { OnPropertyChange(ref _z2, value); Z2Background = _z2 == 1 ? greenBrush : whiteBrush; Z2WaterVisibility = _z2 == 1 ? Visibility.Visible : Visibility.Hidden; } }
        public int Z3 { get { return _z3; } set { OnPropertyChange(ref _z3, value); Z3Background = _z3 == 1 ? greenBrush : whiteBrush; Z3WaterVisibility = _z3 == 1 ? Visibility.Visible : Visibility.Hidden; } }
        public int X1 { get { return _x1; } set { OnPropertyChange(ref _x1, value); X1Background = _x1 == 1 ? yellowBrush : whiteBrush; } }
        public int X2 { get { return _x2; } set { OnPropertyChange(ref _x2, value); X2Background = _x2 == 1 ? yellowBrush : whiteBrush; } }
        public int X3 { get { return _x3; } set { OnPropertyChange(ref _x3, value); X3Background = _x3 == 1 ? yellowBrush : whiteBrush; } }
        public int T { get { return _t; } set { OnPropertyChange(ref _t, value); TBackground = _t == 1 ? yellowBrush : whiteBrush; } }
        public int G { get { return _g; } set { OnPropertyChange(ref _g, value); GBackground = _g == 1 ? greenBrush : whiteBrush; } }
        public int M { get { return _m; } set { OnPropertyChange(ref _m, value); MBackground = _m == 1 ? greenBrush : whiteBrush; } }
        public int W { get { return _w; } set { OnPropertyChange(ref _w, value); WBackground = _w == 1 ? greenBrush : whiteBrush; } }

        private int _x1Index;
        public int X1Index { get { return _x1Index; } set { OnPropertyChange(ref _x1Index, value); } }
        private int _x2Index;
        public int X2Index { get { return _x2Index; } set { OnPropertyChange(ref _x2Index, value); } }
        private int _x3Index;
        public int X3Index { get { return _x3Index; } set { OnPropertyChange(ref _x3Index, value); } }

        private int _tIndex;
        public int TIndex { get { return _tIndex; } set { OnPropertyChange(ref _tIndex, value); } }

        private int _z1Index;
        public int Z1Index { get { return _z1Index; } set { OnPropertyChange(ref _z1Index, value); } }
        private int _z2Index;
        public int Z2Index { get { return _z2Index; } set { OnPropertyChange(ref _z2Index, value); } }
        private int _z3Index;
        public int Z3Index { get { return _z3Index; } set { OnPropertyChange(ref _z3Index, value); } }
        private int _gIndex;
        public int GIndex { get { return _gIndex; } set { OnPropertyChange(ref _gIndex, value); } }
        private int _mIndex;
        public int MIndex { get { return _mIndex; } set { OnPropertyChange(ref _mIndex, value); } }

        private bool _comboBoxIsEnabled = true;
        public bool ComboBoxIsEnabled { get { return _comboBoxIsEnabled; } set { OnPropertyChange(ref _comboBoxIsEnabled, value); } }


        private int _z1Capacity = 4;
        public int Z1Capacity { get { return _z1Capacity; } set { OnPropertyChange(ref _z1Capacity, value); } }

        private int _z2Capacity = 3;
        public int Z2Capacity { get { return _z2Capacity; } set { OnPropertyChange(ref _z2Capacity, value); } }

        private int _z3Capacity = 5;
        public int Z3Capacity { get { return _z3Capacity; } set { OnPropertyChange(ref _z3Capacity, value); } }

        private int _wCapacity = 6;
        public int WCapacity { get { return _wCapacity; } set { OnPropertyChange(ref _wCapacity, value); } }

        private int _gCapacity = 3;
        public int GCapacity { get { return _gCapacity; } set { OnPropertyChange(ref _gCapacity, value); } }

    }
}
