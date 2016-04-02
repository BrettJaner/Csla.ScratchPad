using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Csla.ScratchPad.ServiceLayer
{
    public class TransactionalSaveHandler<T> : ISaveHandler<T>
    {
        private readonly ISaveHandler<T> _saveHandler;

        public TransactionalSaveHandler(ISaveHandler<T> saveHandler)
        {
            _saveHandler = saveHandler;
        }

        public async Task ExecuteAsync(T businessObject, Func<Task> doDataPortalCall)
        {
            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _saveHandler.ExecuteAsync(businessObject, doDataPortalCall).ConfigureAwait(false);

                ts.Complete();
            }
        }
    }
}