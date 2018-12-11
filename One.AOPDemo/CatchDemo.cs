using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace One.AOPDemo
{
    public class CatchDemo : IInterceptionBehavior
    {
        public bool WillExecute { get { return true; } }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
        private static Dictionary<string, object> CatchingDic = new Dictionary<string, object>();

        /// <summary>
        /// 通过容器注入,实现AOP,模拟读取缓存
        /// </summary>
        /// <param name="input">参数</param>
        /// <param name="getNext">next执行函数</param>
        /// <returns></returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine(this.GetType().Name);
            string ket = $"{input.MethodBase.Name}_{Newtonsoft.Json.JsonConvert.SerializeObject(input.Inputs)}";
            if (CatchingDic.ContainsKey(ket))
            {
                //断路器 获取缓存数据
                Console.WriteLine("断路器"+CatchingDic[ket]);
                return input.CreateMethodReturn(CatchingDic[ket]);
            }
            else
            {
                //执行核心方法
                IMethodReturn result= getNext()(input, getNext);
                //判断返回值不为空,存入缓存字典
                if(result.ReturnValue!=null)
                 CatchingDic.Add(ket, result.ReturnValue);
                return result;
            }
        }
    }
}
