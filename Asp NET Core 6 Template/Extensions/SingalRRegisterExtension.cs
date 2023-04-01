using Asp_NET_Core_6_Template.Hubs.Implementation;

namespace Asp_NET_Core_6_Template.Extensions
{
    public static class SingalRRegisterExtension
    {
        public static void RegisterHubs(this WebApplication app)
        {
            app.MapHub<TestHub>("hub/testhub");
        }
    }
}
