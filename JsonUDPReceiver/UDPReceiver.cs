using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ModelLib;
using Newtonsoft.Json;

namespace JsonUDPReceiver
{
    class UDPReceiver
    {
        private const int PORT = 11002;

        public void Start()
        {
            UdpClient client = new UdpClient(PORT);

            Console.WriteLine("UDP receiver startet på port " + PORT);

            IPEndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] bytes = client.Receive(ref remote);
                string str = Encoding.UTF8.GetString(bytes);

                Console.WriteLine("Modtaget " + str);

                Car car = JsonConvert.DeserializeObject<Car>(str);
                Console.WriteLine("Deserialize: " + car);

                string upperStr = str.ToUpper();
                byte[] buffer = Encoding.UTF8.GetBytes(upperStr.ToCharArray(), 0, upperStr.Length);

                client.Send(buffer, buffer.Length, remote);
            }
        }
    }
}
