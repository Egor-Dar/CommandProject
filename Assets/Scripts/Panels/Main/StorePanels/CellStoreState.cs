using JetBrains.Annotations;

namespace Panels.Main.StorePanels
{
    public class CellStoreState
    {
        private Wildcard _currentCard;

        public void SetNewCard([CanBeNull] Wildcard newCard, InfoCards infoCards)
        {
            if (newCard != null) _currentCard = newCard;
            _currentCard.SetNewInfo(infoCards.sprite, infoCards.cost);
        }
    }
}