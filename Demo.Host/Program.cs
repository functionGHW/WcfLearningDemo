/* 
 * FileName:    Program.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  6/28/2015 10:34:07 AM
 * Version:     v1.0
 * Description:
 * */

using Demo.Contracts;
using Demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:4000/IHelloWCF");

            var binding = new WSHttpBinding();

            ServiceHost svc = new ServiceHost(typeof(HelloWCFService));

            svc.AddServiceEndpoint(typeof(IHelloWCF), binding, address);

            svc.Opened += (o, e) => { Console.WriteLine("Service started."); };

            svc.Open();

            Console.ReadLine();

            svc.Close();
        }
    }
}
