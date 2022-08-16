using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Panels.Main.StorePanels
{
    [CreateAssetMenu(fileName = "Panel", menuName = "CardStore", order = 0)]
    public class CardVariant : ScriptableObject
    {
        [SerializeField] private InfoCards[] infoCards;
        public InfoCards GetCardInfo() => infoCards[Random.Range(0, infoCards.Length)];
    }
    [Serializable]
    public struct InfoCards
    {
        public Sprite sprite;
        public int cost;
    }
}