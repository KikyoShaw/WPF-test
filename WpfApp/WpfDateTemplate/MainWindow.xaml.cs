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

namespace WpfDateTemplate
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			List<User> users = new List<User>();
			users.Add(new User() { UserId = "1001001", UserName = "张三", Address = "广州市" });
			users.Add(new User() { UserId = "1001002", UserName = "李四", Address = "深圳市" });
			users.Add(new User() { UserId = "1001003", UserName = "王五", Address = "佛山市" });
			users.Add(new User() { UserId = "1001004", UserName = "赵六", Address = "东莞市" });
			this.gd.ItemsSource = users;

			List<Color> ColorList = new List<Color>();
			ColorList.Add(new Color() { Code = "#FF8C00" });
			ColorList.Add(new Color() { Code = "#FF7F50" });
			ColorList.Add(new Color() { Code = "#FF6EB4" });
			ColorList.Add(new Color() { Code = "#FF4500" });
			ColorList.Add(new Color() { Code = "#FF3030" });
			ColorList.Add(new Color() { Code = "#CD5B45" });
			this.cob.ItemsSource = ColorList;
			this.lib.ItemsSource = ColorList;

			List<Test> tests = new List<Test>();
			tests.Add(new Test() { Code = "1" });
			tests.Add(new Test() { Code = "2" });
			tests.Add(new Test() { Code = "3" });
			tests.Add(new Test() { Code = "4" });
			tests.Add(new Test() { Code = "5" });
			tests.Add(new Test() { Code = "6" });
			this.ic.ItemsSource = tests;
		}

		public class User
		{
			public string UserId { get; set; }
			public string UserName { get; set; }
			public string Address { get; set; }
		}

		public class Color
		{
			public string Code { get; set; }
		}

		public class Test
		{
			public string Code { get; set; }
		}
	}
}
