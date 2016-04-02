using System;
using System.Threading.Tasks;

namespace Csla.ScratchPad.ServiceLayer
{
    public class DataPortalSaveHandler<T> : ISaveHandler<T>
    {
        public Task ExecuteAsync(T businessObject, Func<Task> doDataPortalCall)
        {
            return doDataPortalCall();
        }
    }
}