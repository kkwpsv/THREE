
namespace THREE
{
    [Serializable]
    public class DataTexture : Texture
    {
        public DataTexture()
        {
            GenerateMipmaps = false;
            FlipY = false;
            UnpackAlignment = 1;
        }
    }
}
