using LabControllerSim.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LabControllerSim.Modules.BoardSimulator.Models
{
    public class DiodeModel : ObservableObject
    {
        private int _l1State = 0;
        private int _l2State = 0;
        private int _l3State = 0;
        private int _l4State = 0;
        private int _l5State = 0;
        private int _l6State = 0;
        private int _l7State = 0;
        private int _l8State = 0;
        Brush redBrush = new SolidColorBrush(Colors.Red);
        Brush greenBrush = new SolidColorBrush(Colors.LawnGreen);
        private Brush _l1Fill = new SolidColorBrush(Colors.Red);
        private Brush _l2Fill = new SolidColorBrush(Colors.Red);
        private Brush _l3Fill = new SolidColorBrush(Colors.Red);
        private Brush _l4Fill = new SolidColorBrush(Colors.Red);
        private Brush _l5Fill = new SolidColorBrush(Colors.Red);
        private Brush _l6Fill = new SolidColorBrush(Colors.Red);
        private Brush _l7Fill = new SolidColorBrush(Colors.Red);
        private Brush _l8Fill = new SolidColorBrush(Colors.Red);

        public int L1State { get { return _l1State; } set { OnPropertyChange(ref _l1State, value); L1Fill = _l1State == 1 ? greenBrush : redBrush; } }
        public int L2State { get { return _l2State; } set { OnPropertyChange(ref _l2State, value); L2Fill = _l2State == 1 ? greenBrush : redBrush; } }
        public int L3State { get { return _l3State; } set { OnPropertyChange(ref _l3State, value); L3Fill = _l3State == 1 ? greenBrush : redBrush; } }
        public int L4State { get { return _l4State; } set { OnPropertyChange(ref _l4State, value); L4Fill = _l4State == 1 ? greenBrush : redBrush; } }
        public int L5State { get { return _l5State; } set { OnPropertyChange(ref _l5State, value); L5Fill = _l5State == 1 ? greenBrush : redBrush; } }
        public int L6State { get { return _l6State; } set { OnPropertyChange(ref _l2State, value); L6Fill = _l6State == 1 ? greenBrush : redBrush; } }
        public int L7State { get { return _l7State; } set { OnPropertyChange(ref _l3State, value); L7Fill = _l7State == 1 ? greenBrush : redBrush; } }
        public int L8State { get { return _l8State; } set { OnPropertyChange(ref _l4State, value); L8Fill = _l8State == 1 ? greenBrush : redBrush; } }

        public Brush L1Fill { get { return _l1Fill; } set { OnPropertyChange(ref _l1Fill, value); } }
        public Brush L2Fill { get { return _l2Fill; } set { OnPropertyChange(ref _l2Fill, value); } }
        public Brush L3Fill { get { return _l3Fill; } set { OnPropertyChange(ref _l3Fill, value); } }
        public Brush L4Fill { get { return _l4Fill; } set { OnPropertyChange(ref _l4Fill, value); } }
        public Brush L5Fill { get { return _l5Fill; } set { OnPropertyChange(ref _l5Fill, value); } }
        public Brush L6Fill { get { return _l6Fill; } set { OnPropertyChange(ref _l6Fill, value); } }
        public Brush L7Fill { get { return _l7Fill; } set { OnPropertyChange(ref _l7Fill, value); } }
        public Brush L8Fill { get { return _l8Fill; } set { OnPropertyChange(ref _l8Fill, value); } }

    }
}
