namespace THREE
{
    [Serializable]
    public struct RGBA
    {
        public byte B;
        public byte G;
        public byte R;
        public byte A;
    }
    [Serializable]
    public static class ImageExtension
    {
        public static byte[] ToByteArray(this float[] floatArray)
        {
            byte[] byteArray = new byte[floatArray.Length];
            for (int i = 0; i < floatArray.Length; i++)
                byteArray[i] = (byte)(floatArray[i] * 255.0f);

            return byteArray;
        }
    }
}
