using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace One.AOPDemo
{
    public class ExceptionDemo : IInterceptionBehavior
    {
        public bool WillExecute { get { return true; } }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine(this.GetType().Name+" Before");
            
            User user = input.Inputs[0] as User;
            if (user.Name.Length<=0)
            {
                //返回异常
                return input.CreateExceptionMethodReturn(new Exception("密码不得为空"));
            }
            else
            {
                Console.WriteLine(this.GetType().Name + " 密码检测正常");
                return getNext()(input, getNext);
            }

        
            
        }
    }
}
