using Silk.NET.OpenGLES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THREESilkExample
{
    public interface IExampleControl
    {
        public GL GL { get; }

        public int Width { get; }

        public int Height { get; }
    }
}
