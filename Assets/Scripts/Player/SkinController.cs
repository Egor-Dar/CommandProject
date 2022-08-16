namespace Player
{
    public class SkinController : ISkinned
    {
        private PlayerPlayableData _data;
        private SkinChanger _skinChanger;
        public SkinController(PlayerPlayableData data)
        {
            _data = data;
            _skinChanger = new SkinChanger();
            _skinChanger.SetSkin(data.GetDefaultSkin(), data.GetAnimator());
        }

        public ModelLink GetCurrentModel() => _skinChanger.GetCurrentModel();
        public void SkinDefault()
        {
            _skinChanger.SetSkin(_data.GetDefaultSkin(), _data.GetAnimator());
        }
    }
}
