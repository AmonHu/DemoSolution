using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpCilentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                using (var udpClient = new UdpClient(1399))
                {
                    while (true)
                    {
                        //IPEndPoint object will allow us to read datagrams sent from any source.
                        var result = await udpClient.ReceiveAsync();
                        Console.WriteLine(Encoding.ASCII.GetString(result.Buffer));

                    }
                }
            });

            Console.ReadKey();
        }
    }
}
