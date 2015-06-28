/* 
 * FileName:    Program.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  6/28/2015 10:45:57 AM
 * Version:     v1.0
 * Description:
 * */

using Demo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:4000/IHelloWCF");

            var binding = new WSHttpBinding();
            
            ChannelFactory<IHelloWCF> factory =
               new ChannelFactory<IHelloWCF>(binding, new EndpointAddress(address));

            var proxy = factory.CreateChannel();


            string input = null;
            while (input != "q")
            {
                input = Console.ReadLine();
                proxy.Say(input);
            }
        }
    }
}
