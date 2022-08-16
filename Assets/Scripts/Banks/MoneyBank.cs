using System;
using Base;
using CorePlugin.Extensions;

namespace Banks
{
    public class MoneyBank : BaseBank
    {
        private BanksDelegates.GetMoneyCount getMoneyCount;

        protected override void Awake()
        {
            nameBank = "Money";
            base.Awake();
        }

        private void Start()
        {
            getMoneyCount?.Invoke(Count);
        }

        protected override void Add(int count)
        {
            base.Add(count);
            getMoneyCount?.Invoke(Count);
        }

        protected override void Remove(int count)
        {
            base.Remove(count);
            getMoneyCount?.Invoke(Count);
        }

        public override Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (BanksDelegates.AddMoney)Add,
                (BanksDelegates.RemoveMoney)Remove
            };
        }

        public override void InvokeEvents()
        {
        }

        public override void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref getMoneyCount, subscribers);
        }

        public override void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref getMoneyCount, unsubscribers);
        }
    }
}