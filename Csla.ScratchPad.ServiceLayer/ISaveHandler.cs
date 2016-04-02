using System;
using System.Threading.Tasks;

namespace Csla.ScratchPad.ServiceLayer
{
    public interface ISaveHandler<T>
    {
        Task ExecuteAsync(T businessObject, Func<Task> doDataPortalCall);
    }
}