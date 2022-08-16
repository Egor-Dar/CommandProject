using System;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Base.InteractableObjects
{
    public class Pump : MonoBehaviour, IBonus
    {
        private void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.TryGetComponent(out IInteractable player)) return;
            player.SetBonus(this);
            
        }
        public void StartUse(ModelLink modelLink, Animator animator)
        {
            var localScale = modelLink.hand.localScale;
            modelLink.hand.transform.DOShakeScale(0.5f, new Vector3(.1f, .1f, .1f));
            modelLink.hand.localScale = new Vector3(
                Math.Clamp(localScale.x+0.5f, 1f, 5f),
                Math.Clamp(localScale.y+0.5f, 1f, 5f),
                Math.Clamp(localScale.z+0.5f, 1f, 5f));
            
            Destroy(gameObject);
        }
    }
}
