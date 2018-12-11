using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.AOPDemo
{
    /// <summary>
    /// 代理类
    /// </summary>
   public class ProxyDemo:IUser
    {
        private IUser _User = new User();

        public string RegUser(User user)
        {
            Console.WriteLine("Befor Action");
            string result = _User.RegUser(user);
            Console.WriteLine("After Action");

            return result;
        }
    }
}
