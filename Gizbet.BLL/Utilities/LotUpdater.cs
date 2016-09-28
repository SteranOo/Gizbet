using System;
using System.Threading;
using Gizbet.DAL.Repositories;

namespace Gizbet.BLL.Utilities
{
    public static class LotUpdater
    {
        private static UnitOfWork _unitOfWork;
        private static Timer _timer;

        public static void Start()
        {
            _timer = new Timer(Tick, null, 0, 1000);
        }

        public static void Stop()
        {
            _timer.Dispose();
        }

        static void Tick(object obj)
        {
            _unitOfWork = new UnitOfWork();
            var lots = _unitOfWork.LotRepository.FindBy(l => !l.IsSold);
            bool isChanged = false;
            foreach (var lot in lots)
            {
                if (lot.TimeOfPosting.AddHours(lot.HoursDuration) < DateTime.Now)
                {
                    lot.IsSold = isChanged = true;
                }
            }
            if (isChanged)
               _unitOfWork.SaveAsync().Wait();
        }
    }
}
