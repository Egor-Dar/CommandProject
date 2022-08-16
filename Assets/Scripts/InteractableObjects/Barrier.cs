using System;
using System.Threading.Tasks;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Base.InteractableObjects
{
    public class Barrier : MonoBehaviour, IBonus
    {
        private void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.TryGetComponent(out IInteractable player)) return;
            player.SetBonus(this);
            
        }
        public async void StartUse(ModelLink modelLink, Animator animator)
        {
            animator.SetLayerWeight(1,1);
            var localScale = modelLink.hand.localScale;
            modelLink.hand.transform.DOShakeScale(0.5f, new Vector3(-.1f, -.1f, -.1f));
            modelLink.hand.localScale = new Vector3(
                Math.Clamp(localScale.x-1f, 1f, 5f),
                Math.Clamp(localScale.y-1f, 1f, 5f),
                Math.Clamp(localScale.z-1f, 1f, 5f));
            await Task.Delay(500);
            animator.SetLayerWeight(1, 0);
            Destroy(gameObject);
        }
    }
}
