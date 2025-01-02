using System;

namespace THREE
{
    [Serializable]
    public class DepthTexture : Texture
    {
        public DepthTexture(int width, int height, int format = Constants.DepthFormat)
        {
            if (format != Constants.DepthFormat && format != Constants.DepthStencilFormat)
            {
                throw new Exception("DepthTexture format must be either Constants.DepthFormat or Constants.DepthStencilFormat");
            }

            Format = format;

            if (Format == Constants.DepthFormat)
            {
                Type = Constants.UnsignedIntType;
            }
            else if (Format == Constants.DepthStencilFormat)
            {
                Type = Constants.UnsignedInt248Type;
            }

            Image = new Textures.Image
            {
                Width = width,
                Height = height,
            };

            MinFilter = Constants.NearestFilter;
            MaxFilter = Constants.NearestFilter;

            FlipY = false;
            GenerateMipmaps = false;
        }
    }
}
