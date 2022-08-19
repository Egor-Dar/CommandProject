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
        [SerializeField][CanBeNull] private Image rateImage;
        [SerializeField] private TextMeshProUGUI moneyText;

        private void GetMoney(int count)
        {
            moneyText.text = count.ToString();
        }

        private void GetRate(int count)
        {
            if(rateImage == null) return;
            var t = Mathf.InverseLerp(0, 100000, count);
            rateImage.fillAmount = Mathf.Lerp(0, 1, t);
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