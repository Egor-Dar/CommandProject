using UnityEngine;

namespace Player
{
    public class PlayerPlayableData : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private ModelLink defaultSkin;
        public Animator GetAnimator() => animator;
        public ModelLink GetDefaultSkin() => defaultSkin;
    }
}
