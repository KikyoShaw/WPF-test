﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//MVVM模式
//INotifyPropertyChanged用来通知前端控件，ModelName改变后修改前端显示
namespace BindingTest
{
	public class MainWindowModel : /*INotifyPropertyChanged*/ ViewModelBase
	{
		public MainWindowModel()
		{
			ModelName = "WPFNAME";
			//通过线程改变ModelName
			Task.Run(async () =>
			{
				await Task.Delay(3000);
				ModelName = "NOWPF";
			});

			//按钮
			SaveCommand = new RelayCommand(() =>
			{
				ModelName = "changed by button";
			});
		}

		private string modelName;
		public string ModelName
		{
			get { return modelName; }
			set
			{
				modelName = value;
				//OnPropertyChanged("ModelName");
				RaisePropertyChanged();
			}
		}

		//按钮绑定
		public RelayCommand SaveCommand { get; private set; }

		////为属性添加通知
		//private void OnPropertyChanged(string propertyName)
		//{
		//	if(PropertyChanged != null)
		//	{
		//		PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
		//	}
		//}

		//public event PropertyChangedEventHandler PropertyChanged;
	}
}
