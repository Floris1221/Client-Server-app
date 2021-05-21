using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Serwer
    {
        static void Main(string[] args)
        {
            Serwer serwe = new Serwer();
        }


        TcpListener serwer;
        TcpClient socet;
        public static int port = 1777;
        public static IPAddress ipaddresss = IPAddress.Parse("127.0.0.1"); 
        Serwer()
        {
            try
            {
                serwer = new TcpListener(ipaddresss,port);
                serwer.Start();
                while (true)
                {
                    Console.WriteLine("Czekam na połączenie");
                    if (Users.clients < 5)
                    {
                        socet = serwer.AcceptTcpClient();
                        Console.WriteLine("Jest połączenie na porcie " + socet.Client.RemoteEndPoint.ToString());
                        Thread t = new Thread(new Users(socet).run);
                        t.Start();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Błąd połączenia");
            }
            

        }
    }
}
