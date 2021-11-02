﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.Ui
{
	/// <summary>
	/// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
	///
	/// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
	/// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
	/// 元素中:
	///
	///     xmlns:MyNamespace="clr-namespace:WpfApp.Ui"
	///
	///
	/// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
	/// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
	/// 元素中:
	///
	///     xmlns:MyNamespace="clr-namespace:WpfApp.Ui;assembly=WpfApp.Ui"
	///
	/// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
	/// 并重新生成以避免编译错误:
	///
	///     在解决方案资源管理器中右击目标项目，然后依次单击
	///     “添加引用”->“项目”->[浏览查找并选择此项目]
	///
	///
	/// 步骤 2)
	/// 继续操作并在 XAML 文件中使用控件。
	///
	///     <MyNamespace:iconButton/>
	///
	/// </summary>
	public class IconButton : Button
	{
		static IconButton()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(IconButton), new FrameworkPropertyMetadata(typeof(IconButton)));
		}

		// Normal
		public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(BitmapImage), typeof(IconButton));
		public BitmapImage Icon
		{
			get { return (BitmapImage)GetValue(IconProperty); }
			set { SetValue(IconProperty, value); }
		}

		//  Hover
		public static readonly DependencyProperty HoverIconProperty = DependencyProperty.Register("HoverIcon", typeof(BitmapImage), typeof(IconButton));
		public BitmapImage HoverIcon
		{
			get { return (BitmapImage)GetValue(HoverIconProperty); }
			set { SetValue(HoverIconProperty, value); }
		}

		//  Pushed
		public static readonly DependencyProperty PushIconProperty = DependencyProperty.Register("PushIcon", typeof(BitmapImage), typeof(IconButton));
		public BitmapImage PushIcon
		{
			get { return (BitmapImage)GetValue(PushIconProperty); }
			set { SetValue(PushIconProperty, value); }
		}
	}
}
