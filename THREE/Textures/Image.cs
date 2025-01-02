using System;
using System.Collections.Generic;
using System.Text;

namespace THREE.Textures
{
    public class Image
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public byte[]? Data { get; set; }

        public int[]? IntData { get; set; }

        public float[]? FloatData { get; set; }

        public bool HasData => Data != null || IntData != null || FloatData != null;
    }
}
