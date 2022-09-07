using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.Main
{
    public class UpPanel : MonoBehaviour, IEventSubscriber
    {
        [SerializeField][CanBeNull] private TextMeshProUGUI[] rateText= new TextMeshProUGUI[2];
        [SerializeField] private TextMeshProUGUI moneyText;

        private void GetMoney(int count)
        {
            moneyText.text = count.ToString();
        }

        private void GetRate(int count)
        {
            if(rateText == null) return;
            int b = -1;
            foreach (TextMeshProUGUI t in rateText)
            {
                int minusCount = count + b;
                t.text = minusCount < 0 ? "" : minusCount.ToString();
                b++;
            }
            rateText[^1].text = $"level {count}";
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (BanksDelegates.GetMoneyCount) GetMoney,
                (BanksDelegates.GetRateCount) GetRate,
            };
        }
    }
}