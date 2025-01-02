using System;
using System.Collections.Generic;
using System.Text;

namespace THREE.Textures
{
    public class FramebufferTexture : Texture
    {
        public FramebufferTexture(int width, int height)
        {
            MagFilter = Constants.NearestFilter;
            MinFilter = Constants.NearestFilter;

            GenerateMipmaps = false;

            NeedsUpdate = true;
        }
    }
}
