using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PlainUDPReceiver
{
    class UDPReceiver
    {
        private const int PORT = 11001;

        public void Start()
        {
            //"server" egentlig receiver
            UdpClient client = new UdpClient(PORT);

            Console.WriteLine("UDP receiver startet på port " + PORT);

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] bytes = client.Receive(ref remote);
                string str = Encoding.UTF8.GetString(bytes);

                Console.WriteLine("Modtaget " + str);
                string upperStr = str.ToUpper();
                byte[] buffer = Encoding.UTF8.GetBytes(upperStr.ToCharArray(), 0, upperStr.Length);

                client.Send(buffer, buffer.Length, remote);
            }
        }
    }
}
