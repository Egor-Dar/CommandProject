using UnityEngine;
using UnityEngine.UI;

namespace Panels.Main
{
    public class SettingsPanel : PanelBase
    {
        [SerializeField] private Button musicButton;
        [SerializeField] private Button soundButton;

        protected override void Start()
        {
            base.Start();
            musicButton.onClick.AddListener(OnMusic);
            soundButton.onClick.AddListener(OnSound);
        }

        private void OnSound() => Debug.Log("Sound");
        private void OnMusic() => Debug.Log("Music");
    }
}