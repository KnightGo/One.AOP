using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace One.AOPDemo
{
    /// <summary>
    /// 真实代理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RealProxyDemo<T> : RealProxy
    {
        private T tTarget;
        public RealProxyDemo(T target):base(typeof(T))
        {
            this.tTarget = target;
        }
        /// <summary>
        /// 调用核心业务逻辑
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            Console.WriteLine("Before Action");
            IMethodCallMessage call = (IMethodCallMessage)msg;
            object value = call.MethodBase.Invoke(this.tTarget, call.Args);
            Console.WriteLine("After Action");
            return new ReturnMessage(value, new object[0], 0, null, call);
        }
    }

    /// <summary>
    /// 透明代理
    /// </summary>
    public static class TransparentProxy
    {
        public static T Create<T>()
        {
            T instance = Activator.CreateInstance<T>();
            RealProxyDemo<T> realProxy = new RealProxyDemo<T>(instance);
            T transparentProxy = (T)realProxy.GetTransparentProxy();
            return transparentProxy;
        }
    }
}
