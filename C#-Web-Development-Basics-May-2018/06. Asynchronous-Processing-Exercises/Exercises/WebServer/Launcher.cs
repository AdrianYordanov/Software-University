namespace WebServer
{
    using Application;
    using Server;
    using Server.Contracts;
    using Server.Routing;

    public class Launcher : IRunnable
    {
        private const int Port = 8230;

        public void Run()
        {
            var app = new MainApplication();
            var routeConfig = new AppRouteConfig();
            app.Configure(routeConfig);
            var webServer = new WebServer(Port, routeConfig);
            webServer.Run();
        }

        private static void Main()
        {
            new Launcher().Run();
        }
    }
}