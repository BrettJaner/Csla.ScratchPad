using System;

namespace Csla.ScratchPad.BusinessLayer
{
    [Serializable]
    public class Order : BusinessBase<Order>
    {
        private readonly static PropertyInfo<int> OrderIdProperty = RegisterProperty<int>(x => x.OrderId);

        public int OrderId
        {
            get { return GetProperty(OrderIdProperty); }
        }

        public static Order NewOrder()
        {
            return DataPortal.Create<Order>();
        }

        public static Order GetOrder(int orderId)
        {
            return DataPortal.Fetch<Order>(orderId);
        }

        [RunLocal]
        protected override void DataPortal_Create()
        {
            BusinessRules.CheckRules();
        }

        private void DataPortal_Fetch(int orderId)
        {
            LoadProperty(OrderIdProperty, orderId);
        }

        protected override void DataPortal_Insert()
        {
            DoInsertUpdate();
        }

        protected override void DataPortal_Update()
        {
            DoInsertUpdate();
        }

        private void DoInsertUpdate()
        {
        }
    }
}