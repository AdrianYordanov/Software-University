namespace WebServer.Application
{
    using Controllers;
    using Server.Contracts;
    using Server.Routing.Contracts;

    public class MainApplication : IApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", request => new HomeController().Index());
            appRouteConfig.Post("/register", request => new UserController().RegisterPost(request.FormData["name"]));
            appRouteConfig.Get("/register", request => new UserController().RegisterGet());
            appRouteConfig.Get("/user/{(?<name>[a-z]+)}",
                request => new UserController().Details(request.UrlParameters["name"]));
        }
    }
}