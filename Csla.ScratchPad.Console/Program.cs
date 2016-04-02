using SimpleInjector;

using Csla.ScratchPad.BusinessLayer;
using Csla.ScratchPad.ServiceLayer;

namespace Csla.ScratchPad.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.Register(typeof(ISaveHandler<>), typeof(DataPortalSaveHandler<>));
            container.RegisterDecorator(typeof(ISaveHandler<>), typeof(MessageBrokerSaveHandler<>));
            container.RegisterDecorator(typeof(ISaveHandler<>), typeof(TransactionalSaveHandler<>));

            Csla.Server.DataPortalSelector.DataPortalServer = 
                new SaveDispatcherDataPortal(
                    new SaveHandlerDispatcher(container.GetInstance));

            var order = Order.NewOrder();

            order.Save();
        }
    }
}
