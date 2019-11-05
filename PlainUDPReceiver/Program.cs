using System;

namespace PlainUDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPReceiver udpReceiver = new UDPReceiver();
            udpReceiver.Start();
        }
    }
}
