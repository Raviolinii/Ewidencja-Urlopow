using EwidencjaUrlopow.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EwidencjaUrlopow.Commands
{
    class UpdateViewCommand : ICommand
    {
        private EwidencjaUrlopowVM _viewModel;

        public UpdateViewCommand(EwidencjaUrlopowVM viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Kalendarz")
                _viewModel.selectedViewModel = new KalendarzVM();
            else if (parameter.ToString() == "Pracownik")
                _viewModel.selectedViewModel = new PracownikVM();
            else
                _viewModel.selectedViewModel = new UrlopVM();
        }
    }
}
