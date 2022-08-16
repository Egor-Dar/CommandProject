using System;
using Base;
using CorePlugin.Extensions;

namespace Banks
{
    public class UniqueBank : BaseBank
    {
        private BanksDelegates.GetUniqueCount getUniqueCount;

        protected override void Awake()
        {
            nameBank = "Unique";
            base.Awake();
        }

        private void Start()
        {
            getUniqueCount?.Invoke(Count);
        }

        protected override void Add(int count)
        {
            base.Add(count);
            getUniqueCount?.Invoke(Count);
        }

        protected override void Remove(int count)
        {
            base.Remove(count);
            getUniqueCount?.Invoke(Count);
        }

        public override Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (BanksDelegates.AddUnique)Add,
                (BanksDelegates.RemoveUnique)Remove
            };
        }

        public override void InvokeEvents()
        {
        }

        public override void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref getUniqueCount, subscribers);
        }

        public override void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref getUniqueCount, unsubscribers);
        }
    }
}