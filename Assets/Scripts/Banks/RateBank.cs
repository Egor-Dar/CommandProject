using System;
using Base;
using CorePlugin.Extensions;

namespace Banks
{
    public class RateBank : BaseBank
    {
        private BanksDelegates.GetRateCount getRateCount;

        protected override void Awake()
        {
            nameBank = "Rate";
            base.Awake();
        }

        private void Start()
        {
            getRateCount?.Invoke(Count);
        }

        protected override void Add(int count)
        {
            base.Add(count);
            getRateCount?.Invoke(Count);
        }

        protected override void Remove(int count)
        {
            base.Remove(count);
            getRateCount?.Invoke(Count);
        }

        public override Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (BanksDelegates.AddRate)Add,
                (BanksDelegates.RemoveRate)Remove
            };
        }

        public override void InvokeEvents()
        {
        }

        public override void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref getRateCount, subscribers);
        }

        public override void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref getRateCount, unsubscribers);
        }
    }
}