using EwidencjaUrlopow.Commands;
using EwidencjaUrlopow.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EwidencjaUrlopow.ViewModel
{
    class EwidencjaUrlopowVM : BindableBase
    {
        private BaseVM _selectedVM = new KalendarzVM();

        public BaseVM selectedViewModel
        {
            get => _selectedVM;
            set => SetProperty(ref _selectedVM, value);
        }

        public ICommand UpdateViewCommand { get; set; }       
    }
}
