
##### 发现问问题的人还挺多，赶紧补发一个收款码！！！

![image](https://raw.githubusercontent.com/zifeiniu/YinHaiYiBaoCSharpAPI/master/%E5%BE%AE%E4%BF%A1%E5%9B%BE%E7%89%87_20200311113458.jpg)
![image](https://github.com/AngelSXD/sxd_first_repository/blob/master/images/20160615165142.png)

## C#Model封装 银海医保的接口

### 介绍
银海医保的接口我就不说了，很多家医院在用，但是网上资料不多，接口通过COM组件调用。官方示例有VB，delphi，PB。

我们的HIS是B/S 程序，不能直接调用，所以通过此程序封装银海接口后，通过此程序调用。

当前程序是一个Asp.net mvc web api selfhost 做成一个桌面服务端，封装银海接口，浏览器通过使用JavaScript 请求调用。当然你也可以直接引用DLL，调用方法。


### .NET 调用COM 组件示例：

COM 组件调用方式如下：
```
int  Appcode = -1;
msg = string.Empty;
object[] args = new object[] { Appcode, msg };
yhObject = System.Activator.CreateInstance(yh);
ParameterModifier pm = new ParameterModifier(2);
pm[0] = true;
pm[1] = true;
ParameterModifier[] pmd = { pm };
yh.InvokeMember("yh_interface_init", BindingFlags.InvokeMethod, null,
	yhObject, args, pmd, System.Globalization.CultureInfo.CurrentCulture, null);

string o1 = args[0].ToString();
string o2 = args[1].ToString();
```

### 项目特点

银行的接口是通过组装XML来调用，而且xml都是这种prm_xxx 神奇的数字节点。。
我使用特性封装Model，调用方屏蔽掉xml中prm_xxx 这种神奇的数字，直接使用中文属性。
（使用中文Model当然也有缺点，只不过是我懒得封装上百个Model。直接使用代码生成器生成Model）

这样如果需要添加一个新的接口，可以在两分钟之内搞定。（只需要一键生成Model）

项目添加Mock方式，可以在没有环境的情况下模拟假数据。
也添加了测试环境，及Dump文件及日志等。直接使用dump的json重现错误。
不吹了。。


### 已知的坑

银海某些接口是返回的使用/t分隔的文本文件的，居然没有表头。我这边解析是通过反射解析，所以要注意model属性声明的顺序就是解析文本文件的顺序。。。顺序千万不能乱。

此项目主要是通过反射赋值，其实效率并不慢。当然你可以去优化了。。

不同的医保政策使用同一个接口，同一个model时，可能再不同的政策下，屏蔽某些属性。
这个只要在反射的时候过滤下就行，这个我还没做。因为我的项目所在医院目前只开了两个政策。

