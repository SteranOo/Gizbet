using System;
using Gizbet.BLL.Interfaces;
using Gizbet.DAL.Interfaces;

namespace Gizbet.BLL.Services
{
    public class GeneralService : IService
    {
        private bool _isDisposed;

        protected IUnitOfWork _unitOfWork;

        public GeneralService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~GeneralService()
        {
            Dispose(false);
        }
    }
}
