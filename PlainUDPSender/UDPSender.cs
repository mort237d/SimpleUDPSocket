using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ModelLib;

namespace PlainUDPSender
{
    class UDPSender
    {
        private const int PORT = 11001;

        public void Start()
        {
            Car car = new Car("Tesla", "red", "EL23400");

            //sender - ingen PORT i UdpClient
            UdpClient client = new UdpClient();

            Console.WriteLine("UDP sender startet");

            IPEndPoint ReceiverEP = new IPEndPoint(IPAddress.Loopback, PORT);

            string str = car.ToString();
            Console.WriteLine("Sender " + str);

            byte[] buffer = Encoding.UTF8.GetBytes(str.ToCharArray());
            client.Send(buffer, buffer.Length, ReceiverEP);


            byte[] bytes = client.Receive(ref ReceiverEP);
            string instr = Encoding.UTF8.GetString(bytes);

            Console.WriteLine("Tilbage fra receiver: " + instr);
            Console.ReadLine();
        }
    }
}
