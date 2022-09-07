namespace Player
{
    public interface ISkinned
    {
        public ModelLink GetCurrentModel();
        public void ListNextSkin();
        public void ListPreviousSkin();
    }
}
