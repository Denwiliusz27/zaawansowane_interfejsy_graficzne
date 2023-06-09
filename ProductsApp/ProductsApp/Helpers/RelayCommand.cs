using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ProductsApp.Helpers
{
    // wiąże komendę z metodą klasy
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action mAction;

        public Action<object> DeleteProduct { get; }

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public RelayCommand(Action<object> deleteProduct)
        {
            DeleteProduct = deleteProduct;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (DeleteProduct != null)
            {
                DeleteProduct(parameter);
            }
            else
            {
                mAction();
            }
        }
    }
}
