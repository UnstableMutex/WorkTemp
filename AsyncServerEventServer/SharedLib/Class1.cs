using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SharedLib
{
  public  class EventServer
    {
        private TcpListener server;
        public async void Start()
        {
            server = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), 8090);
            server.Start();
            Console.WriteLine("server started");
            while (true)
            {
                var client = server.AcceptTcpClient();
                Console.WriteLine("client accept");
                ProcessClient(client);
            }

        }

        private async Task ProcessClient(TcpClient client)
        {
            byte[] bytes = new byte[1024];
            string data;

            var stream = client.GetStream();
            int i = 0;
            i = stream.Read(bytes, 0, bytes.Length);

            while (i!=0)
            {
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine(String.Format("Received: {0}", data));

            }
           
           // StreamReader r = new StreamReader(stream);
           // //var clientQuery = r.ReadToEnd();
            //Console.WriteLine(clientQuery);
            StreamWriter w = new StreamWriter(stream);
            w.Write("Answer");

        }
    }

   public class EventClient
    {
        public string ReadEvents()
        {
            var ip = new IPAddress(new byte[] {127, 0, 0, 1});
            var tcpClient = new TcpClient();
            tcpClient.Connect(ip,8090);

            NetworkStream stream = tcpClient.GetStream();

            string message = "sdfsfdsdf";


            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);         
            // Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", message);






            // Receive the TcpServer.response.

            // Buffer to store the response bytes.
            data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
            return responseData;
        }
    }
}
