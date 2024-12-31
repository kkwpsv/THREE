﻿using Silk.NET.OpenGLES;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THREE
{
    public class GLUniformsLoader
    {
        public static void Upload(GL gl,List<GLUniform> Seq, GLUniforms values, GLTextures textures)
        {
            for (int i = 0, n = Seq.Count; i != n; ++i)
            {
                var u = Seq[i];
                object v = (values[u.Id] as GLUniform)["value"];
                if (v == null) continue;

                if (u.UniformKind.Equals("SingleUniform"))
                {

                    (u as SingleUniform).SetValue(v, textures);

                    GLEnum error = gl.GetError();

                    if (error == GLEnum.InvalidOperation)
                    {
                        Debug.WriteLine(error.ToString());
                    }
                }
                else if (u.UniformKind.Equals("PureArrayUniform"))
                {
                    (u as PureArrayUniform).SetValue(v, textures);
                    GLEnum error = gl.GetError();
                    if (error == GLEnum.InvalidOperation)
                    {
                        Debug.WriteLine(error.ToString());
                    }
                }
                else
                {

                    (u as StructuredUniform).SetValue(v, textures);
                    GLEnum error = gl.GetError();
                    if (error == GLEnum.InvalidOperation)
                    {
                        Debug.WriteLine(error.ToString());
                    }
                }
            }
        }
        public static List<GLUniform> SeqWithValue(List<GLUniform> seq, GLUniforms values)
        {
            List<GLUniform> r = new List<GLUniform>();

            for (int i = 0, n = seq.Count; i != n; ++i)
            {
                var u = seq[i];
                if (values.ContainsKey(u.Id))
                    r.Add(u);
            }
            return r;
        }
    }
}
