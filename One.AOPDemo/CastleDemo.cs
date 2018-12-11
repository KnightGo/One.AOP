using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.AOPDemo
{
    public class CastleDemo : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Before Action");
            invocation.Proceed();
            Console.WriteLine("After Action");

        }
    }
}
