using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfApp.ViewModels;

namespace WpfApp
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			//在主界面的后台代码中把DataContext设置为ViewModel的一个实例。
			this.DataContext = new MainViewModel(); 
		}

		//  移动窗口
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			try
			{
				base.OnMouseLeftButtonDown(e);

				if (e.ButtonState == MouseButtonState.Pressed)
				{
					this.DragMove();
				}
			}
			catch (Exception) { }
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				MessageBox.Show("");

				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.ShowDialog();
			}
			catch (Exception) { };
		}

		private void button_Close(object sender, RoutedEventArgs e)
		{
			try
			{
				Close();
			}
			catch (Exception) { }
		}
		private void propNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			//限制只能输入数字
			//e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
		}

		private void addButtoon_Click(object sender, RoutedEventArgs e)
		{
			double d1 = 0;
			if (!double.TryParse(this.box1.Text, out d1))
			{
				return;
			}
			double d2 = 0;
			if (!double.TryParse(this.box2.Text, out d2))
			{
				return;
			}

			double result = d1 + d2;
			this.box3.Text = result.ToString();
		}
	}
}
