namespace Player
{
    public class AnimatorController : IAnimatable
    {
        private PlayerPlayableData _data;
        private string _isDie = "isDie";
        private string _isPaused = "isPaused";

        public AnimatorController(PlayerPlayableData data)
        {
            _data = data;
        }
        public void End()
        {
            _data.GetAnimator().SetBool(_isDie, true); 
        }
        public void Paused(bool value)
        {

            _data.GetAnimator().SetBool(_isPaused, value);
        }

    }
}
