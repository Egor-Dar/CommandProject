using CorePlugin.Extensions;
using UnityEngine;

namespace Panels
{
    public class PanelState
    {
        private CanvasGroup currentPanel;
        public CanvasGroup GetCurrentPanel() => currentPanel;

        public void SetPanel(CanvasGroup newPanel)
        {
            currentPanel?.ChangeGroupState(false);
            currentPanel = newPanel;
            currentPanel.ChangeGroupState(true);
        }
    }
}