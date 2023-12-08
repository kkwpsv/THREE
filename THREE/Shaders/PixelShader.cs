﻿
using System.Runtime.Serialization;

namespace THREE
{
    [Serializable]
    public class PixelShader : ShaderMaterial
    {
        public PixelShader() : base()
        {
            Uniforms.Add("tDiffuse", new Uniform { { "value", null } });
            Uniforms.Add("resolution", new Uniform { { "value", new Vector2(256, 256) } });
            Uniforms.Add("pixelSize", new Uniform { { "value", 1.0f } });


            VertexShader = @"
                varying vec2 vUv; 


                void main() {

					vUv = uv;
			        gl_Position = projectionMatrix * modelViewMatrix * vec4( position, 1.0 );

		        }


            "
            ;

            FragmentShader = @"
				uniform sampler2D tDiffuse; 
				uniform float pixelSize;
				uniform vec2 resolution;

				varying highp vec2 vUv;

				void main(){

				vec2 dxy = pixelSize / resolution;
				vec2 coord = dxy * floor( vUv / dxy );
				gl_FragColor = texture2D(tDiffuse, coord);

				}


			";
        }

        public PixelShader(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
