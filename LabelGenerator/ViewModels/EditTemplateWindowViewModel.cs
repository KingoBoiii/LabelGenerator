﻿using System;
using System.Windows;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.Win32;

namespace LabelGenerator.ViewModels {
    using LabelGenerator.Data;
    using LabelGenerator.Utils;
    using LabelGenerator.Models;

    public class EditTemplateWindowViewModel : BaseViewModel {
        private readonly Window m_Window;
        private readonly EditTemplateWindowModel m_Model;

        public string TemplateText {
            get { return m_Model.TemplateText; }
            set {
                if(m_Model.TemplateText != value) {
                    m_Model.TemplateText = value;
                    AppData.Instance.Template = TemplateText;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand NewCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        /// <summary>
        /// Default constructor, creates an Instance of the EditTemplateWindowViewModel class
        /// </summary>
        /// <param name="window"></param>
        public EditTemplateWindowViewModel(Window window) {
            this.m_Window = window;
            this.m_Model = new EditTemplateWindowModel();

            this.m_Window.Loaded += (sender, e) => {
                this.TemplateText = AppData.Instance.Template;
            };

            NewCommand = new RelayCommand(() => {
                TemplateText = "";
            });
            OpenCommand = new RelayCommand(() => {
                string data = string.Empty;
                FileUtil.OpenAndReadFileDialog(out data);
                TemplateText = data;
            });
            SaveCommand = new RelayCommand(() => {
                FileUtil.WriteFile("_template_.txt", TemplateText);
            });
            ExitCommand = new RelayCommand(() => { this.m_Window.Close(); });
        }
    }
}
