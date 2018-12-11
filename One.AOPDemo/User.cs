using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.AOPDemo
{
    public class User : MarshalByRefObject,IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }


        public virtual string RegUser(User user)
        {
            Console.WriteLine($"注册成功：{user.Id}:姓名：{user.Name}；密码：{user.Pwd}");
            return $"注册成功：{user.Id}:姓名：{user.Name}；密码：{user.Pwd}";
        }

    }
}
