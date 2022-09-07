using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerPlayableData : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private ModelLink defaultSkin;
        [SerializeField] private ModelLink[] allSkins;
        private List<ModelLink> _allSkins;
        public List<ModelLink>  GetSkins() => _allSkins;
        public Animator GetAnimator() => animator;
        public ModelLink GetDefaultSkin() => defaultSkin;
        public void SetDefaultSkin(ModelLink skin)
        {
            defaultSkin = skin;
            animator.avatar = defaultSkin.avatar;
        }
        private void Awake()
        {
            _allSkins = new List<ModelLink>(allSkins.Length);
            foreach (ModelLink skin in allSkins)
            {
                _allSkins.Add(skin);
            }
            animator.avatar = defaultSkin.avatar;
        }
    }
}
