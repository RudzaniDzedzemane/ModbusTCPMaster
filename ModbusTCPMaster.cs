using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ModbusTCPMaster
{
    public class ModbusTCPMaster
    {

        // Parameters

        Int32 port;

        IPAddress ServerIPAddress;

        IPEndPoint serverIPEnd;

        Socket TCPmasterSocket;


        public ModbusTCPMaster(String ServerIPAddressString, Int32 port)
        {

            this.port = port;
            this.ServerIPAddress = IPAddress.Parse(ServerIPAddressString);

            this.serverIPEnd = new IPEndPoint(this.ServerIPAddress, this.port);

            try
            {
                this.TCPmasterSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            catch(SocketException e)
            {
                Console.WriteLine("Error creating Socket");
                TCPmasterSocket.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error creating Socket");
                TCPmasterSocket.Close();
            }

            

            
        }

        public void OpenConnectionAndprintMessages()
        {

            try
            {
                this.TCPmasterSocket.Bind(this.serverIPEnd);
            }
            catch(Exception e)
            {
                Console.WriteLine("Winsock error: " + e.ToString());
            }
            
            Console.WriteLine("Listening for incoming connections");
            Console.WriteLine("==================================");

            this.TCPmasterSocket.Listen();

            Socket ClientSocket = TCPmasterSocket.Accept();

            Console.WriteLine("Connection made to IP Address: " + ClientSocket.RemoteEndPoint.ToString());

            Console.WriteLine("==================================");

            Console.WriteLine("Closing Connection");

            ClientSocket.Close();

            TCPmasterSocket.Close();

        }

        public void CloseConnection()
        {
            TCPmasterSocket.Close();
        }

    }

}
