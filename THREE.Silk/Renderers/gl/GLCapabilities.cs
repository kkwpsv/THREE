using Silk.NET.OpenGLES;
using Silk.NET.OpenGLES.Extensions.EXT;
using System;
using System.Linq;


namespace THREE
{
    [Serializable]
    public struct GLCapabilitiesParameters
    {
        public string precision;

        public bool logarithmicDepthBuffer;

    }

    [Serializable]
    public class GLCapabilities
    {
        public bool IsGL2;

        public string Precision { get; }

        public bool logarithmicDepthBuffer { get; }

        public int MaxTextures { get; }

        public int MaxVertexTextures { get; }

        public int MaxTextureSize { get; }

        public int MaxCubemapSize { get; }

        public int MaxAttributes { get; }

        public int MaxVertexUniforms { get; }

        public int MaxVaryings { get; }

        public int MaxFragmentUniforms { get; }

        public bool VertexTextures { get; }

        public bool FloatFragmentTextures { get; }

        public bool FloatVertexTextures { get; }

        public float MaxAnisotropy { get; }

        public int MaxSamples { get; }

        private readonly GLExtensions _extensions;
        private readonly GL _gl;

        public GLCapabilities(GLExtensions extensions, ref GLCapabilitiesParameters parameters)
        {
            IsGL2 = true;
            _gl = extensions.GL;

            _extensions = extensions;

            Precision = parameters.precision != null ? parameters.precision : "highp";

            string maxPrecision = GetMaxPrecision(this.Precision);

            if (!maxPrecision.Equals(this.Precision))
            {
                Precision = maxPrecision;
            }

            MaxTextures = _gl.GetInteger(GetPName.MaxTextureImageUnits);
            MaxVertexTextures = _gl.GetInteger(GetPName.MaxVertexTextureImageUnits);
            MaxTextureSize = _gl.GetInteger(GetPName.MaxTextureSize);
            MaxCubemapSize = _gl.GetInteger(GetPName.MaxCubeMapTextureSize);
            MaxAttributes = _gl.GetInteger(GetPName.MaxVertexAttribs);
            MaxVertexUniforms = _gl.GetInteger(GetPName.MaxVertexUniformVectors);
            MaxVaryings = _gl.GetInteger(GetPName.MaxVaryingVectors);
            MaxFragmentUniforms = _gl.GetInteger(GetPName.MaxFragmentUniformVectors);

            VertexTextures = MaxVertexTextures > 0;
            FloatFragmentTextures = true;
            FloatVertexTextures = VertexTextures && FloatFragmentTextures;

            MaxSamples = _gl.GetInteger(GLEnum.MaxSamples);

            if (_extensions.Get("GL_EXT_texture_filter_anisotropic"))
            {
                MaxAnisotropy = _gl.GetFloat((GetPName)EXT.MaxTextureMaxAnisotropyExt);
            }
            else
            {
                MaxAnisotropy = 0;
            }
        }

        public string GetMaxPrecision(string precision)
        {
            if (precision.Equals("highp"))
            {
                int range, value1, value2;
                _gl.GetShaderPrecisionFormat(ShaderType.VertexShader, GLEnum.HighFloat, out range, out value1);
                _gl.GetShaderPrecisionFormat(ShaderType.FragmentShader, GLEnum.HighFloat, out range, out value2);

                if (value1 > 0 && value2 > 0)
                {
                    return "highp";
                }
                precision = "mediump";
            }
            if (precision.Equals("mediump"))
            {
                int range, value1, value2;
                _gl.GetShaderPrecisionFormat(ShaderType.VertexShader, GLEnum.MediumFloat, out range, out value1);
                _gl.GetShaderPrecisionFormat(ShaderType.FragmentShader, GLEnum.MediumFloat, out range, out value2);

                if (value1 > 0 && value2 > 0)
                {
                    return "mediump";
                }
            }
            return "lowp";
        }
    }
}
