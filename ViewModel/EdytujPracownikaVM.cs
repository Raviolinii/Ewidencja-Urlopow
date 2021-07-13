using EwidencjaUrlopow.Model;
using EwidencjaUrlopow.Windows;
using Prism.Commands;
using EwidencjaUrlopow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EwidencjaUrlopow.ViewModel
{
    class EdytujPracownikaVM : BaseVM
    {
        EdytujPracownika _view;
        Pracownik _toEdit;
        public Pracownik toEdit
        {
            get => _toEdit;
            set
            {
                SetProperty(ref _toEdit, value);
                FillData();
            }
        }

        string _imie;
        public string imie
        {
            get => _imie;
            set
            {
                SetProperty(ref _imie, value);
                toEdit.Imie = value;
            }
        }

        string _nazwisko;
        public string nazwisko
        {
            get => _nazwisko;
            set
            {
                SetProperty(ref _nazwisko, value);
                toEdit.Nazwisko = value;
            }
        }
        string _stanowisko;
        public string stanowisko
        {
            get => _stanowisko;
            set
            {
                SetProperty(ref _stanowisko, value);
                toEdit.StanowiskoPracy = value;
            }
        }
        int _lataPracy;
        public int lataPracy
        {
            get => _lataPracy;
            set
            {
                SetProperty(ref _lataPracy, value);
                toEdit.LataPracy = value;
            }
        }
        int _dostepnyUrlop;
        public int dostepnyUrlop
        {
            get => _dostepnyUrlop;
            set
            {
                SetProperty(ref _dostepnyUrlop, value);
                toEdit.DostepnyUrlop = value;
            }
        }


        public ICommand CancelEditWorkerCommand { get; }
        public ICommand DeleteWorkerCommand { get; }
        public ICommand SaveWorkerCommand { get; }

        public EdytujPracownikaVM(EdytujPracownika view, Pracownik toEdit)
        {
            _view = view;

            CancelEditWorkerCommand = new DelegateCommand(CancelEditWorker);
            DeleteWorkerCommand = new DelegateCommand(DeleteWorker);
            SaveWorkerCommand = new DelegateCommand(SaveWorker);

            this.toEdit = toEdit;
        }

        public void CancelEditWorker() => _view.Close();
        public void DeleteWorker()
        {
            // delete from model
            EwidencjaUrlopowContext ewidencjaUrlopowContext = new EwidencjaUrlopowContext();
            ewidencjaUrlopowContext.DeleteWorker(toEdit);
            _view.Close();
        }

        public void SaveWorker()
        {
            EwidencjaUrlopowContext ewidencjaUrlopowContext = new EwidencjaUrlopowContext();
            ewidencjaUrlopowContext.EditWorker(toEdit);
            _view.Close();
        }

        void FillData()
        {
            imie = toEdit.Imie;
            nazwisko = toEdit.Nazwisko;
            stanowisko = toEdit.StanowiskoPracy;
            lataPracy = toEdit.LataPracy;
            dostepnyUrlop = (int)toEdit.DostepnyUrlop;
        }

    }
}
