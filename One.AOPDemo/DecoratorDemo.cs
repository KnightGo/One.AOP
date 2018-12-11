using One.AOPDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.AOPDemo
{
    public class DecoratorDemo : IUser
    {
        public IUser _User { get; set; }
        public DecoratorDemo(IUser user)
        {
            _User = user;
        }

        public string RegUser(User user)
        {
            Console.WriteLine("Before Action");
            string result = _User.RegUser(user);
            Console.WriteLine("After Action");
            return result;
        }
    }
}
