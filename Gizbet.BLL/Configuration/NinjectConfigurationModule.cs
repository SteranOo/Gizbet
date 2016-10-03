using Gizbet.DAL.Interfaces;
using Gizbet.DAL.Repositories;
using Ninject.Modules;

namespace Gizbet.BLL.Configuration
{
    /// <summary>
    /// BLL Ninject Configuration Module
    /// </summary>
    public class NinjectConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
