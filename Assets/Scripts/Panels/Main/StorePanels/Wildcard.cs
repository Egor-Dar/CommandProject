using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.Main.StorePanels
{
    public class Wildcard : MonoBehaviour
    {
        [SerializeField] private Image imageComponent;
        [SerializeField] private TextMeshProUGUI costText;
        private Sprite sprite;
        private int cost;

        public void SetNewInfo(Sprite newSprite, int newCost)
        {
            sprite = newSprite;
            cost = newCost;
            imageComponent.sprite = sprite;
            costText.text = cost.ToString();
        }
    }
}