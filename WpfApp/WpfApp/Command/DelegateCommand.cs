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

		// 在命令可执行状态发生改变时触发
		//当出现影响是否应执行该命令的更改时发生
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value;}
		}

		//检查命令是否可用的方法
		//定义确定此命令是否可在其当前状态下执行的方法
		public bool CanExecute(object parameter)
		{
			if(this.CanExecuteFunc == null)
			{
				return true;
			}

			return this.CanExecuteFunc(parameter);
		}

		//命令执行的方法
		//定义在调用此命令时要调用的方法
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
