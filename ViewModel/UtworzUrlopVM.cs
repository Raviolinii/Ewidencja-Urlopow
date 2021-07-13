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
    class UtworzUrlopVM : BaseVM
    {
        UtworzUrlop _view;


        DateTime? _dataRozpoczecia;
        public DateTime? dataRozpoczecia
        {
            get => _dataRozpoczecia;
            set
            {
                if (value != dataRozpoczecia)
                    SetProperty(ref _dataRozpoczecia, value);
            }
        }
        DateTime? _dataZakonczenia;
        public DateTime? dataZakonczenia
        {
            get => _dataZakonczenia;
            set
            {
                if (value != dataZakonczenia)
                    SetProperty(ref _dataZakonczenia, value);
            }
        }
        string _opis;
        public string opis
        {
            get => _opis;
            set
            {
                if (value != opis)
                    SetProperty(ref _opis, value);
            }
        }
        int _idPracownika;
        public int idPracownika
        {
            get => _idPracownika;
            set
            {
                if (value != idPracownika)
                    SetProperty(ref _idPracownika, value);
            }
        }



        public ICommand CancelAddLeaveCommand { get; }
        public ICommand AddLeaveCommand { get; }
        public UtworzUrlopVM(UtworzUrlop view)
        {
            _view = view;
            CancelAddLeaveCommand = new DelegateCommand(CancelAddLeave);
            AddLeaveCommand = new DelegateCommand(AddLeave);
        }

        public void CancelAddLeave() => _view.Close();
        public void AddLeave()
        {
            // Add data to the model
            if (ValidateDates() && ValidateDescryption() && ValidateWorkerId())
            {
                EwidencjaUrlopowContext context = new EwidencjaUrlopowContext();
                int days = CalculateDays((DateTime)dataRozpoczecia, (DateTime)dataZakonczenia);
                if (HasEnoughLeaveDays(days))
                    context.AddLeave(days, (DateTime)dataRozpoczecia, (DateTime)dataZakonczenia, opis, idPracownika);
            }

            _view.Close();
        }

        bool ValidateDates()
        {
            var today = DateTime.Now;

            if (dataRozpoczecia <= dataZakonczenia && today <= dataRozpoczecia && dataRozpoczecia != null && dataZakonczenia != null)
                return true;
            else 
                return false;
        }

        bool ValidateDescryption()
        {
            if (opis.Length > 1 && !opis.Contains('@'))
                return true;
            else
                return false;
        }

        bool ValidateWorkerId()
        {
            EwidencjaUrlopowContext context = new EwidencjaUrlopowContext();
            var cos = context.Pracowniks.Where(x => x.IdPracownika == idPracownika);
            if (cos.Count() == 1)
                return true;
            else
                return false;
        }

        public int CalculateDays(DateTime begin, DateTime end)
        {
            int result = 0;

            EwidencjaUrlopowContext context = new EwidencjaUrlopowContext();
            List<Kalendarz> leaveDays = context.Kalendarzs.Where(x => x.DzienRoku >= begin && x.DzienRoku <= end).ToList();
            foreach (var day in leaveDays)
            {
                if (!day.DzienWolny)
                    result++;
            }

            return result;
        }
        bool HasEnoughLeaveDays(int days)
        {
            EwidencjaUrlopowContext context = new EwidencjaUrlopowContext();
            Pracownik pracownik = context.Pracowniks.Find(idPracownika);
            if (pracownik.DostepnyUrlop - days >= 0)
                return true;
            else
                return false;
        }

    }
}
