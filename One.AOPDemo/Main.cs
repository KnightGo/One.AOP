namespace One.AOPDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using One.AOPDemo;
    using Castle.DynamicProxy;
    using log4net;
    using Unity;
    using Vanilla;
    using System.Configuration;
    using System.IO;
    using Microsoft.Practices.Unity.Configuration;

    internal class Main
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        internal static async Task Work(string[] args)
        {
            await Task.FromResult(0);
            
            User userModel = new User { Id = 1, Name = "程序员", Pwd = "HelloWord123" };

            #region 静态AOP
            ////装饰器模式+组合实现AOP
            //{
            //    IUser user = new User();
            //    user = new DecoratorDemo(user);
            //    user.RegUser(userModel);
            //}
            ////代理模式
            //{
            //    ProxyDemo proxy = new ProxyDemo();
            //    proxy.RegUser(userModel);
            //}

            #endregion

            #region 动态AOP
            ////使用Net.Remoting生成动态类型，使用动态代理的方式调用(核心类必须实现 MarshalByRefObject)
            //{
            //    User user = TransparentProxy.Create<User>();
            //    user.RegUser(userModel);
            //}
            ////使用Castle/Emit生成 (核心方法必须为虚方法)
            //{
            //    ProxyGenerator proxy = new ProxyGenerator();
            //    CastleDemo castleDemo = new CastleDemo();
            //    User user = proxy.CreateClassProxy<User>(castleDemo);
            //    user.RegUser(userModel);

            //}
            ////Unity 代码注册方式
            //{
            //    IUnityContainer container = new UnityContainer();
            //    container.RegisterType<IUser, User>();
            //    IUser user = container.Resolve<IUser>();
            //    user.RegUser(userModel);

            //}
            //Unity 配置文件注册+模拟缓存AOP方法
            //{
            //    try
            //    {

            //        IUnityContainer container = UnityFactory.CreateUnityInit();
            //        IUser user = container.Resolve<IUser>();
            //        user.RegUser(userModel);

            //        IUnityContainer container2 = UnityFactory.CreateUnityInit();
            //        IUser user2 = container2.Resolve<IUser>();
            //        user2.RegUser(userModel);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            #endregion
            

        }
    }
}
