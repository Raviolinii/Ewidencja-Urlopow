using EwidencjaUrlopow.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace EwidencjaUrlopow.ViewModel
{
    class KalendarzVM : BaseVM
    {
        private ObservableCollection<Kalendarz> _calyKalendarz = new ObservableCollection<Kalendarz>();
        public ObservableCollection<Kalendarz> calyKalendarz
        {
            get => _calyKalendarz;
            set => SetProperty(ref _calyKalendarz, value);
        }

        private ObservableCollection<Kalendarz> _freeDays = new ObservableCollection<Kalendarz>();
        public ObservableCollection<Kalendarz> freeDays
        {
            get => _freeDays;
            set => SetProperty(ref _freeDays, value);
        }

        DateTime? _selectedDay;
        public DateTime? selectedDay
        {
            get => _selectedDay;
            set
            {
                if (_selectedDay != value)
                    SetProperty(ref _selectedDay, value);

                if (value is not null)
                {
                    var dayToSelect = freeDays.FirstOrDefault(x => x.DzienRoku == value);

                    if (dayToSelect is not null)
                    {
                        if (selectedFreeDay != dayToSelect)
                            selectedFreeDay = dayToSelect;
                    }
                    else
                        selectedFreeDay = null;
                }
            }
        }

        Kalendarz? _selectedFreeDay;
        public Kalendarz? selectedFreeDay
        {
            get => _selectedFreeDay;
            set
            {
                if (value != null)
                {
                    if (selectedDay != value.DzienRoku)
                        selectedDay = value.DzienRoku;
                }
                if (_selectedFreeDay != value)
                    SetProperty(ref _selectedFreeDay, value);
            }
        }

        DateTime _displayDate = new DateTime();
        public DateTime displayDate
        {
            get => _displayDate;
            set
            {
                if (displayDate != value)
                {
                    SetProperty(ref _displayDate, value);
                    ShowFreeDays(displayDate.Month);
                }
            }
        }


        public KalendarzVM()
        {
            ShowCallendarCommand = new DelegateCommand(ShowCallendar);
            AddFreeDayCommand = new DelegateCommand(AddFreeDay);
            DeleteFreeDayCommand = new DelegateCommand(RemoveFreeDay);

            displayDate = DateTime.Now;
            ShowFreeDays(displayDate.Month);
            ShowCallendar();
        }
        public ICommand ShowCallendarCommand { get; set; }
        public ICommand AddFreeDayCommand { get; }
        public ICommand DeleteFreeDayCommand { get; }

        public void ShowCallendar()
        {
            var ewidencjaUrlopowContext = new EwidencjaUrlopowContext();
            var calledndarList = ewidencjaUrlopowContext.Kalendarzs;
            foreach (var item in calledndarList)
            {
                calyKalendarz.Add(item);
            }
        }

        public void ShowFreeDays(int month)
        {
            var ewidencjaUrlopowContext = new EwidencjaUrlopowContext();
            var calledndarList = ewidencjaUrlopowContext.Kalendarzs;
            var list = calledndarList.Where(x => x.DzienWolny == true && x.DzienRoku.Month == month);
            freeDays.Clear();
            foreach (var item in list)
            {
                freeDays.Add(item);
            }
        }

        public void AddFreeDay()
        {
            if (selectedDay is not null)
            {

                EwidencjaUrlopowContext ewidencjaUrlopowContext = new EwidencjaUrlopowContext();

                var day = calyKalendarz.Single(x => x.DzienRoku == selectedDay);
                if (day is not null)
                {
                    if (!day.DzienWolny)
                        ewidencjaUrlopowContext.MakeDayFree(day.DzienRoku);
                }
            }
        }

        public void RemoveFreeDay()
        {
            if (selectedDay is not null)
            {
                EwidencjaUrlopowContext ewidencjaUrlopowContext = new EwidencjaUrlopowContext();

                var day = calyKalendarz.Single(x => x.DzienRoku == selectedDay);
                if (day is not null)
                {
                    if (day.DzienWolny)
                        ewidencjaUrlopowContext.CancelDayFree(day.DzienRoku);
                }
            }
        }
    }
}
