using THREE.Textures;

namespace THREE
{
    [Serializable]
    public class GlitchPass : Pass
    {
        GLUniforms uniforms;
        ShaderMaterial material;
        bool goWild = false;
        float curF = 0.0f;
        int randX = 0;
        Random random = new Random();
        public GlitchPass(int dt_size = 64) : base()
        {
            var shader = new DigitalGlitch();

            uniforms = UniformsUtils.CloneUniforms(shader.Uniforms);

            (uniforms["tDisp"] as GLUniform)["value"] = GenerateHeightmap(dt_size);

            this.material = new ShaderMaterial
            {
                Uniforms = this.uniforms,
                VertexShader = shader.VertexShader,
                FragmentShader = shader.FragmentShader
            };

            this.fullScreenQuad = new Pass.FullScreenQuad(this.material);

            this.goWild = false;
            this.curF = 0;
            GenerateTrigger();
        }

        public override void Render(GLRenderer renderer, GLRenderTarget writeBuffer, GLRenderTarget readBuffer, float? deltaTime = null, bool? maskActive = null)
        {
            (this.uniforms["tDiffuse"] as GLUniform)["value"] = readBuffer.Texture;
            (this.uniforms["seed"] as GLUniform)["value"] = (float)random.NextDouble();//default seeding
            (this.uniforms["byp"] as GLUniform)["value"] = 0;

            if (this.curF % this.randX == 0 || this.goWild == true)
            {

                (this.uniforms["amount"] as GLUniform)["value"] = (float)random.NextDouble() / 30;
                (this.uniforms["angle"] as GLUniform)["value"] = MathUtils.NextFloat((float)-System.Math.PI, (float)System.Math.PI);
                (this.uniforms["seed_x"] as GLUniform)["value"] = MathUtils.NextFloat(-1, 1);
                (this.uniforms["seed_y"] as GLUniform)["value"] = MathUtils.NextFloat(-1, 1);
                (this.uniforms["distortion_x"] as GLUniform)["value"] = MathUtils.NextFloat(0, 1);
                (this.uniforms["distortion_y"] as GLUniform)["value"] = MathUtils.NextFloat(0, 1);
                this.curF = 0;
                this.GenerateTrigger();

            }
            else if (this.curF % this.randX < this.randX / 5)
            {

                (this.uniforms["amount"] as GLUniform)["value"] = (float)random.NextDouble() / 90;
                (this.uniforms["angle"] as GLUniform)["value"] = MathUtils.NextFloat(-(float)System.Math.PI, (float)System.Math.PI);
                (this.uniforms["distortion_x"] as GLUniform)["value"] = MathUtils.NextFloat(0, 1);
                (this.uniforms["distortion_y"] as GLUniform)["value"] = MathUtils.NextFloat(0, 1);
                (this.uniforms["seed_x"] as GLUniform)["value"] = MathUtils.NextFloat(-0.3f, 0.3f);
                (this.uniforms["seed_y"] as GLUniform)["value"] = MathUtils.NextFloat(-0.3f, 0.3f);

            }
            else if (this.goWild == false)
            {

                (this.uniforms["byp"] as GLUniform)["value"] = 1;

            }

            this.curF++;

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
        private void GenerateTrigger()
        {
            this.randX = random.Next(120, 240);
        }

        private DataTexture GenerateHeightmap(int dt_size)
        {
            var data_arr = new float[(dt_size * dt_size)];
            var length = dt_size * dt_size;

            for (var i = 0; i < length; i++)
            {
                data_arr[i] = (float)random.NextDouble();
            }

            return new DataTexture
            {
                Image = new Image
                {
                    Width = dt_size,
                    Height = dt_size,
                    FloatData = data_arr,
                },
                Format = Constants.RedFormat,
                Type = Constants.FloatType,
            };
        }
    }
}
