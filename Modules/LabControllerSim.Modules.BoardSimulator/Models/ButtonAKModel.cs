using LabControllerSim.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LabControllerSim.Modules.BoardSimulator.Models
{
    public class ButtonAKModel : ObservableObject
    {
        private int _aK1State;
        private int _aK2State;
        private int _aK3State;
        private int _aK4State;
        private int _aK5State;
        private int _aK6State;
        private int _aK7State;
        private int _aK8State;

        private Brush _aK1Background = new SolidColorBrush(Colors.LightGray);
        private Brush _aK2Background = new SolidColorBrush(Colors.LightGray);
        private Brush _aK3Background = new SolidColorBrush(Colors.LightGray);
        private Brush _aK4Background = new SolidColorBrush(Colors.LightGray);
        private Brush _aK5Background = new SolidColorBrush(Colors.LightGray);
        private Brush _aK6Background = new SolidColorBrush(Colors.LightGray);
        private Brush _aK7Background = new SolidColorBrush(Colors.LightGray);
        private Brush _aK8Background = new SolidColorBrush(Colors.LightGray);

        Brush grayBrush = new SolidColorBrush(Colors.Gray);
        Brush lightGrayBrush = new SolidColorBrush(Colors.LightGray);

        public int AK1State { get { return _aK1State; } set { OnPropertyChange(ref _aK1State, value); AK1Background = _aK1State == 1 ? grayBrush : lightGrayBrush; } }
        public int AK2State { get { return _aK2State; } set { OnPropertyChange(ref _aK2State, value); AK2Background = _aK2State == 1 ? grayBrush : lightGrayBrush; } }
        public int AK3State { get { return _aK3State; } set { OnPropertyChange(ref _aK3State, value); AK3Background = _aK3State == 1 ? grayBrush : lightGrayBrush; } }
        public int AK4State { get { return _aK4State; } set { OnPropertyChange(ref _aK4State, value); AK4Background = _aK4State == 1 ? grayBrush : lightGrayBrush; } }
        public int AK5State { get { return _aK5State; } set { OnPropertyChange(ref _aK5State, value); AK5Background = _aK5State == 1 ? grayBrush : lightGrayBrush; } }
        public int AK6State { get { return _aK6State; } set { OnPropertyChange(ref _aK6State, value); AK6Background = _aK6State == 1 ? grayBrush : lightGrayBrush; } }
        public int AK7State { get { return _aK7State; } set { OnPropertyChange(ref _aK7State, value); AK7Background = _aK7State == 1 ? grayBrush : lightGrayBrush; } }
        public int AK8State { get { return _aK8State; } set { OnPropertyChange(ref _aK8State, value); AK8Background = _aK8State == 1 ? grayBrush : lightGrayBrush; } }

        public Brush AK1Background { get { return _aK1Background; } set { OnPropertyChange(ref _aK1Background, value); } }
        public Brush AK2Background { get { return _aK2Background; } set { OnPropertyChange(ref _aK2Background, value); } }
        public Brush AK3Background { get { return _aK3Background; } set { OnPropertyChange(ref _aK3Background, value); } }
        public Brush AK4Background { get { return _aK4Background; } set { OnPropertyChange(ref _aK4Background, value); } }
        public Brush AK5Background { get { return _aK5Background; } set { OnPropertyChange(ref _aK5Background, value); } }
        public Brush AK6Background { get { return _aK6Background; } set { OnPropertyChange(ref _aK6Background, value); } }
        public Brush AK7Background { get { return _aK7Background; } set { OnPropertyChange(ref _aK7Background, value); } }
        public Brush AK8Background { get { return _aK8Background; } set { OnPropertyChange(ref _aK8Background, value); } }

    }

}
