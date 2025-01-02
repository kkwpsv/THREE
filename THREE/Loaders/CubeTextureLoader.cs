using THREE.Textures;

namespace THREE
{
    public class CubeTextureLoader
    {
        public static CubeTexture Load(List<string> filePath)
        {
            if (filePath.Count != 6)
            {
                throw new Exception("File count should be 6");
            }
            var images = new Image[6];
            for (int i = 0; i < filePath.Count; i++)
            {
                images[i] = TextureLoader.LoadImage(filePath[i], StbImageSharp.ColorComponents.RedGreenBlueAlpha);
            }
            CubeTexture texture = new CubeTexture
            {
                Images = images,
            };
            texture.NeedsUpdate = true;
            return texture;
        }
    }
}
