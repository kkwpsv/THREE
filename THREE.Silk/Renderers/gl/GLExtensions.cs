using Silk.NET.OpenGLES;
using System.Collections.Generic;

namespace THREE
{
    [Serializable]
    public class GLExtensions
    {
        public List<string> ExtensionsName { get; }
        public Dictionary<string, int> Extensions { get; } = new Dictionary<string, int>();
        public GL GL { get; }

        public GLExtensions(GL gl)
        {
            GL = gl;
            var extensions = gl.GetStringS(GLEnum.Extensions);
            ExtensionsName = new List<string>(extensions.Split(' '));
        }

        public int Get(string name)
        {
            int index = -1;

            int value;

            if (Extensions.TryGetValue(name, out value))
            {
                return value;
            }
            else
            {
                index = ExtensionsName.IndexOf(name);
                if (index >= 0)
                {
                    Extensions.Add(name, index);
                }
                return index;
            }
        }
    }
}
