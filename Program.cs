using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipAddress = IPAddress.Parse("192.168.100.3");
            int port = 12345;

            UdpClient udpClient = new UdpClient();

            try
            {
                udpClient.Connect(ipAddress, port);

                string ingredients = "яйца";
                byte[] request = Encoding.UTF8.GetBytes(ingredients);
                udpClient.Send(request, request.Length);

                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] response = udpClient.Receive(ref serverEndPoint);
                string recipes = Encoding.UTF8.GetString(response);
                Console.WriteLine($"Рецепты с {ingredients}:");
                Console.WriteLine(recipes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                udpClient.Close();
            }
        }
    }
}
