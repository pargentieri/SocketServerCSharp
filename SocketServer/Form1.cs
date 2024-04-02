using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace SocketServer
{
    public partial class Form1 : Form
    {
        private string text { get; set; }

        public Form1()
        {
            InitializeComponent();
            createSockServer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       

        private void createSockServer()
        {
            var server = new WebSocketSharp.Server.WebSocketServer("ws://localhost:3000");
            server.AddWebSocketService<Chat>("/chat");
            server.Start();
            server.WebSocketServices["/chat"].Sessions.Broadcast("pippo");


            Console.WriteLine("Server avviato su ws://localhost:3000/chat");
            Console.ReadLine();

            //server.
            //server.Stop();
        }
    }

    public class Chat : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string message =e.Data;
            Console.WriteLine($"Messaggio ricevuto:"+ message);

            // Esempio di invio di un messaggio di risposta
            string response = "Messaggio ricevuto correttamente!";
            Send(response);
        }
    }
}
