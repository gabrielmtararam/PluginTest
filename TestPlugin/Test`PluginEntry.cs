using Proculus.UnicViewTerminal.PluginApi.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using System.Windows.Shapes;
using Proculus.UnicViewTerminal.PluginApi.Broking;
using Proculus.UnicViewTerminal.PluginApi.Broking.Payloads;
using Proculus.UnicViewTerminal.PluginApi.BaseClasses;
using Proculus.UnicViewTerminal.PluginApi.BaseClasses.Payloads;

namespace TestPlugin
{
    [Export(typeof(IGraphicalPlugin))]
    public class Test_PluginEntry : IGraphicalPlugin,
        ISubscriber<IDataInPayload>,
        ISubscriber<IDataOutPayload>,
        ISubscriber<IConnectionStatePayload>,
        IPublisher<IDataInPayload>,
         IPublisher<IDataOutPayload>
    {


        public string PluginName { get; } = "teste plugin 1";

        public string Description { get; } = "primeiro teste com  plugin";

        public string Version { get; } = "1.0.0";

        public PluginCategory PluginCategory { get; } = PluginCategory.Other;

        public bool IsProductionDefault { get; } = false;

        public Guid Guid { get; } = Guid.Parse("8DCBC4A9-CD5B-48CC-886D-8D01C23A3CCC");

        public UserControl UserControl { get; } = new TestPluginGui();

        public UIElement Icon { get; }

        private TestPluginGui _testPluginGui;


        public Test_PluginEntry()
        {
            var path = new Path {
                Data = Geometry.Parse("M17,3H7A2,2 0 0,0 5,5V21L12,18L19,21V5C19,3.89 18.1,3 17,3Z")
            };
            path.SetResourceReference(Shape.FillProperty, "MaterialDesignBody");

            Icon = new Canvas
            {
                Width = 24,
                Height = 24,
                Children =
                {
                    path
                }
            };


            _testPluginGui = (TestPluginGui)UserControl;
            _testPluginGui.completeEvent += OnCommandComplete;
            

            


        }

        private void OnCommandComplete(object sender, CommandCompleteEventArgs e)
        {
            MessageBox.Show("enviado 2" + e._command);

            var dataOutPayload = new DataOutPayloadBase
            {
                Bytes = new Byte[] { 1, 2, 3, 4 }
            };

            var dataOutPayloadWrapper = new BrokerPayloadWrapperBase<IDataOutPayload>
            {
                Payload = dataOutPayload
            };

            Publish(dataOutPayloadWrapper);
        }



        public void Close(object sender, CancelEventArgs args)
        {
            // args.Cancel = true;

            var dialogResult = MessageBox.Show("Pode fechar", "Pergunta", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(dialogResult==MessageBoxResult.Yes)
            {
                return;
            }
            else{
                args.Cancel = true;
                MessageBox.Show("o host nao vai fechar");
            }
            //aplicativo vai  cancelar  o fechamento, exemplo serve pra salvar o conteudo antes de fechar
            //o false continua o fechamento normal
        }

        private string addDataFolder;
        public void SetAppDataFolder(string appDataFolder)
        {
            addDataFolder = appDataFolder;
            //
        }

        private bool _isConnected;
        public void PublishStateEvents()
        {
            // chama quando o host precisa que o plugin publique um estado/informacao de novo, exemplo estado de conexao
            //ex alterar estado is connected (pergunta)
        }



        //////////////////
        /// Publisher
        ////////////////
        /// evento lançado pelo plugin

        ///thread safety lock object
        private readonly object _lock = new object();


        //data in
        private EventHandler<IBrokerPayloadWrapper<IDataInPayload>> _IDataInPayloadPublished;

        //este eh o evento (payloadpublished) que vai ser lançado pelo plugin que o broker do host vai atender
        //para lançar esse evento poder criar os metodos privados Publish
        event EventHandler<IBrokerPayloadWrapper<IDataInPayload>> IPublisher<IDataInPayload>.PayloadPublished
            {
                add{
                        lock(_lock)
                            {
                             _IDataInPayloadPublished=value;;
                            }
                    }
            remove
            {
                lock (_lock)
                {
                    _IDataInPayloadPublished = value; ;
                }

            }
        }

        //ele dispara o evento
        private void Publish (IBrokerPayloadWrapper<IDataInPayload> payloadWrapper)
        {
            _IDataInPayloadPublished?.Invoke(this, payloadWrapper);
        }

        //data out
        private EventHandler<IBrokerPayloadWrapper<IDataOutPayload>> _IDataOutPayloadPublished;

        event EventHandler<IBrokerPayloadWrapper<IDataOutPayload>> IPublisher<IDataOutPayload>.PayloadPublished
        {
            add
            {
                lock (_lock)
                {
                    _IDataOutPayloadPublished = value; ;
                }
            }
            remove
            {
                lock (_lock)
                {
                    _IDataOutPayloadPublished = value; ;
                }

            }
        }
        //ele dispara o evento
        private void Publish(IBrokerPayloadWrapper<IDataOutPayload> payloadWrapper)
        {
            _IDataOutPayloadPublished?.Invoke(this, payloadWrapper);
        }

        //////////////////
        /// Subscribe
        ////////////////

        //tratando recepcao de dados
        public void NotifySubscription(IBrokerPayloadWrapper<IDataInPayload> brokerPayloadWrapper)
        {

            // chamado pelo host, quando outro plugin publisher, publica um payload deste tipo IdataPay...
            //basicamente o plugin aqui fazendo uma logica com o que foi recebido
            // brokerPayloadWrapper.DateTime data e hora q o payload foi criado
            //  brokerPayloadWrapper.Sender quem enviou
            // brokerPayloadWrapper.Payload o proprio payload que eh do tipo data in nesse caso
            MessageBox.Show($"Bytes arrived: {brokerPayloadWrapper.Payload.Bytes.Count()}"); 

        }

        //tratamento do envio de dados
        public void NotifySubscription(IBrokerPayloadWrapper<IDataOutPayload> brokerPayloadWrapper)
        {
            //
        }

        //tratamento do estado de conexao
        public void NotifySubscription(IBrokerPayloadWrapper<IConnectionStatePayload> brokerPayloadWrapper)
        {
           // throw new NotImplementedException();
        }




    }
}
