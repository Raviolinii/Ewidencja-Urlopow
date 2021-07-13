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
    class EdytujUrlopVM : BaseVM
    {
        EdytujUrlop _view;
        Urlop _toRestore;
        public Urlop toRestore
        {
            get => _toRestore;
            set
            {
                if (value != toRestore)
                    SetProperty(ref _toRestore, value);
            }
        }

        Urlop _toEdit = new Urlop();
        public Urlop toEdit
        {
            get => _toEdit;
            set
            {
                if (value != _toEdit)
                    SetProperty(ref _toEdit, value);
            }
        }

        public ICommand CancelEditLeaveCommand { get; }
        public ICommand DeleteLeaveCommand { get; }
        public ICommand SaveLeaveCommand { get; }


        public EdytujUrlopVM(EdytujUrlop view, Urlop toEdit)
        {
            _view = view;
            CancelEditLeaveCommand = new DelegateCommand(CancelEditLeave);
            DeleteLeaveCommand = new DelegateCommand(DeleteLeave);
            SaveLeaveCommand = new DelegateCommand(SaveLeave);

            toRestore = toEdit;

            this.toEdit.DataRozpoczeciaUrlopu = toEdit.DataRozpoczeciaUrlopu;
            this.toEdit.DataZakonczeniaUrlopu = toEdit.DataZakonczeniaUrlopu;
            this.toEdit.DniUrlopu = toEdit.DniUrlopu;
            this.toEdit.IdPracownika = toEdit.IdPracownika;
            this.toEdit.IdUrlopu = toEdit.IdUrlopu;
            this.toEdit.OpisUrlopu = toEdit.OpisUrlopu;
            
        }

        public void CancelEditLeave() => _view.Close();
        public void DeleteLeave()
        {
            EwidencjaUrlopowContext ewidencjaUrlopowContext = new EwidencjaUrlopowContext();
            ewidencjaUrlopowContext.DeleteLeave(toEdit);
            _view.Close();
        }
        public void SaveLeave()
        {
            int days = CalculateDays(toEdit.DataRozpoczeciaUrlopu, toEdit.DataZakonczeniaUrlopu);
            toEdit.DniUrlopu = days;
            EwidencjaUrlopowContext ewidencjaUrlopowContext = new EwidencjaUrlopowContext();
            if (ValidateDates() && ValidateDescryption() && ValidateWorkerId() && HasEnoughLeaveDays())
            ewidencjaUrlopowContext.SaveLeave(toEdit);
            _view.Close();
        }
        bool ValidateDates()
        {
            var today = DateTime.Now;

            if (toEdit.DataRozpoczeciaUrlopu <= toEdit.DataZakonczeniaUrlopu && 
                today <= toEdit.DataRozpoczeciaUrlopu)
                return true;
            else
                return false;
        }

        bool ValidateDescryption()
        {
            if (toEdit.OpisUrlopu.Length > 1 && !toEdit.OpisUrlopu.Contains('@'))
                return true;
            else
                return false;
        }

        bool ValidateWorkerId()
        {
            EwidencjaUrlopowContext context = new EwidencjaUrlopowContext();
            var cos = context.Pracowniks.Where(x => x.IdPracownika == toEdit.IdPracownika);
            if (cos.Count() == 1)
                return true;
            else
                return false;
        }

        bool HasEnoughLeaveDays()
        {
            EwidencjaUrlopowContext context = new EwidencjaUrlopowContext();
            Pracownik pracownik = context.Pracowniks.Find(toEdit.IdPracownika);
            if (pracownik.DostepnyUrlop - toEdit.DniUrlopu >= 0)
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
    }
}
