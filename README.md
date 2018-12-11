# One.AOP
使用.Net.Remoting、RealProxy、Unity多种方式实现静态、动态AOP


OOP：面向对象编程
特点：一切皆对象，任何东西都抽象成一个类，对象交互组成一个功能模块，模块叠加组成一个系统，面向对象适用于大型系统。
弊端：因为面向对象的对象是静态的，任何需求的细微变化，都可能导致比较大的影响，在应对需求变化的时候，比较困难;
解决：

1、设计出灵活、可重用的架构，可解决部分问题（抽象/类）

2、使用面向切面思想（AOP）解决类的内部变化

AOP：面向切面编程
面向切面编程（编程思想），是对OOP面向对象编程的一种补充，解决类的内部变化问题，能做到让开发者动态的修改一个静态的面向对象模型，在不破坏封装的前提下，去增加各种功能：非业务逻辑，是一些公共逻辑的模块


实现方式：

静态AOP：

（1）装饰器模式+组合/代理模式  
局限：不灵活 必须为每个类声明一个装饰器方法实现继承核心业务
动态AOP：

（1）Remote/RealProxy代理+组合
     局限：核心业务类 必须继承 MarshalByRefObject 
     
（2）Castle/DynamicProxy 使用emit动态反射
    局限：核心业务方法必须为虚方法才能生成调用
    
（3）Unity+Attribute 容器+特性
   局限：注册过程面向细节，注册过程繁琐；可以使用配置文件方式实现批量注册，面向抽象同时可以通过该方法可以更好实现IOC控制反转；

Unity+Config实现步骤：

0、添加NuGet包：Unity、Unity.Interception

1、配置Config文件 container

2、核心方法执行前或执行后的公共类，类实现IInterceptionBehavior

3、实现接口方法，在Invoke方法中调用方法

4、IMethodReturn methodReturn = getNext().Invoke(input,getNext);执行核心方法，在该语句前后执行其他业务逻辑实现AOP

5、通过配置文件信息，注册实例，实现AOP

多个AOP函数执行顺序：

