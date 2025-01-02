using THREE.Textures;

namespace THREE
{
    public class CubeTexture : Texture
    {
        public Image[]? Images { get; set; }

        public DataTexture[]? Textures { get; set; }

        public CubeTexture()
        {
            Mapping = Constants.CubeReflectionMapping;
            Format = Constants.RGBAFormat;

            FlipY = false;
        }
    }
}
