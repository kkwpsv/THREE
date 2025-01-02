using Silk.NET.OpenGLES;
using System.Collections.Generic;

namespace THREE
{
    [Serializable]
    public class GLExtensions
    {
        private HashSet<string> ExtensionsName { get; }
        public GL GL { get; }

        public GLExtensions(GL gl)
        {
            GL = gl;
            var extensions = gl.GetStringS(GLEnum.Extensions);
            ExtensionsName = new HashSet<string>(extensions.Split(' '));
        }

        public bool Get(string name) => ExtensionsName.Contains(name);
    }
}
