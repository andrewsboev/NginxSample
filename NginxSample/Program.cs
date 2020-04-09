using System;
using System.Linq;
using System.Net;

namespace NginxSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var prefix = args.First();
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add(prefix);
            httpListener.Start();

            while (true)
            {
                Console.WriteLine("Listening");
                var context = httpListener.GetContext();
                var request = context.Request;
                var response = context.Response;
                var responseString = $"<HTML><BODY> Hello from {prefix} </BODY></HTML>";
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                var output = response.OutputStream;
                output.Write(buffer,0,buffer.Length);
                output.Close();
            }
        }
    }
}