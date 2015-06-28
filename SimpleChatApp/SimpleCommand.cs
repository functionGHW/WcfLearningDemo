/* 
 * FileName:    SimpleCommand.cs
 * Author:      functionghw<functionghw@hotmail.com>
 * CreateTime:  6/28/2015 1:53:42 PM
 * Version:     v1.0
 * Description:
 * */

namespace SimpleChatApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class SimpleCommand : ICommand
    {

        private Action<object> action;

        public SimpleCommand(Action<object> action)
        {
            this.action = action;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.action(parameter);
        }

        #endregion
    }
}
