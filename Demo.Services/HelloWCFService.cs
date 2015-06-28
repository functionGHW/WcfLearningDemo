/* 
 * FileName:    HelloWCFService.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  6/28/2015 10:36:02 AM
 * Version:     v1.0
 * Description:
 * */

namespace Demo.Services
{
    using Demo.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;

    public class HelloWCFService : IHelloWCF
    {
        #region IHelloWCF Members

        public void Say(string input)
        {
            Console.WriteLine("Client: " + input);
            //using (var fs = File.CreateText("E:\\wcfmsg.xml"))
            //{
            //    fs.WriteLine(OperationContext.Current.RequestContext.RequestMessage.ToString());
            //}
        }

        #endregion
    }
}
