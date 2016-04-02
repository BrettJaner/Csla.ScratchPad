using System;
using System.Threading.Tasks;

using Csla.ScratchPad.ServiceLayer.Messages;

namespace Csla.ScratchPad.ServiceLayer
{
    public class MessageBrokerSaveHandler<T> : ISaveHandler<T>
    {
        private readonly ISaveHandler<T> _saveHandler;

        public MessageBrokerSaveHandler(ISaveHandler<T> saveHandler)
        {
            _saveHandler = saveHandler;
        }

        public async Task ExecuteAsync(T businessObject, Func<Task> doDataPortalCall)
        {
            await _saveHandler.ExecuteAsync(businessObject, doDataPortalCall).ConfigureAwait(false);

            var broker = new MessageBroker();

            broker.Publish(new Saved<T> { BusinessObject = businessObject });
        }
    }
}