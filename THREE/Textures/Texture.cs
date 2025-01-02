using THREE.Textures;

namespace THREE
{
    [Serializable]
    public class MipMap
    {
        public byte[] Data;

        public int Width;

        public int Height;

        public MipMap() { }

        public MipMap(MipMap other)
        {
            if (other.Data.Length > 0)
                this.Data = other.Data.ToArray();
        }
        public MipMap Clone()
        {
            return new MipMap(this);
        }
    }

    [Serializable]
    public class Texture : DisposableObject, ICloneable
    {
        #region Static Fields

        private static int TextureIdCount;

        #endregion

        #region Fields

        public int Id { get; } = TextureIdCount++;

        public Guid Uuid { get; } = Guid.NewGuid();

        public string Name { get; set; } = "";

        public Image? Image { get; set; }

        public List<MipMap> Mipmaps { get; set; } = new List<MipMap>();

        public int Mapping { get; set; } = Constants.UVMapping;

        public int WrapS { get; set; } = Constants.ClampToEdgeWrapping;
        public int WrapT { get; set; } = Constants.ClampToEdgeWrapping;
        public int WrapR { get; set; }

        public int MagFilter { get; set; } = Constants.LinearFilter;
        public int MinFilter { get; set; } = Constants.LinearMipMapLinearFilter;
        public int MaxFilter { get; set; }

        public float Anisotropy { get; set; } = 1;

        public int Format { get; set; } = Constants.RGBAFormat;

        public int Type { get; set; } = Constants.UnsignedByteType;

        public Vector2 Offset { get; set; } = new Vector2(0, 0);
        public Vector2 Repeat { get; set; } = new Vector2(1, 1);
        public Vector2 Center { get; set; } = new Vector2(0, 0);
        public float Rotation { get; set; } = 0;

        public bool MatrixAutoUpdate = true;
        public Matrix3 Matrix { get; set; } = new Matrix3();

        public bool GenerateMipmaps { get; set; } = true;
        public bool PremultiplyAlpha { get; set; } = false;
        public bool FlipY { get; set; } = false; // seem to not work now
        public int UnpackAlignment { get; set; } = 4;

        private bool _needsUpdate;

        public bool NeedsUpdate
        {
            get { return _needsUpdate; }
            set
            {
                _needsUpdate = value;
                if (value == true) Version++;
            }
        }

        public string? InternalFormat { get; set; } = null;

        public int Encoding { get; set; } = Constants.LinearEncoding;

        public int Version { get; private set; } = 0;

        private readonly int defaultMapping = Constants.UVMapping;

        public bool NeedsFlipEnvMap { get; set; } = false;
        #endregion

        #region Constructors and Destructors

        public Texture()
        {
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="other"></param>
        protected Texture(Texture other) : this()
        {
            this.Mipmaps = other.Mipmaps;
            //this.Mipmaps = other.Mipmaps.Select(item => (MipMap)item.Clone()).ToList();

            this.Mapping = other.Mapping;

            this.WrapS = other.WrapS;
            this.WrapT = other.WrapT;

            this.MagFilter = other.MagFilter;
            this.MinFilter = other.MinFilter;

            this.Anisotropy = other.Anisotropy;

            this.Format = other.Format;
            this.InternalFormat = other.InternalFormat;
            this.Type = other.Type;

            this.Encoding = other.Encoding;

            this.Version = other.Version;
        }

        #endregion

        public void UpdateMatrix()
        {
            Matrix.SetUvTransform(Offset.X, Offset.Y, Repeat.X, Repeat.Y, Rotation, Center.X, Center.Y);
        }

        public virtual object Clone()
        {
            return new Texture(this);
        }
    }
}
