using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THREE
{
    [Serializable]
    public class Constants
    {
        public static string REVISION = "121";
        public enum MOUSE { LEFT = 0, MIDDLE = 1, RIGHT = 2, ROTATE = 0, DOLLY = 1, PAN = 2 };
        public enum TOUCH { ROTATE = 0, PAN = 1, DOLLY_PAN = 2, DOLLY_ROTATE = 3 };
        public const int LineStrip = 0;
        public const int LinePieces = 1;
        public const int CullFaceNone = 0;
        public const int CullFaceBack = 1;
        public const int CullFaceFront = 2;
        public const int CullFaceFrontBack = 3;
        public const int FrontFaceDirectionCW = 0;
        public const int FrontFaceDirectionCCW = 1;
        public const int BasicShadowMap = 0;
        public const int PCFShadowMap = 1;
        public const int PCFSoftShadowMap = 2;
        public const int VSMShadowMap = 3;
        public const int FrontSide = 0;
        public const int BackSide = 1;
        public const int DoubleSide = 2;
        public const int FlatShading = 1;
        public const int SmoothShading = 2;
        public const int NoColors = 0;
        public const int FaceColors = 1;
        public const int VertexColors = 2;
        public const int NoBlending = 0;
        public const int NormalBlending = 1;
        public const int AdditiveBlending = 2;
        public const int SubtractiveBlending = 3;
        public const int MultiplyBlending = 4;
        public const int CustomBlending = 5;
        public const int AddEquation = 100;
        public const int SubtractEquation = 101;
        public const int ReverseSubtractEquation = 102;
        public const int MinEquation = 103;
        public const int MaxEquation = 104;
        public const int ZeroFactor = 200;
        public const int OneFactor = 201;
        public const int SrcColorFactor = 202;
        public const int OneMinusSrcColorFactor = 203;
        public const int SrcAlphaFactor = 204;
        public const int OneMinusSrcAlphaFactor = 205;
        public const int DstAlphaFactor = 206;
        public const int OneMinusDstAlphaFactor = 207;
        public const int DstColorFactor = 208;
        public const int OneMinusDstColorFactor = 209;
        public const int SrcAlphaSaturateFactor = 210;
        public const int NeverDepth = 0;
        public const int AlwaysDepth = 1;
        public const int LessDepth = 2;
        public const int LessEqualDepth = 3;
        public const int EqualDepth = 4;
        public const int GreaterEqualDepth = 5;
        public const int GreaterDepth = 6;
        public const int NotEqualDepth = 7;
        public const int MultiplyOperation = 0;
        public const int MixOperation = 1;
        public const int AddOperation = 2;
        public const int NoToneMapping = 0;
        public const int LinearToneMapping = 1;
        public const int ReinhardToneMapping = 2;
        public const int CineonToneMapping = 3;
        public const int ACESFilmicToneMapping = 4;
        public const int CustomToneMapping = 5;

        public const int UVMapping = 300;
        public const int CubeReflectionMapping = 301;
        public const int CubeRefractionMapping = 302;
        public const int EquirectangularReflectionMapping = 303;
        public const int EquirectangularRefractionMapping = 304;
        public const int SphericalReflectionMapping = 305;
        public const int CubeUVReflectionMapping = 306;
        public const int CubeUVRefractionMapping = 307;
        public const int RepeatWrapping = 1000;
        public const int ClampToEdgeWrapping = 1001;
        public const int MirroredRepeatWrapping = 1002;
        public const int NearestFilter = 1003;
        public const int NearestMipmapNearestFilter = 1004;
        public const int NearestMipMapNearestFilter = 1004;
        public const int NearestMipmapLinearFilter = 1005;
        public const int NearestMipMapLinearFilter = 1005;
        public const int LinearFilter = 1006;
        public const int LinearMipmapNearestFilter = 1007;
        public const int LinearMipMapNearestFilter = 1007;
        public const int LinearMipmapLinearFilter = 1008;
        public const int LinearMipMapLinearFilter = 1008;
        public const int UnsignedByteType = 1009;
        public const int ByteType = 1010;
        public const int ShortType = 1011;
        public const int UnsignedShortType = 1012;
        public const int IntType = 1013;
        public const int UnsignedIntType = 1014;
        public const int FloatType = 1015;
        public const int HalfFloatType = 1016;
        public const int UnsignedShort4444Type = 1017;
        public const int UnsignedShort5551Type = 1018;
        public const int UnsignedShort565Type = 1019;
        public const int UnsignedInt248Type = 1020;
        public const int AlphaFormat = 1021;
        public const int RGBFormat = 1022;
        public const int RGBAFormat = 1023;
        public const int LuminanceFormat = 1024;
        public const int LuminanceAlphaFormat = 1025;
        public const int RGBEFormat = RGBAFormat;
        public const int DepthFormat = 1026;
        public const int DepthStencilFormat = 1027;
        public const int RedFormat = 1028;
        public const int RedIntegerFormat = 1029;
        public const int RGFormat = 1030;
        public const int RGIntegerFormat = 1031;
        public const int RGBIntegerFormat = 1032;
        public const int RGBAIntegerFormat = 1033;

        public const int RGB_S3TC_DXT1_Format = 33776;
        public const int RGBA_S3TC_DXT1_Format = 33777;
        public const int RGBA_S3TC_DXT3_Format = 33778;
        public const int RGBA_S3TC_DXT5_Format = 33779;
        public const int RGB_PVRTC_4BPPV1_Format = 35840;
        public const int RGB_PVRTC_2BPPV1_Format = 35841;
        public const int RGBA_PVRTC_4BPPV1_Format = 35842;
        public const int RGBA_PVRTC_2BPPV1_Format = 35843;
        public const int RGB_ETC1_Format = 36196;
        public const int RGBA_ASTC_4x4_Format = 37808;
        public const int RGBA_ASTC_5x4_Format = 37809;
        public const int RGBA_ASTC_5x5_Format = 37810;
        public const int RGBA_ASTC_6x5_Format = 37811;
        public const int RGBA_ASTC_6x6_Format = 37812;
        public const int RGBA_ASTC_8x5_Format = 37813;
        public const int RGBA_ASTC_8x6_Format = 37814;
        public const int RGBA_ASTC_8x8_Format = 37815;
        public const int RGBA_ASTC_10x5_Format = 37816;
        public const int RGBA_ASTC_10x6_Format = 37817;
        public const int RGBA_ASTC_10x8_Format = 37818;
        public const int RGBA_ASTC_10x10_Format = 37819;
        public const int RGBA_ASTC_12x10_Format = 37820;
        public const int RGBA_ASTC_12x12_Format = 37821;
        public const int LoopOnce = 2200;
        public const int LoopRepeat = 2201;
        public const int LoopPingPong = 2202;
        public const int InterpolateDiscrete = 2300;
        public const int InterpolateLinear = 2301;
        public const int InterpolateSmooth = 2302;
        public const int ZeroCurvatureEnding = 2400;
        public const int ZeroSlopeEnding = 2401;
        public const int WrapAroundEnding = 2402;
        public const int TrianglesDrawMode = 0;
        public const int TriangleStripDrawMode = 1;
        public const int TriangleFanDrawMode = 2;
        public const int LinearEncoding = 3000;
        public const int sRGBEncoding = 3001;
        public const int GammaEncoding = 3007;
        public const int RGBEEncoding = 3002;
        public const int LogLuvEncoding = 3003;
        public const int RGBM7Encoding = 3004;
        public const int RGBM16Encoding = 3005;
        public const int RGBDEncoding = 3006;
        public const int BasicDepthPacking = 3200;
        public const int RGBADepthPacking = 3201;
        public const int TangentSpaceNormalMap = 0;
        public const int ObjectSpaceNormalMap = 1;

        public const int ZeroStencilOp = 0;
        public const int KeepStencilOp = 7680;
        public const int ReplaceStencilOp = 7681;
        public const int IncrementStencilOp = 7682;
        public const int DecrementStencilOp = 7683;
        public const int IncrementWrapStencilOp = 34055;
        public const int DecrementWrapStencilOp = 34056;
        public const int InvertStencilOp = 5386;

        public const int NeverStencilFunc = 512;
        public const int LessStencilFunc = 513;
        public const int EqualStencilFunc = 514;
        public const int LessEqualStencilFunc = 515;
        public const int GreaterStencilFunc = 516;
        public const int NotEqualStencilFunc = 517;
        public const int GreaterEqualStencilFunc = 518;
        public const int AlwaysStencilFunc = 519;

        public const int StaticDrawUsage = 35044;
        public const int DynamicDrawUsage = 35048;
        public const int StreamDrawUsage = 35040;
        public const int StaticReadUsage = 35045;
        public const int DynamicReadUsage = 35049;
        public const int StreamReadUsage = 35041;
        public const int StaticCopyUsage = 35046;
        public const int DynamicCopyUsage = 35050;
        public const int StreamCopyUsage = 35042;

        public enum GLComtibility
        {
            ES2,
            ES3,
            ES3_1,
            ES3_2
        }
    }
}
