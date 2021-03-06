﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.ComponentModel;

namespace MVVMVoorbeeld.ViewModel
{
    public class TekstMetOpmaakViewModel : ViewModelBase
    {
        private Model.TekstMetOpmaak opgemaakteTekst;

        public TekstMetOpmaakViewModel(Model.TekstMetOpmaak deTekst)
        {
            this.opgemaakteTekst = deTekst;
        }

        public string Inhoud
        {
            get
            {
                return opgemaakteTekst.Inhoud;
            }
            set
            {
                opgemaakteTekst.Inhoud = value;
                RaisePropertyChanged("Inhoud");
            }
        }

        public Boolean Vet
        {
            get
            {
                return opgemaakteTekst.Vet;
            }
            set
            {
                opgemaakteTekst.Vet = value;
                RaisePropertyChanged("Vet");
            }
        }

        public Boolean Schuin
        {
            get
            {
                return opgemaakteTekst.Schuin;
            }
            set
            {
                opgemaakteTekst.Schuin = value;
                RaisePropertyChanged("Schuin");
            }
        }

        public RelayCommand NieuwCommand
        {
            get
            {
                return new RelayCommand(NieuwTextBox);
            }
        }

        private void NieuwTextBox()
        {
            Inhoud = string.Empty;
            Vet = false;
            Schuin = false;
        }

        public RelayCommand OpslaanCommand
        {
            get
            {
                return new RelayCommand(OpslaanBestand);
            }
        }

        private void OpslaanBestand()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "tekstbox";
                dlg.DefaultExt = ".box";
                dlg.Filter = "Textbox Documents |*.box*";

                if(dlg.ShowDialog() == true)
                {
                    using (StreamWriter bestand = new StreamWriter(dlg.FileName))
                    {
                        bestand.WriteLine(Inhoud);
                        bestand.WriteLine(Vet.ToString());
                        bestand.WriteLine(Schuin.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Opslaan mislukt : " + ex.Message, "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private RelayCommand OpenenCommand
        {
            get
            {
                return new RelayCommand(OpenenBestand);
            }
        }

        private void OpenenBestand()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "";
                dlg.DefaultExt = ".box";
                dlg.Filter = "Texbox Documents |*.box*";

                if(dlg.ShowDialog() == true)
                {
                    using(StreamReader bestand = new StreamReader(dlg.FileName))
                    {
                        Inhoud = bestand.ReadLine();
                        Vet = Convert.ToBoolean(bestand.ReadLine());
                        Schuin = Convert.ToBoolean(bestand.ReadLine());
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Openen bestand mislukt: " + ex.Message, "Openen error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private RelayCommand AfsluitenCommand
        {
            get
            {
                return new RelayCommand(AfsluitenApp);
            }
        }

        private void AfsluitenApp()
        {
            Application.Current.MainWindow.Close();
        }

        public RelayCommand<CancelEventArgs> ClosingCommand
        {
            get
            {
                return new RelayCommand<CancelEventArgs>(onWindowClosing);
            }
        }

        public void onWindowClosing(CancelEventArgs e)
        {
            if(MessageBox.Show("Wilt u het programma afsluiten?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
