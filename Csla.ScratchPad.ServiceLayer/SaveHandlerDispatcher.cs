using System;
using System.Threading.Tasks;

namespace Csla.ScratchPad.ServiceLayer
{
    public class SaveHandlerDispatcher
    {
        private readonly Func<Type, object> _saveHandlerFactory;

        public SaveHandlerDispatcher(Func<Type, object> saveHandlerFactory)
        {
            _saveHandlerFactory = saveHandlerFactory;
        }

        public void Dispatch(object businessObject, Func<Task> doDataPortalCall)
        {
            dynamic saveHandler = _saveHandlerFactory(typeof(ISaveHandler<>).MakeGenericType(businessObject.GetType()));

            saveHandler.ExecuteAsync((dynamic)businessObject, doDataPortalCall);
        }
    }
}