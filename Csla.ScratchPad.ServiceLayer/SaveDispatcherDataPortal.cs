using System;
using System.Threading.Tasks;

using Csla.Server;

namespace Csla.ScratchPad.ServiceLayer
{
    public class SaveDispatcherDataPortal : IDataPortalServer
    {
        private readonly SaveHandlerDispatcher _dispatcher;

        public SaveDispatcherDataPortal(SaveHandlerDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public Task<DataPortalResult> Create(Type objectType, object criteria, DataPortalContext context, bool isSync)
        {
            var dp = new SimpleDataPortal();
            return dp.Create(objectType, criteria, context, isSync);
        }

        public Task<DataPortalResult> Delete(Type objectType, object criteria, DataPortalContext context, bool isSync)
        {
            var dp = new SimpleDataPortal();
            return dp.Delete(objectType, criteria, context, isSync);
        }

        public Task<DataPortalResult> Fetch(Type objectType, object criteria, DataPortalContext context, bool isSync)
        {
            var dp = new SimpleDataPortal();
            return dp.Fetch(objectType, criteria, context, isSync);
        }

        public Task<DataPortalResult> Update(object obj, DataPortalContext context, bool isSync)
        {
            var dp = new SimpleDataPortal();

            Task<DataPortalResult> result = null;

            _dispatcher.Dispatch(obj, () => result = dp.Update(obj, context, isSync));

            if (result == null)
                throw new InvalidOperationException("SaveHandlerDispatcher.Dispatch never called doDataPortalCall.");

            return result;
        }
    }
}