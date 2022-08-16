using System;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace Banks
{
    public abstract class BaseBank : MonoBehaviour, IEventSubscriber, IEventHandler
    {
        protected int Count;
        protected string nameBank;


        protected virtual void Awake()
        {
            Count = PlayerPrefs.GetInt(nameBank);
        }

        protected virtual void Add(int count)
        {
            if (count < 0)
            {
                Debug.LogError(
                    "The argument cannot be less than 0," +
                    "please check the code for errors or use the method RemoveMoney");
                return;
            }

            Count += count;
            PlayerPrefs.SetInt(nameBank, Count);
        }

        protected virtual void Remove(int count)
        {
            if (count > 0)
            {
                Debug.LogError("The argument cannot be more than 0," +
                               "please check the code for errors or use the method AddMoney");
                return;
            }
            
            Count -= count;
            PlayerPrefs.SetInt(nameBank, Count);
        }

        public abstract Delegate[] GetSubscribers();
        public abstract void InvokeEvents();

        public abstract void Subscribe(params Delegate[] subscribers);

        public abstract void Unsubscribe(params Delegate[] unsubscribers);
    }
}