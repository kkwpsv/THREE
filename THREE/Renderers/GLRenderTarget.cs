using System.Collections;
using THREE.Textures;

namespace THREE
{
    [Serializable]
    public class GLRenderTarget : DisposableObject, ICloneable
    {
        public bool IsGLMultiviewRenderTarget = false;

        public int NumViews = 0;

        public Texture Texture;

        public Hashtable Options;

        public int Width;

        public int Height;

        public Vector4 Scissor;

        public bool ScissorTest = false;

        public Vector4 Viewport;

        public bool depthBuffer;

        public bool stencilBuffer;

        public DepthTexture depthTexture;

        public GLRenderTarget(int width, int height, Hashtable options = null)
        {
            this.Width = width;

            this.Height = height;

            if (options != null)
            {
                this.Options = (Hashtable)options;
            }
            else
            {
                this.Options = new Hashtable();
            }

            Scissor = new Vector4(0, 0, width, height);
            ScissorTest = false;
            Viewport = new Vector4(0, 0, width, height);

            Texture = new Texture();

            Texture.Image = new Image
            {
                Width = Width,
                Height = Height,
            };

            Texture.WrapS = (int?)Options["wrapS"] ?? Constants.ClampToEdgeWrapping;
            Texture.WrapT = (int?)Options["wrapT"] ?? Constants.ClampToEdgeWrapping;
            Texture.MagFilter = (int?)Options["magFilter"] ?? Constants.LinearFilter;
            Texture.MinFilter = (int?)Options["minFilter"] ?? Constants.LinearMipmapLinearFilter;
            Texture.Format = (int?)Options["format"] ?? Constants.RGBAFormat;
            Texture.InternalFormat = null;
            Texture.Type = (int?)Options["type"] ?? Constants.UnsignedByteType;
            Texture.Anisotropy = (int?)Options["anisotropy"] ?? 1;
            Texture.Encoding = (int?)Options["encoding"] ?? Constants.LinearEncoding;

            Texture.GenerateMipmaps = Options["generateMipmaps"] != null ? (bool)Options["generateMipmaps"] : false;

            this.depthBuffer = Options["depthBuffer"] != null ? (bool)Options["depthBuffer"] : true;
            this.stencilBuffer = Options["stencilBuffer"] != null ? (bool)Options["stencilBuffer"] : true;
            this.depthTexture = Options["depthTexture"] != null ? (DepthTexture)Options["depthTexture"] : null;
        }

        protected GLRenderTarget(GLRenderTarget source)
        {
            this.Width = source.Width;
            this.Height = source.Height;

            Scissor = source.Scissor;
            ScissorTest = source.ScissorTest;
            this.Viewport = source.Viewport;


            this.Texture = (Texture)source.Texture.Clone();

            this.depthBuffer = source.depthBuffer;
            this.stencilBuffer = source.stencilBuffer;
            this.depthTexture = source.depthTexture;
        }

        public new object Clone()
        {
            return new GLRenderTarget(this);
        }

        public void SetSize(int width, int height)
        {
            if (this.Width != width || this.Height != height)
            {
                this.Width = width;
                this.Height = height;

                this.Texture.Image.Width = width;
                this.Texture.Image.Height = height;

            }
        }
    }
}
