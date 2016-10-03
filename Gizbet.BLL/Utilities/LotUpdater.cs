using System;
using System.Threading;
using Gizbet.BLL.Infrastructure;
using Gizbet.DAL.Repositories;

namespace Gizbet.BLL.Utilities
{
    /// <summary>
    /// Class represents utility for updating lot state
    /// </summary>
    public static class LotUpdater
    {
        private static Timer _timer;

        /// <summary>
        /// Start updating utility
        /// </summary>
        public static void Start()
        {
            _timer = new Timer(Tick, null, 0, 1000);
        }

        /// <summary>
        /// Stop updating utility
        /// </summary>
        public static void Stop()
        {
            _timer.Dispose();
        }

        private static async void Tick(object obj)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var lots = unitOfWork.LotRepository.FindBy(l => !l.IsSold);
                    bool isChanged = false;
                    foreach (var lot in lots)
                    {
                        if (lot.TimeOfPosting.AddHours(lot.HoursDuration) < DateTime.Now)
                        {
                            lot.IsSold = isChanged = true;
                        }
                    }
                    if (isChanged)
                        await unitOfWork.SaveAsync();
                }
            }
            catch (Exception exception)
            {
                throw new GizbetBLLException("", exception);
            }
        }
    }
}
