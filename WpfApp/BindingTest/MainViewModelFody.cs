using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Test.ViewModel
{
	[AddINotifyPropertyChangedInterface]
	public class MainViewModelFody
	{
		public string FodyName { get; set; }

		public MainViewModelFody()
		{
			FodyName = "FODY";

			Task.Run(async() => { 
				await Task.Delay(2000);
				FodyName = "WPFFODY";
			});
		}
	}
}
