/* 
 * FileName:    MainWindowViewModel.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  6/28/2015 1:31:25 PM
 * Version:     v1.0
 * Description:
 * */

namespace SimpleChatApp
{
    using Demo.Contracts;
    using Demo.Services;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MainWindowViewModel : INotifyPropertyChanged, IHelloWCF
    {
        private string listenPort;
        private string displayName;
        private string connectIP;
        private string connectPort;
        private string chatBoard;
        private string message;
        private bool isServerStarted;

        public MainWindowViewModel()
        {
            this.ListenPort = "4000";
            this.DisplayName = Environment.UserName;
            this.ConnectIP = "127.0.0.1";
            this.ConnectPort = "4000";
            this.IsServerStarted = false;

            this.StartServerCommand = new SimpleCommand(StartServerCommandExecute);
            this.StopServerCommand = new SimpleCommand(StopServerCommandExecute);
            this.ConnectCommand = new SimpleCommand(ConnectCommandExecute);
            this.SendCommand = new SimpleCommand(SendCommandExecute);
        }

        #region Properties

        public string ListenPort
        {
            get { return this.listenPort; }
            set { this.listenPort = value; OnPropertyChanged(); }
        }

        public string DisplayName
        {
            get { return this.displayName; }
            set { this.displayName = value; OnPropertyChanged(); }
        }

        public string ConnectIP
        {
            get { return this.connectIP; }
            set { this.connectIP = value; OnPropertyChanged(); }
        }

        public string ConnectPort
        {
            get { return this.connectPort; }
            set { this.connectPort = value; OnPropertyChanged(); }
        }

        public string ChatBoard
        {
            get { return this.chatBoard; }
            set { this.chatBoard = value; OnPropertyChanged(); }
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; OnPropertyChanged(); }
        }

        public bool IsServerStarted
        {
            get { return this.isServerStarted; }
            set { this.isServerStarted = value; OnPropertyChanged(); }
        }

        #endregion

        #region Commands

        public ICommand StartServerCommand { get; set; }

        public ICommand StopServerCommand { get; set; }

        public ICommand ConnectCommand { get; set; }

        public ICommand SendCommand { get; set; }

        #endregion

        #region Command Implements

        private void StartServerCommandExecute(object parameter)
        {
            if (this.ListenPort != null)
            {
                this.StartServer();
            }
        }

        private void StopServerCommandExecute(object parameter)
        {
            this.StopServer();
        }

        private void ConnectCommandExecute(object parameter)
        {
            this.ConnectTo();
        }

        private void SendCommandExecute(object parameter)
        {
            if (!string.IsNullOrEmpty(this.Message))
            {
                string msg = string.Format("[{0}] {1}: {2}", DateTime.Now.ToString(),
                    this.DisplayName, this.Message);
                Task.Run(() =>
                {
                    this.proxy.Say(msg);
                    this.ChatBoard += msg + "\n";

                    this.Message = string.Empty;
                });
            }
        }

        #endregion

        #region Private Methods

        private ServiceHost svc;

        private void StartServer()
        {
            Uri address = new Uri(string.Format("http://localhost:{0}/IHelloWCF", this.ListenPort));

            var binding = new BasicHttpBinding();

            this.svc = new ServiceHost(this);

            this.svc.AddServiceEndpoint(typeof(IHelloWCF), binding, address);
            this.svc.Open();
            this.IsServerStarted = true;
            this.ChatBoard += "Server started" + "\n";
        }

        private void StopServer()
        {
            this.svc.Close();
            this.IsServerStarted = false;
            this.ChatBoard += "Server stopped" + "\n";
        }


        private IHelloWCF proxy;
        private void ConnectTo()
        {
            string addr = string.Format("http://{0}:{1}/IHelloWCF", this.ConnectIP, this.ConnectPort);
            Uri address = new Uri(addr);

            var binding = new BasicHttpBinding();

            ChannelFactory<IHelloWCF> factory =
               new ChannelFactory<IHelloWCF>(binding, new EndpointAddress(address));

            proxy = factory.CreateChannel();
            this.ChatBoard += "Connect to " + this.ConnectIP + "\n";
        }

        #endregion


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException("propertyName");

            var theEvent = this.PropertyChanged;
            if (theEvent != null)
            {
                theEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region IHelloWCF Members

        public void Say(string input)
        {
            this.ChatBoard += input + "\n";
        }

        #endregion
    }
}
