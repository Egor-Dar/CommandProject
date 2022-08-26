using TMPro;
using UnityEngine;

namespace Base
{
    public static class PlayerDelegates
    {
        public delegate void SetTransform(Transform newTransform);
        public delegate void Death();
        public delegate void Movement(float speed);
        public delegate Transform GetEndPoint();
        public delegate void EndLevel();
    }

    public static class PanelsGeter
    {
        public delegate Joystick GetJoystick();

        public delegate TextMeshProUGUI GetMoneyText();

        public delegate int GetRate();
    }

    public static class BanksDelegates
    {
        #region MoneyBank

        public delegate void GetMoneyCount(int count);

        public delegate void AddMoney(int count);

        public delegate void RemoveMoney(int count);

        #endregion

        #region RateBank

        public delegate void GetRateCount(int count);
        public delegate void AddRate(int count);
        public delegate void RemoveRate(int count);

        #endregion

        #region UniqueBank

        public delegate void GetUniqueCount(int count);
        public delegate void AddUnique(int count);
        public delegate void RemoveUnique(int count);

        #endregion

    }

    public static class MainDelegates
    {
        public delegate void GoToPlay();
        public delegate void GoToStore();
    }

    public static class GameDelegates
    {
        public delegate void OnStart();
        public delegate void ShopOpenClose();
    }
   
}