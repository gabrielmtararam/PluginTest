using Proculus.UnicViewTerminal.PluginApi.BaseClasses.Payloads;
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
    /// Interaction logic for TestPluginGui.xaml
    /// </summary>
    public partial class TestPluginGui : UserControl
    {
        CommandControl0Value commandControl0;
        public TestPluginGui()
        {
           
            InitializeComponent();
            commandControl0 = (CommandControl0Value)this.FindName("commandcontrol0");
           commandControl0.EnviarClicked += OnCommandSended;
          //  AddHandler(CommandControl1Value.CommandRoutedEvent, new RoutedEventHandler(dargs.CommandEvent));
        }

        //public event EventHandler EnviarClicked;

        public event EventHandler<CommandCompleteEventArgs> completeEvent;

        private Byte[] convertToList(CommandExecEventArgs e)
        {
            Byte[] Bytes = new Byte[] { e._header, e._bytecount, e._command, e._address,e._valueCount };
            return Bytes;
        }

        private void OnCommandSended(object sender, CommandExecEventArgs e)
        {
           Byte[] message= convertToList(e);

            var dataOutPayload = new DataOutPayloadBase
            {
                Bytes = message
            };

            CommandCompleteEventArgs evArgs = new CommandCompleteEventArgs(dataOutPayload);
          
            MessageBox.Show("enviado 2"+e._header);
            completeEvent?.Invoke(this, evArgs);
            // Console.WriteLine("\nThe book '" + e._command + "' has been read by Reader A");
        }


        private void ButtonEnviar_OnClick(object sender, RoutedEventArgs e)
        {
         //   EnviarClicked?.Invoke(this, EventArgs.Empty);
            MessageBox.Show("enviado");
        }
    }
}
