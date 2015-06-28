/* 
 * FileName:    IHelloWCF.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  6/28/2015 10:34:40 AM
 * Version:     v1.0
 * Description:
 * */

namespace Demo.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;

    [ServiceContract]
    public interface IHelloWCF
    {
        [OperationContract]
        void Say(string input);
    }
}
