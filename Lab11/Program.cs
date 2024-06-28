using Lab1;
using System.Net.Sockets;
using System.Text;

namespace Lab11
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}