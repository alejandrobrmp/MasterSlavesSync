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

namespace MasterSlavesSync.Controls
{
    public class TextInput : TextBox
    {
        public string Title
        {
            get { return GetValue(TitleProperty) as string; }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                nameof(Title),
                typeof(string),
                typeof(TextInput),
                new FrameworkPropertyMetadata("No data"));

        public int? TitleFontSize
        {
            get { return GetValue(TitleFontSizeProperty) as int?; }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register(
                nameof(TitleFontSize),
                typeof(int?),
                typeof(TextInput),
                new FrameworkPropertyMetadata(10));

        public Button Button
        {
            get { return GetValue(ButtonProperty) as Button; }
            set { SetValue(ButtonProperty, value); }
        }

        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register(
                nameof(Button),
                typeof(Button),
                typeof(TextInput));



        static TextInput()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextInput), new FrameworkPropertyMetadata(typeof(TextInput)));
        }
    }
}
