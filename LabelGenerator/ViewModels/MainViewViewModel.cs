using System.Windows.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LabelGenerator.ViewModels {
    using LabelGenerator.Data;
    using LabelGenerator.Utils;
    using LabelGenerator.Models;

    public class MainViewViewModel : BaseViewModel {
        private static MainViewModel m_Model;

        /// <summary>
        /// Integer representation of Year.
        /// </summary>
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

        /// <summary>
        /// Integer representation of Week.
        /// </summary>
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

        /// <summary>
        /// Integer representation of Number.
        /// </summary>
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

        /// <summary>
        /// The output value of Serial Number, represented in stirng.
        /// </summary>
        public string SerialNumberOutput { get { return "Serial Number: " + m_Model.SerialNumber; } }

        /// <summary>
        /// String representation of IMEI number
        /// </summary>
        public string IMEINumber {
            get { return m_Model.IMEINumber; }
            set {
                if(m_Model.IMEINumber != value) {
                    m_Model.IMEINumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> ExcelIMEINumbers {
            get { return m_Model.IMEINumbers; }
            set {
                if (m_Model.IMEINumbers != value) {
                    m_Model.IMEINumbers = value;
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

        public ICommand LoadExcelFileCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public ICommand GenerateCommand { get; set; }

        /// <summary>
        /// Default constructor, creates an Instance of the MainViewViewModel class
        /// </summary>
        public MainViewViewModel() {
            JsonUtil.LoadJson<MainViewModel>(AppData.Instance.SaveDataFileName, out m_Model);
            if (m_Model == null) {
                m_Model = new MainViewModel();
                JsonUtil.SaveJson<MainViewModel>(AppData.Instance.SaveDataFileName, m_Model);
            }
            AppData.Instance.Template = FileUtil.ReadFile(AppData.Instance.TemplateFileName);

            ExcelIMEINumbers = new ObservableCollection<string>();

            AddYearCommand = new RelayCommand(() => { Year++; });
            SubYearCommand = new RelayCommand(() => { Year--; });

            AddWeekCommand = new RelayCommand(() => { Week++; });
            SubWeekCommand = new RelayCommand(() => { Week--; });

            AddNumberCommand = new RelayCommand(() => { Number++; });
            SubNumberCommand = new RelayCommand(() => { Number--; });

            LoadExcelFileCommand = new RelayCommand(() => {
                FileUtil.OpenDialog(out string filepath, "Excel Workbook | *.xlsx");
                ObservableCollection<string> imeiNumbers = OfficeUtil.OpenExcelFile(filepath);
                ExcelIMEINumbers = imeiNumbers;
            });

            ClearCommand = new RelayCommand(() => {
                ExcelIMEINumbers.Clear();
            });

            GenerateCommand = new RelayCommand(GenerateOutput);
        }

        public void Closing() {
            JsonUtil.SaveJson<MainViewModel>(AppData.Instance.SaveDataFileName, m_Model);
        }

        /// <summary>
        /// The method that generate the output label
        /// </summary>
        private void GenerateOutput() {
            string outputData = Formatter.GenerateStringOutput(m_Model.SerialNumber, m_Model.IMEINumber);
            FileUtil.WriteFile(m_Model.SerialNumber + ".txt", outputData);

            JsonUtil.SaveJson<MainViewModel>(AppData.Instance.SaveDataFileName, m_Model);

            Number++;
        }
    }
}
