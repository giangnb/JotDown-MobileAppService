using Microsoft.Owin;
using Owin;

[assembly: OwinStartup( typeof( JotDown.MobileAppService.Startup ) )]

namespace JotDown.MobileAppService
{
    public partial class Startup
    {
        public void Configuration( IAppBuilder app )
        {
            ConfigureMobileApp( app );
        }
    }
}