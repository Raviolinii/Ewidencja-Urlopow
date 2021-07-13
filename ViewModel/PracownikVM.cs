using EwidencjaUrlopow.Commands;
using EwidencjaUrlopow.Model;
using EwidencjaUrlopow.Windows;
using Microsoft.Data.SqlClient;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EwidencjaUrlopow.ViewModel
{
    class PracownikVM : BaseVM
    {
        DodajPracownika dodajPracownika;
        EdytujPracownika edytujPracownika;
        bool isWindowOpened = false;

        
        Pracownik _selectedItem;
        public Pracownik selectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        int? _szukaneId = null;
        public int? szukaneId
        {
            get => _szukaneId;
            set
            {
                if (value != szukaneId)
                    SetProperty(ref _szukaneId, value);
            }
        }

        string _szukaneImie;
        public string szukaneImie
        {
            get => _szukaneImie;
            set
            {
                if (value != szukaneImie)
                    SetProperty(ref _szukaneImie, value);
            }
        }

        string _szukaneNazwisko;
        public string szukaneNazwisko
        {
            get => _szukaneNazwisko;
            set
            {
                if (value != szukaneNazwisko)
                    SetProperty(ref _szukaneNazwisko, value);
            }
        }

        string _szukaneStanowisko;
        public string szukaneStanowisko
        {
            get => _szukaneStanowisko;
            set
            {
                if (value != szukaneStanowisko)
                    SetProperty(ref _szukaneStanowisko, value);
            }
        }

        int? _szukaneLataPracy;
        public int? szukaneLataPracy
        {
            get => _szukaneLataPracy;
            set
            {
                if (value != szukaneLataPracy)
                    SetProperty(ref _szukaneLataPracy, value);
            }
        }

        int? _szukaneDostepnyUrlop;
        public int? szukaneDostepnyUrlop
        {
            get => _szukaneDostepnyUrlop;
            set
            {
                if (value != szukaneDostepnyUrlop)
                    SetProperty(ref _szukaneDostepnyUrlop, value);

            }
        }
        public ICommand AddWorkerCommand { get; }
        public ICommand EditWorkerCommand { get; }
        public ICommand SearchCommand { get; }
        ObservableCollection<Pracownik> _wszyscyPracownicy = new ObservableCollection<Pracownik>();
        public ObservableCollection<Pracownik> wszyscyPracownicy
        {
            get => _wszyscyPracownicy;
            set => SetProperty(ref _wszyscyPracownicy, value);
        }

        ObservableCollection<Pracownik> _szukaniPracownicy = new ObservableCollection<Pracownik>();
        public ObservableCollection<Pracownik> szukaniPracownicy
        {
            get => _szukaniPracownicy;
            set => SetProperty(ref _szukaniPracownicy, value);
        }
        public PracownikVM()
        {
            AddWorkerCommand = new DelegateCommand(OpenAddWorker);
            EditWorkerCommand = new DelegateCommand(OpenEditWorker);
            SearchCommand = new DelegateCommand(UpdateSearch);
            PopulateWorkers();
        }

        private void DodajPracownika_Closed(object sender, EventArgs e) =>isWindowOpened = false;

        private void EdytujPracownika_Closed(object sender, EventArgs e) => isWindowOpened = false;

        public async void OpenAddWorker()
        {
            if (!isWindowOpened)
                await AddWorker();
        }
        async Task AddWorker()
        {
            isWindowOpened = true;
            dodajPracownika = new DodajPracownika();
            dodajPracownika.Closed += DodajPracownika_Closed;
            dodajPracownika.Show();
            await Task.Yield();
        }

        public async void OpenEditWorker()
        {
            if (!isWindowOpened)
                await EditWorker();
        }

        public async Task EditWorker()
        {
            isWindowOpened = true;
            edytujPracownika = new EdytujPracownika(selectedItem);
            edytujPracownika.Closed += EdytujPracownika_Closed;
            edytujPracownika.Show();
            await Task.Yield();
        }

        public void PopulateWorkers()
        {
            var ewidencjaUrlopowContext = new EwidencjaUrlopowContext();
            var workersList = ewidencjaUrlopowContext.Pracowniks;
            foreach (var worker in workersList)
            {
                if (!wszyscyPracownicy.Contains(worker))
                    wszyscyPracownicy.Add(worker);
            }
            UpdateSearch();
        }
      
        public void UpdateSearch()
        {
            szukaniPracownicy = new ObservableCollection<Pracownik>(wszyscyPracownicy);

            if (szukaneId != null)
                szukaniPracownicy = new ObservableCollection<Pracownik>(szukaniPracownicy.Where(x => x.IdPracownika == szukaneId));
            if (szukaneImie != null)
                szukaniPracownicy = new ObservableCollection<Pracownik>(szukaniPracownicy.Where(x => x.Imie.Contains(szukaneImie)));
            if (szukaneNazwisko != null)
                szukaniPracownicy = new ObservableCollection<Pracownik>(szukaniPracownicy.Where(x => x.Nazwisko.Contains(szukaneNazwisko)));
            if (szukaneStanowisko != null)
                szukaniPracownicy = new ObservableCollection<Pracownik>(szukaniPracownicy.Where(x => x.StanowiskoPracy.Contains(szukaneStanowisko)));
            if (szukaneLataPracy != null)
                szukaniPracownicy = new ObservableCollection<Pracownik>(szukaniPracownicy.Where(x => x.LataPracy == szukaneLataPracy));
            if (szukaneDostepnyUrlop != null)
                szukaniPracownicy = new ObservableCollection<Pracownik>(szukaniPracownicy.Where(x => x.DostepnyUrlop == szukaneDostepnyUrlop));
        }
    }
}
