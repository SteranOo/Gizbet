using Gizbet.DAL.Interfaces;
using Gizbet.DAL.Repositories;
using Ninject.Modules;

namespace Gizbet.BLL.Configuration
{
    public class NinjectConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
