using UnityEngine;
using UnityEngine.UI;

namespace Panels.Main.StorePanels
{
    public class FreePanel : MonoBehaviour
    {
        [SerializeField] private Wildcard wildcard;
        [SerializeField] private Button freeSpinButton;
        [SerializeField] private CardVariant cardVariant;
        private CellStoreState cellStoreState;

        private void Start()
        {
            cellStoreState = new CellStoreState();
            freeSpinButton.onClick.AddListener(NewCard);
        }

        private void NewCard() => cellStoreState.SetNewCard(wildcard, cardVariant.GetCardInfo());
    }
}