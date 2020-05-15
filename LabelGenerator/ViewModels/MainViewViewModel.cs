using System.Diagnostics;
using System.Windows.Input;

namespace LabelGenerator.ViewModels {
    using LabelGenerator.Models;
    using LabelGenerator.Utils;

    public class MainViewViewModel : BaseViewModel {
        private static MainViewModel m_Model;

        public int Year {
            get { return m_Model.Year; }
            set {
                if (m_Model.Year != value) {
                    m_Model.Year = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SerialNumberOutput));
                }
            }
        }

        public int Week {
            get { return m_Model.Week; }
            set {
                if (m_Model.Week != value) {
                    m_Model.Week = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SerialNumberOutput));
                }
            }
        }

        public int Number {
            get { return m_Model.Number; }
            set {
                if (m_Model.Number != value) {
                    m_Model.Number = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SerialNumberOutput));
                }
            }
        }

        public string SerialNumberOutput { get { return "Serial Number: " + m_Model.SerialNumber; } }

        public string IMEINumber {
            get { return m_Model.IMEINumber; }
            set {
                if(m_Model.IMEINumber != value) {
                    m_Model.IMEINumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddYearCommand { get; set; }
        public ICommand SubYearCommand { get; set; }

        public ICommand AddWeekCommand { get; set; }
        public ICommand SubWeekCommand { get; set; }

        public ICommand AddNumberCommand { get; set; }
        public ICommand SubNumberCommand { get; set; }

        public ICommand GenerateCommand { get; set; }

        /// <summary>
        /// Default constructor, creates an Instance of the MainViewViewModel class
        /// </summary>
        public MainViewViewModel() {
            JsonUtil.LoadJson<MainViewModel>("SaveData.json", out m_Model);
            if (m_Model == null) {
                m_Model = new MainViewModel();
                JsonUtil.SaveJson<MainViewModel>("SaveData.json", m_Model);
#if DEBUG
                Trace.WriteLine("Created new SaveData.json file", "Constructor");
#endif
            }

            // FileUtil.SaveFile("test.txt", "Hello, world");

            AddYearCommand = new RelayCommand(() => { Year++; });
            SubYearCommand = new RelayCommand(() => { Year--; });

            AddWeekCommand = new RelayCommand(() => { Week++; });
            SubWeekCommand = new RelayCommand(() => { Week--; });

            AddNumberCommand = new RelayCommand(() => { Number++; });
            SubNumberCommand = new RelayCommand(() => { Number--; });

            GenerateCommand = new RelayCommand(GenerateOutput);
        }

        public void Closing() {
#if DEBUG
            Trace.WriteLine("Closing, saving .json file...");
#endif
            JsonUtil.SaveJson<MainViewModel>("SaveData.json", m_Model);
#if DEBUG
            Trace.WriteLine("Closing, successfully saved .json file!");
#endif
        }

        /// <summary>
        /// The method that generate the output label
        /// </summary>
        private void GenerateOutput() {
            JsonUtil.SaveJson<MainViewModel>("SaveData.json", m_Model);
            Number++;
            // Trace.WriteLine("Generating Output..."); 
        }
    }
}
