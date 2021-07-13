using EwidencjaUrlopow.Model;
using EwidencjaUrlopow.Windows;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EwidencjaUrlopow.ViewModel 
{
    class UrlopVM : BaseVM
    {
        UtworzUrlop _utworzUrlopWindow;
        EdytujUrlop _edytujUrlopWindow;

        ObservableCollection<Urlop> _wszystkieUrlopy = new ObservableCollection<Urlop>();
        public ObservableCollection<Urlop> wszystkieUrlopy
        {
            get => _wszystkieUrlopy;
            set => SetProperty(ref _wszystkieUrlopy, value);
        }

        ObservableCollection<Urlop> _szukaneUrlopy = new ObservableCollection<Urlop>();
        public ObservableCollection<Urlop> szukaneUrlopy
        {
            get => _szukaneUrlopy;
            set => SetProperty(ref _szukaneUrlopy, value);
        }

        Urlop _selectedItem;
        public Urlop selectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        int? _szukaneIdUrlopu;
        public int? szukaneIdUrlopu
        {
            get => _szukaneIdUrlopu;
            set
            {
                if (value != szukaneIdUrlopu)
                    SetProperty(ref _szukaneIdUrlopu, value);
            }
        }

        int? _szukaneDni;
        public int? szukaneDni
        {
            get => _szukaneDni;
            set
            {
                if (value != szukaneDni)
                    SetProperty(ref _szukaneDni, value);
            }
        }
        DateTime? _szukaneDataRozpoczecia;
        public DateTime? szukaneDataRozpoczecia
        {
            get => _szukaneDataRozpoczecia;
            set
            {
                if (value != szukaneDataRozpoczecia)
                    SetProperty(ref _szukaneDataRozpoczecia, value);
            }
        }
        DateTime? _szukaneDataZakonczenia;
        public DateTime? szukaneDataZakonczenia
        {
            get => _szukaneDataZakonczenia;
            set
            {
                if (value != szukaneDataZakonczenia)
                    SetProperty(ref _szukaneDataZakonczenia, value);
            }
        }
        string _szukaneOpis;
        public string szukaneOpis
        {
            get => _szukaneOpis;
            set
            {
                if (value != szukaneOpis)
                    SetProperty(ref _szukaneOpis, value);
            }
        }
        int? _szukaneIdPracownika;
        public int? szukaneIdPracownika
        {
            get => _szukaneIdPracownika;
            set
            {
                if (value != szukaneIdPracownika)
                    SetProperty(ref _szukaneIdPracownika, value);
            }
        }

        public ICommand OpenAddLeaveWindowCommand { get; }
        public ICommand SearchCommand { get; }

        bool isWindowOpened = false;

        public UrlopVM()
        {
            OpenAddLeaveWindowCommand = new DelegateCommand(OpenAddLeaveWindow);
            SearchCommand = new DelegateCommand(UpdateSearch);
            PopulateLeaves();
        }

        private void UtworzUrlop_Closed(object sender, EventArgs e) => isWindowOpened = false;
        private void EdytujUrlop_Closed(object sender, EventArgs e) => isWindowOpened = false;

        public async void OpenAddLeaveWindow()
        {
            if (!isWindowOpened)
                await AddLeave();
        }
        async Task AddLeave()
        {
            isWindowOpened = true;
            _utworzUrlopWindow = new UtworzUrlop();
            _utworzUrlopWindow.Closed += UtworzUrlop_Closed;
            _utworzUrlopWindow.Show();
            await Task.Yield();
        }

        public async void OpenEditLeave()
        {
            if (!isWindowOpened)
                await EditLeave();
        }
        async Task EditLeave()
        {
            isWindowOpened = true;
            _edytujUrlopWindow = new EdytujUrlop(selectedItem);
            _edytujUrlopWindow.Closed += EdytujUrlop_Closed;
            _edytujUrlopWindow.Show();
            await Task.Yield();
        }

        public void PopulateLeaves()
        {
            var ewidencjaUrlopowContext = new EwidencjaUrlopowContext();
            var leavesList = ewidencjaUrlopowContext.Urlops;
            foreach (var leave in leavesList)
            {
                if (!wszystkieUrlopy.Contains(leave))
                    wszystkieUrlopy.Add(leave);
            }

            UpdateSearch();
        }

        public void UpdateSearch()
        {
            szukaneUrlopy = new ObservableCollection<Urlop>(wszystkieUrlopy);

            if (szukaneIdUrlopu != null)
                szukaneUrlopy = new ObservableCollection<Urlop>(szukaneUrlopy.Where(x => x.IdUrlopu == szukaneIdUrlopu));
            if (szukaneDni != null)
                szukaneUrlopy = new ObservableCollection<Urlop>(szukaneUrlopy.Where(x => x.DniUrlopu == szukaneDni));
            if (szukaneDataRozpoczecia != null)
                szukaneUrlopy = new ObservableCollection<Urlop>(szukaneUrlopy.Where(x => x.DataRozpoczeciaUrlopu == szukaneDataRozpoczecia));
            if (szukaneDataZakonczenia != null)
                szukaneUrlopy = new ObservableCollection<Urlop>(szukaneUrlopy.Where(x => x.DataZakonczeniaUrlopu == szukaneDataZakonczenia));
            if (szukaneOpis != null)
                szukaneUrlopy = new ObservableCollection<Urlop>(szukaneUrlopy.Where(x => x.OpisUrlopu.Contains(szukaneOpis)));
            if (szukaneIdPracownika != null)
                szukaneUrlopy = new ObservableCollection<Urlop>(szukaneUrlopy.Where(x => x.IdPracownika == szukaneIdPracownika));
        }
    }
}
