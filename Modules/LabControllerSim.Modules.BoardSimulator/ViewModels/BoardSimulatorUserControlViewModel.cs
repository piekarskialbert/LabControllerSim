using LabControllerSim.Core;
using LabControllerSim.Core.Events;
using LabControllerSim.Modules.BoardSimulator.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LabControllerSim.Modules.BoardSimulator.ViewModels
{
    public class BoardSimulatorUserControlViewModel : BindableBase
    {    
        IEventAggregator _ea;
        public SimulatorViewModel Simulator { get; set; }
        public DelegateCommand<object> MouseLeftButtonDownCommand { get; private set; }
        public DelegateCommand<object> MouseRightButtonDownCommand { get; private set; }
        public FileViewModel File { get; private set; }
        public DelegateCommand<object> MouseLeftButtonUpCommand { get; private set; }
        public DiodeModel Diode { get; set; }
        public ButtonAKModel ButtonAK { get; set; }
        public ControlButton StartButton { get; set; }
        public ControlButton StopButton { get; set; }
        private string inputToProgram = "00000000";
        string inputCharToProgram = "";
        string inputCharBuffor = "";
        public ICommand StartButtonCommand { get; }
        public ICommand StopButtonCommand { get; }
        private BackgroundWorker Processer = new BackgroundWorker();
        private int _cykl = 100;
        public HelpViewModel Help { get; }
        public int Cykl
        {
            get { return _cykl; }
            set { SetProperty(ref _cykl, value); }
        }
        Process process;
        public static BoardSimulatorUserControlViewModel Current { get; private set; }
        public BoardSimulatorUserControlViewModel(IEventAggregator ea)
        {
            _ea = ea;
            Simulator = new SimulatorViewModel(ea);
            Help = new HelpViewModel();
            MouseLeftButtonDownCommand = new DelegateCommand<object>(MouseLeftButtonDown);
            MouseLeftButtonUpCommand = new DelegateCommand<object>(MouseLeftButtonUp);
            MouseRightButtonDownCommand = new DelegateCommand<object>(MouseRightButtonDown);
            File = new FileViewModel();
            StartButton = new ControlButton();
            StopButton = new ControlButton();
            StartButton.IsEnabled = true;
            StartButtonCommand = new RelayCommand(StartButton_Click, () => StartButton.IsEnabled);
            StopButtonCommand = new RelayCommand(StopButton_Click, () => StopButton.IsEnabled);
            Diode = new DiodeModel();
            ButtonAK = new ButtonAKModel();
            ea.GetEvent<CloseSimulatorWindowEvent>().Subscribe(DataWindow_Closing);
            ea.GetEvent<KeyUpWindowEvent>().Subscribe(Window_KeyUp);
            ea.GetEvent<KeyDownWindowEvent>().Subscribe(Window_KeyDown);
            ea.GetEvent<SendInputFromObjectToProgramEvent>().Subscribe((e) => inputToProgram = e);
            ea.GetEvent<SendCharFromConsoleToProgramEvent>().Subscribe((e) => { inputCharBuffor += e;; });
            Current = this;
        }


        private void MouseRightButtonDown(object obj)
        {
            if (obj.ToString() == "aK1") ButtonAK.AK1State = ButtonAK.AK1State == 0 ? 1 : 0;
            if (obj.ToString() == "aK2") ButtonAK.AK2State = ButtonAK.AK2State == 0 ? 1 : 0;
            if (obj.ToString() == "aK3") ButtonAK.AK3State = ButtonAK.AK3State == 0 ? 1 : 0;
            if (obj.ToString() == "aK4") ButtonAK.AK4State = ButtonAK.AK4State == 0 ? 1 : 0;
            if (obj.ToString() == "aK5") ButtonAK.AK5State = ButtonAK.AK5State == 0 ? 1 : 0;
            if (obj.ToString() == "aK6") ButtonAK.AK6State = ButtonAK.AK6State == 0 ? 1 : 0;
            if (obj.ToString() == "aK7") ButtonAK.AK7State = ButtonAK.AK7State == 0 ? 1 : 0;
            if (obj.ToString() == "aK8") ButtonAK.AK8State = ButtonAK.AK8State == 0 ? 1 : 0;
        }

        private void MouseLeftButtonUp(object obj)
        {
            if (obj.ToString() == "aK1") ButtonAK.AK1State = 0;
            if (obj.ToString() == "aK2") ButtonAK.AK2State = 0;
            if (obj.ToString() == "aK3") ButtonAK.AK3State = 0;
            if (obj.ToString() == "aK4") ButtonAK.AK4State = 0;
            if (obj.ToString() == "aK5") ButtonAK.AK5State = 0;
            if (obj.ToString() == "aK6") ButtonAK.AK6State = 0;
            if (obj.ToString() == "aK7") ButtonAK.AK7State = 0;
            if (obj.ToString() == "aK8") ButtonAK.AK8State = 0;
        }

        private void MouseLeftButtonDown(object obj)
        {
            if (obj.ToString() == "aK1") ButtonAK.AK1State = 1;
            if (obj.ToString() == "aK2") ButtonAK.AK2State = 1;
            if (obj.ToString() == "aK3") ButtonAK.AK3State = 1;
            if (obj.ToString() == "aK4") ButtonAK.AK4State = 1;
            if (obj.ToString() == "aK5") ButtonAK.AK5State = 1;
            if (obj.ToString() == "aK6") ButtonAK.AK6State = 1;
            if (obj.ToString() == "aK7") ButtonAK.AK7State = 1;
            if (obj.ToString() == "aK8") ButtonAK.AK8State = 1;
        }

        private void Window_KeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Q) { ButtonAK.AK1State = 1; }
            if (e.Key == Key.W) { ButtonAK.AK2State = 1; }
            if (e.Key == Key.E) { ButtonAK.AK3State = 1; }
            if (e.Key == Key.R) { ButtonAK.AK4State = 1; }
            if (e.Key == Key.T) { ButtonAK.AK5State = 1; }
            if (e.Key == Key.Y) { ButtonAK.AK6State = 1; }
            if (e.Key == Key.U) { ButtonAK.AK7State = 1; }
            if (e.Key == Key.I) { ButtonAK.AK8State = 1; }
        }

        private void Window_KeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Q) { ButtonAK.AK1State = 0; }
            if (e.Key == Key.W) { ButtonAK.AK2State = 0; }
            if (e.Key == Key.E) { ButtonAK.AK3State = 0; }
            if (e.Key == Key.R) { ButtonAK.AK4State = 0; }
            if (e.Key == Key.T) { ButtonAK.AK5State = 0; }
            if (e.Key == Key.Y) { ButtonAK.AK6State = 0; }
            if (e.Key == Key.U) { ButtonAK.AK7State = 0; }
            if (e.Key == Key.I) { ButtonAK.AK8State = 0; }

        }


        private void StartButton_Click()
        {
            if (!string.IsNullOrEmpty(File.Path))
            {
                StopButton.IsEnabled = true;
                StartButton.IsEnabled = false;
                File.SelectButton.IsEnabled = false;
                Processer.DoWork += Processer_DoWork;
                Processer.WorkerSupportsCancellation = true;
                Processer.RunWorkerAsync();
            }
            else
            {
                string messageBoxText = "Przez uruchomieniem wybierz program.";
                string caption = "";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }

        }

        void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!string.IsNullOrEmpty(outLine.Data))
            {
                if (outLine.Data.Substring(0, 3) == "COM")
                {
                    string outputChar = outLine.Data.Substring(3,1);
                    _ea.GetEvent<SendCharFromProgramToConsoleEvent>().Publish(outputChar);
                }
                else
                {
                    string output = outLine.Data;
                    if (Diode.L1State != Int32.Parse(output.Substring(0, 1))) Diode.L1State = Int32.Parse(output.Substring(0, 1));
                    if (Diode.L2State != Int32.Parse(output.Substring(1, 1))) Diode.L2State = Int32.Parse(output.Substring(1, 1));
                    if (Diode.L3State != Int32.Parse(output.Substring(2, 1))) Diode.L3State = Int32.Parse(output.Substring(2, 1));
                    if (Diode.L4State != Int32.Parse(output.Substring(3, 1))) Diode.L4State = Int32.Parse(output.Substring(3, 1));
                    if (Diode.L5State != Int32.Parse(output.Substring(4, 1))) Diode.L5State = Int32.Parse(output.Substring(4, 1));
                    if (Diode.L6State != Int32.Parse(output.Substring(5, 1))) Diode.L6State = Int32.Parse(output.Substring(5, 1));
                    if (Diode.L7State != Int32.Parse(output.Substring(6, 1))) Diode.L7State = Int32.Parse(output.Substring(6, 1));
                    if (Diode.L8State != Int32.Parse(output.Substring(7, 1))) Diode.L8State = Int32.Parse(output.Substring(7, 1));

                    _ea.GetEvent<SendOutputToObjectSimulatorEvent>().Publish(output.Substring(8));
                }
            }
        }

        private void DataWindow_Closing(object str)
        {
            if (process != null)
                if (!process.HasExited)
                {
                    process.Kill();
                    process.Refresh();
                    Processer.CancelAsync();

                }
            Simulator.CloseSimulatorWindows();
        }



        private void StopButton_Click()
        {
            if (process != null)
                if (!process.HasExited)
                {
                    StopButton.IsEnabled = false;
                    StartButton.IsEnabled = true;
                    File.SelectButton.IsEnabled = true;
                    process.Kill();
                    process.Refresh();
                    Processer.CancelAsync();
                }
        }

        private void Processer_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    process = new Process();
                    process.StartInfo.FileName = File.Path;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                    process.Start();
                    process.BeginOutputReadLine();
                    StreamWriter ProcessInput = process.StandardInput;
                    long lastMillis = Millis();
                    while (!process.HasExited)
                    {
                        if (Millis()- lastMillis >= _cykl)
                        {
                            lastMillis = Millis();
                            ProcessInput.WriteLine($"{ButtonAK.AK1State}{ButtonAK.AK2State}{ButtonAK.AK3State}{ButtonAK.AK4State}{ButtonAK.AK5State}{ButtonAK.AK6State}{ButtonAK.AK7State}{ButtonAK.AK8State}{inputToProgram}");
                            if (!string.IsNullOrEmpty(inputCharBuffor))
                            {
                                inputCharToProgram = inputCharBuffor.Substring(0, 1);
                                inputCharBuffor = inputCharBuffor.Substring(1);
                            }
                            if (!string.IsNullOrEmpty(inputCharToProgram))
                            {
                                ProcessInput.WriteLine(inputCharToProgram.Substring(0, 1));
                                Console.WriteLine(inputCharToProgram.ToCharArray());
                                inputCharToProgram = "";
                            }
                            else ProcessInput.WriteLine("\0");
                        }

                    }

                    process.WaitForExit();
                }
            }

        }


        long Millis()
        {
            return (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
        }
    }
}