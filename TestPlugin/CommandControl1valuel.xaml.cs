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

namespace TestPlugin
{
    /// <summary>
    /// Interaction logic for CommandControl.xaml
    /// </summary>
    public partial class CommandControl1Value : UserControl
    {



        public String CommandName
        {
            get { return (String)GetValue(CommandNameProperty); }
            set { SetValue(CommandNameProperty, value); }
        }


        public static readonly DependencyProperty CommandNameProperty =
            DependencyProperty.Register("CommandName", typeof(String), typeof(CommandControl1Value), new PropertyMetadata("defaultName"));




        public String CommandHeader
        {
            get { return (String)GetValue(CommandHeaderProperty); }
            set { SetValue(CommandHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandHeaderProperty =
            DependencyProperty.Register("CommandHeader", typeof(String), typeof(CommandControl1Value), new PropertyMetadata("defaultName"));




        public String CommandByteCount
        {
            get { return (String)GetValue(CommandByteCountProperty); }
            set { SetValue(CommandByteCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandByteCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandByteCountProperty =
            DependencyProperty.Register("CommandByteCount", typeof(String), typeof(CommandControl1Value), new PropertyMetadata("defaultName"));




        public String CommandCommand
        {
            get { return (String)GetValue(CommandCommandProperty); }
            set { SetValue(CommandCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandCommandProperty =
            DependencyProperty.Register("CommandCommand", typeof(String), typeof(CommandControl1Value), new PropertyMetadata("defaultName"));





        public String CommandAdress
        {
            get { return (String)GetValue(CommandAdressProperty); }
            set { SetValue(CommandAdressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandAdress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandAdressProperty =
            DependencyProperty.Register("CommandAdress", typeof(String), typeof(CommandControl1Value), new PropertyMetadata("defaultName"));




        public String CommandValue
        {
            get { return (String)GetValue(CommandValueProperty); }
            set { SetValue(CommandValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandValueProperty =
            DependencyProperty.Register("CommandValue", typeof(String), typeof(CommandControl1Value), new PropertyMetadata("defaultName"));





        public CommandControl1Value()
        {
            InitializeComponent();
        }




      
       
    }
}
