using UnityEngine;
using UnityEngine.Scripting;
using Object = UnityEngine.Object;

namespace Player
{
    public class SkinChanger
    {
        private ModelLink _prefabSkin;
        private ModelLink _currentSkin;
        public ModelLink GetCurrentModel() => _currentSkin;

        public void SetSkin(ModelLink newSkin, Animator animator)
        {
            if (_prefabSkin == newSkin) return;
            if (_currentSkin != null) Object.Destroy(_currentSkin.gameObject);
            animator.avatar = null;
            _prefabSkin = newSkin;
            _currentSkin = Object.Instantiate(newSkin, animator.transform);
            animator.enabled = false;
            animator.avatar = newSkin.avatar;
            animator.enabled = true;
            animator.Rebind();
        }
    }
}
