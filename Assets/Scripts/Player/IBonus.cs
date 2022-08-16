using UnityEngine;

namespace Player
{
    public interface IBonus
    {
        public void StartUse(ModelLink modelLink, Animator animator);
    }
}
