﻿
using System;
using THREE.Renderers.Shaders;

namespace THREE
{
    [Serializable]
    public class DotScreenPass : Pass
    {
        public Uniforms uniforms;
        private ShaderMaterial material;

        public DotScreenPass(Vector2 center = null, float? angle = null, float? scale = null) : base()
        {
            var shader = new DotScreenShader();

            this.uniforms = UniformsUtils.CloneUniforms(shader.Uniforms);

            if (center != null) (this.uniforms["center"] as Uniform)["value"] = center;
            if (angle != null) (this.uniforms["angle"] as Uniform)["value"] = angle;
            if (scale != null) (this.uniforms["scale"] as Uniform)["value"] = scale;

            this.material = new ShaderMaterial
            {

                Uniforms = this.uniforms,
                VertexShader = shader.VertexShader,
                FragmentShader = shader.FragmentShader

            };

            this.fullScreenQuad = new FullScreenQuad(this.material);

        }
        public override void Render(GLRenderer renderer, GLRenderTarget writeBuffer, GLRenderTarget readBuffer, float? deltaTime = null, bool? maskActive = null)
        {
            (this.uniforms["tDiffuse"] as Uniform)["value"] = readBuffer.Texture;
            ((this.uniforms["tSize"] as Uniform)["value"] as Vector2).Set(readBuffer.Width, readBuffer.Height);

            if (this.RenderToScreen)
            {

                renderer.SetRenderTarget(null);
                this.fullScreenQuad.Render(renderer);

            }
            else
            {

                renderer.SetRenderTarget(writeBuffer);
                if (this.Clear) renderer.Clear();
                this.fullScreenQuad.Render(renderer);

            }
        }

        public override void SetSize(float width, float height)
        {
        }
    }
}
