using MVVM.Test.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingTest
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.dataText.DataContext = new Text() { Name = "WPF" };

			//为当前窗口构建数据上下文
			//这是一种弱绑定
			//this.DataContext = new MainWindowModel();

			this.DataContext = new MainViewModelFody();
		}

		public class Text
		{
			public string Name { get; set; }
		}
	}
}
