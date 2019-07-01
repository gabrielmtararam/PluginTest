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
    public partial class CommandControl0Value : UserControl
    {



        public String CommandName
        {
            get { return (String)GetValue(CommandNameProperty); }
            set { SetValue(CommandNameProperty, value); }
        }


        public static readonly DependencyProperty CommandNameProperty =
            DependencyProperty.Register("CommandName", typeof(String), typeof(CommandControl0Value), new PropertyMetadata("defaultName"));




        public Byte CommandHeader
        {
            get { return (Byte)GetValue(CommandHeaderProperty); }
            set { SetValue(CommandHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandHeaderProperty =
            DependencyProperty.Register("CommandHeader", typeof(Byte), typeof(CommandControl0Value), new PropertyMetadata(Convert.ToInt32("5AA5")));



        public Byte CommandValueCount
        {
            get { return (Byte)GetValue(CommandValueCountProperty); }
            set { SetValue(CommandValueCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandValueCountProperty =
            DependencyProperty.Register("CommandValueCount", typeof(Byte), typeof(CommandControl0Value), new PropertyMetadata(1));




        public Byte CommandByteCount
        {
            get { return (Byte)GetValue(CommandByteCountProperty); }
            set { SetValue(CommandByteCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandByteCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandByteCountProperty =
            DependencyProperty.Register("CommandByteCount", typeof(Byte), typeof(CommandControl0Value), new PropertyMetadata(3));




        public Byte CommandCommand
        {
            get { return (Byte)GetValue(CommandCommandProperty); }
            set { SetValue(CommandCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandCommandProperty =
            DependencyProperty.Register("CommandCommand", typeof(Byte), typeof(CommandControl0Value), new PropertyMetadata(81));





        public Byte CommandAdress
        {
            get { return (Byte)GetValue(CommandAdressProperty); }
            set { SetValue(CommandAdressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandAdress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandAdressProperty =
            DependencyProperty.Register("CommandAdress", typeof(int), typeof(CommandControl0Value), new PropertyMetadata(0));




        public Byte CommandValue
        {
            get { return (Byte)GetValue(CommandValueProperty); }
            set { SetValue(CommandValueProperty, value); }
        }

        

        // Using a DependencyProperty as the backing store for CommandValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandValueProperty =
            DependencyProperty.Register("CommandValue", typeof(Byte), typeof(CommandControl0Value), new PropertyMetadata(01));





        public CommandControl0Value()
        {
            InitializeComponent();
        }

        public event EventHandler<CommandExecEventArgs> EnviarClicked;

        private void ButtonEnviar_OnClick(object sender, RoutedEventArgs e)
        {
            byte[] values = { 0, 2, 3, 4 };
            CommandExecEventArgs evArgs = new CommandExecEventArgs(this.CommandHeader, this.CommandByteCount, this.CommandCommand, this.CommandAdress, this.CommandValueCount, values);
            EnviarClicked?.Invoke(this, evArgs);
            MessageBox.Show("enviado");
        }





    }
}
