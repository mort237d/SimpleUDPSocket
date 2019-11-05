using System;

namespace JsonUDPSender
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPSender udpSender = new UDPSender();
            udpSender.Start();
        }
    }
}
