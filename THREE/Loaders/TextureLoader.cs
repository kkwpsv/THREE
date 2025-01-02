using Pfim;
using StbImageSharp;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using THREE.Textures;

namespace THREE
{
    public class TextureLoader
    {
        public static Texture LoadDDS(string filePath)
        {
            var image = Pfimage.FromFile(filePath);
            var texture = new Texture();
            texture.Image = new Image
            {
                Data = image.Data,
                Width = image.Width,
                Height = image.Height,
            };
            texture.Format = Constants.RGBFormat;
            texture.NeedsUpdate = true;

            return texture;
        }
        public static Texture Load(string filePath)
        {
            Texture texture = new Texture();
            texture.Image = LoadImage(filePath, ColorComponents.RedGreenBlueAlpha);
            texture.Format = Constants.RGBAFormat;
            texture.NeedsUpdate = true;
            return texture;
        }

        public static Texture LoadEmbedded(string EmbeddedPath)
        {
            string embeddedNameBase = "THREE.Resources.";
            //Bitmap bitmap = new Bitmap(typeof(THREE.Object3D).GetTypeInfo().Assembly.GetManifestResourceStream(embeddedNameBase + EmbeddedPath));

            //bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            Texture texture = new Texture();
            texture.Image = LoadImage(embeddedNameBase + EmbeddedPath, ColorComponents.RedGreenBlue);
            texture.Format = Constants.RGBFormat;
            texture.NeedsUpdate = true;

            return texture;
        }

        public static Image LoadImage(string filePath, ColorComponents colorComponents)
        {
            using var file = File.OpenRead(filePath);
            StbImageSharp.StbImage.stbi_set_flip_vertically_on_load(1);
            var result = ImageResult.FromStream(file, colorComponents);
            if (result == null)
            {
                throw new Exception($"Load Texture Failed: {filePath}");
            }
            return new Image
            {
                Width = result.Width,
                Height = result.Height,
                Data = result.Data,
            };
        }
    }
}
