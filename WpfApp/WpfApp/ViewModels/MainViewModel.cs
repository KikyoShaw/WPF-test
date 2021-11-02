using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Command;

namespace WpfApp.ViewModels
{
	internal class MainViewModel: NotificationObject
	{
		//数据属性
		private double input1;

		public double Input1
		{
			get { return input1; }
			set 
			{ 
				input1 = value; 
				this.RaisePropertyChange(nameof(Input1));
			}
		}

		private double input2;

		public double Input2
		{
			get { return input2; }
			set
			{
				input2 = value;
				this.RaisePropertyChange(nameof(Input2));
			}
		}

		private double result;

		public double Result 
		{ 
			get { return result; } 
			set
			{
				result = value;
				this.RaisePropertyChange (nameof(Result));
			}
		}

		//命令属性
		public DelegateCommand AddCommand { get; set; }
		public DelegateCommand CloseCommand { get; set;}

		private void Add(object parameter)
		{
			this.Result = this.Input1 + this.Input2;
		}

		private void CloseWidget(object parameter)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.ShowDialog();
		}

		//构造函数
		public MainViewModel()
		{
			this.AddCommand = new DelegateCommand();
			this.AddCommand.ExecuteAction = new Action<object>(this.Add);

			this.CloseCommand = new DelegateCommand();
			this.CloseCommand.ExecuteAction = new Action<object>(this.CloseWidget);
		}
	}
}
