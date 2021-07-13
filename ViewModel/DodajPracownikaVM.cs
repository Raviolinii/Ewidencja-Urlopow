using EwidencjaUrlopow.Model;
using EwidencjaUrlopow.Windows;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EwidencjaUrlopow.ViewModel
{
    class DodajPracownikaVM : BaseVM
    {
        DodajPracownika _view;

        string _imie;
        public string imie
        {
            get => _imie;
            set => SetProperty(ref _imie, value);
        }

        string _nazwisko;
        public string nazwisko
        {
            get => _nazwisko;
            set => SetProperty(ref _nazwisko, value);
        }
        string _stanowisko;
        public string stanowisko
        {
            get => _stanowisko;
            set => SetProperty(ref _stanowisko, value);
        }
        int _lataPracy;
        public int lataPracy
        {
            get => _lataPracy;
            set => SetProperty(ref _lataPracy, value);
        }
        int _dostepnyUrlop;
        public int dostepnyUrlop
        {
            get => _dostepnyUrlop;
            set => SetProperty(ref _dostepnyUrlop, value);
        }

        public ICommand CancelWorkerAddingCommand { get; }
        public ICommand AddWorkerCommand { get; }

        public DodajPracownikaVM(DodajPracownika view)
        {
            _view = view;
            CancelWorkerAddingCommand = new DelegateCommand(CancelWorkerAdding);
            AddWorkerCommand = new DelegateCommand(AddWorker);
        }

        void CancelWorkerAdding() => _view.Close();

        async void AddWorker()
        {
            if (FirstNameValidation() && LastNameValidation() && JobValidation() && YearsValidation() && LeaveDaysValidation())
                await InsertSQL();

            _view.Close();
        }

        private async Task InsertSQL()
        {
            var context = new EwidencjaUrlopowContext();
            Pracownik pracownik = new Pracownik();
            pracownik.Imie = imie;
            pracownik.Nazwisko = nazwisko;
            pracownik.StanowiskoPracy = stanowisko;
            pracownik.LataPracy = lataPracy;
            pracownik.DostepnyUrlop = dostepnyUrlop;
            await context.AddAsync(pracownik);
            await context.SaveChangesAsync();

        }

        bool FirstNameValidation()
        {
            if (imie is not null)
            {
                if (imie.Length >= 3 && !imie.Contains('@') && !imie.Contains('='))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        bool LastNameValidation()
        {
            if (nazwisko is not null)
            {
                if (nazwisko.Length >= 3 && !nazwisko.Contains('@') && !nazwisko.Contains('='))
                    return true;
                else
                    return false;
            }
            else return false;
        }

        bool JobValidation()
        {
            if (stanowisko is not null)
            {
                if (stanowisko.Length >= 1 && !stanowisko.Contains('@') && !stanowisko.Contains('='))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        bool YearsValidation()
        {
            return true;
        }
        bool LeaveDaysValidation()
        {
            return true;
        }
    }
}
