using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


//委托事件 Action-Func
namespace WpfApp.Command
{
	internal class DelegateCommand : ICommand
	{
		//委托
		public Action<object> ExecuteAction { get; set; }
		public Func<object, bool> CanExecuteFunc { get; set; }
		//public Predicate<object> CanExecuteFunc { get; set; }

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			if(this.CanExecuteFunc == null)
			{
				return true;
			}

			return this.CanExecuteFunc(parameter);
		}

		public void Execute(object parameter)
		{
			if(this.ExecuteAction == null)
			{
				return;
			}

			this.ExecuteAction(parameter);
		}
	}
}
