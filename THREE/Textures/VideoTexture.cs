namespace THREE
{
    [Serializable]
    public class VideoTexture : Texture
    {
        public VideoTexture()
        {
            this.GenerateMipmaps = false;
        }

        public void Update()
        {
            this.NeedsUpdate = true;
        }
    }
}
