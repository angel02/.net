using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Net;

using System.ComponentModel;
//using System.Collections;

namespace Networking
{
    class Program
    {
        static void Main(string[] args){
            App app = new App();
            if (args.Length == 1){
                app.start(args[0]);
            } else {
                Console.WriteLine("Introduzca la URL deseada:");
                app.start(Console.ReadLine());
            }
        }
    }

    class App {
        private WebClient client;

        public void start(string arg) {
            client = new WebClient();
            client.DownloadFileCompleted += client_DownloadedFileCompleted;
            client.DownloadProgressChanged += client_DownloadProgressChanged;
            string url;

            if (arg.Length > 0){
                url = arg;
                Console.WriteLine(arg.Length);
            }else{
                Console.WriteLine("Introduzca la URL deseada:");
                url = Console.ReadLine();
            }

            Uri uri = new Uri(url);
            client.DownloadFileAsync(uri, "file");

            Console.ReadLine();
        }

        private void client_DownloadedFileCompleted( object sender, AsyncCompletedEventArgs e) {
            Console.WriteLine("Download completed.");
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            Console.Clear();
            Console.WriteLine("Proceso de descarga: " + Convert.ToString(e.ProgressPercentage) + "%");
        }
    }
}
