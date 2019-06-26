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
        public TestPluginGui()
        {
            InitializeComponent();
            DefaultEvents dargs = new DefaultEvents();
          //  AddHandler(CommandControl1Value.CommandRoutedEvent, new RoutedEventHandler(dargs.CommandEvent));
        }

        public event EventHandler EnviarClicked;

        private void ButtonEnviar_OnClick(object sender, RoutedEventArgs e)
        {
            EnviarClicked?.Invoke(this, EventArgs.Empty);
            MessageBox.Show("enviado");
        }
    }
}
