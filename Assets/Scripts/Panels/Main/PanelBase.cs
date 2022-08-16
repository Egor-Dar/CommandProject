using CorePlugin.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.Main
{
    public abstract class PanelBase : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        private CanvasGroup currentPanel;

        protected virtual void Start()
        {
            currentPanel = GetComponent<CanvasGroup>();
            closeButton.onClick.AddListener(OnClose);
        }

        protected virtual void OnClose() => currentPanel.ChangeGroupState(false);
    }
}