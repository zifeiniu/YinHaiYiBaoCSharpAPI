using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.SelfHost;

namespace WebAPIServer
{

    public static class WebServer
    {
        static Uri _baseAddress;

        static HttpSelfHostServer server = null;

        public static bool StopWebServer()
        {
            try
            {
                if (server != null)
                {
                    server.CloseAsync();
                }
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }
        //string WebListenUrl = "http://localhost:54321/";
        public static bool StartWebServer(string Urladdress,out string msg)
        {
            msg = "";

            try
            {
                _baseAddress = new Uri(Urladdress);

                // Set up server configuration
                HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);
                config.MaxBufferSize = 65536 * 100;
                config.MaxReceivedMessageSize = 65536 * 100;


                //config.Routes.MapHttpRoute(
                //    name: "DefaultApi",
                //    routeTemplate: "api/{controller}/{id}",
                //    defaults: new { id = RouteParameter.Optional }
                //);

                config.Routes.MapHttpRoute(
                    name: "actionApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

                //启用跨站
                var cors = new EnableCorsAttribute("*", "*", "*");
                config.EnableCors(cors);

                // Create server
                server = new HttpSelfHostServer(config);
                

                // Start listening
                server.OpenAsync().Wait();
                msg = "服务启动成功..";

            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
                msg = "启动失败 ,可能服务已经启动,或端口被占用.." + ex.Message;
               return false;
            }catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
