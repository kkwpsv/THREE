using THREE.Textures;

namespace THREE
{
    [Serializable]
    public class Lut
    {
        private Dictionary<string, List<(float, int)>> _colorMapKeywords;
        private float _minV;
        private float _maxV;
        private int? _n;
        private List<Color> _lut = new List<Color>();
        private List<(float, int)> _map = new List<(float, int)>();

        public Lut(string colorMap = null, int? numberofcolors = null)
        {
            _minV = 0;
            _maxV = 1;

            _colorMapKeywords = new Dictionary<string, List<(float, int)>>() {
                { "rainbow",new List<(float,int)>() {( 0.0f, 0x0000FF ), (0.2f, 0x00FFFF), (0.5f, 0x00FF00), (0.8f, 0xFFFF00), (1.0f, 0xFF0000) } },
                { "cooltowarm", new List<(float,int)>(){ (0.0f, 0x3C4EC2 ), (0.2f, 0x9BBCFF), (0.5f, 0xDCDCDC), (0.8f, 0xF6A385), (1.0f, 0xB40426) } },
                { "blackbody", new List<(float,int)>(){ (0.0f, 0x000000), (0.2f, 0x780000), (0.5f, 0xE63200), (0.8f, 0xFFFF00), (1.0f, 0xFFFFFF) } },
                { "grayscale", new List<(float,int)>(){ (0.0f, 0x000000), (0.2f, 0x404040), (0.5f, 0x7F7F80), (0.8f, 0xBFBFBF), (1.0f, 0xFFFFFF) } }
            };

            SetColorMap(colorMap, numberofcolors);

        }
        public Lut Set(Lut value)
        {
            if (value is Lut)
            {
                Copy(value);
            }
            return this;
        }

        public void SetMin(float min)
        {
            _minV = min;
        }

        public void SetMax(float max)
        {
            _maxV = max;
        }

        public Lut SetColorMap(string colormap, int? numberofcolors)
        {
            if (colormap != null && _colorMapKeywords.ContainsKey(colormap))
            {
                _map = _colorMapKeywords[colormap];
            }
            else
            {
                _map = _colorMapKeywords["rainbow"];
            }

            _n = numberofcolors != null ? numberofcolors.Value : 32;

            var step = 1.0 / _n.Value;

            _lut.Clear();

            for (var i = 0.0; i <= 1.0; i += step)
            {

                for (var j = 0; j < _map.Count - 1; j++)
                {

                    if (i >= _map[j].Item1 && i < _map[j + 1].Item1)
                    {
                        var min = _map[j].Item1;
                        var max = _map[j + 1].Item1;

                        var minColor = new Color(_map[j].Item2);
                        var maxColor = new Color(_map[j + 1].Item2);

                        var color = minColor.Lerp(maxColor, (float)((i - min) / (max - min)));

                        _lut.Add(color);
                    }

                }

            }

            return this;

        }
        public Lut Copy(Lut lut)
        {
            _lut = lut._lut;
            _map = lut._map;
            _n = lut._n;
            _minV = lut._minV;
            _maxV = lut._maxV;
            _lut = new List<Color>(lut._lut);

            return this;
        }
        public Color GetColor(float alpha)
        {

            if (alpha <= _minV)
            {
                alpha = _minV;
            }
            else if (alpha >= _maxV)
            {
                alpha = _maxV;
            }

            alpha = (alpha - _minV) / (_maxV - _minV);

            var colorPosition = (int)System.Math.Round(alpha * _n.Value);

            if (colorPosition == _n.Value)
                colorPosition -= 1;

            return _lut[colorPosition];

        }
        public void AddColorMap(string colormapName, List<(float, int)> arrayOfColors)
        {
            _colorMapKeywords[colormapName] = arrayOfColors;
        }

        public Texture CreateTexture()
        {
            Texture texture = new Texture();

            byte[] data = new byte[4 * _n.Value];

            var k = 0;

            var step = 1.0 / _n.Value;

            for (var i = 1.0; i >= 0.0; i -= step)
            {
                for (var j = _map.Count - 1; j >= 0; j--)
                {
                    if (i < _map[j].Item1 && i >= _map[j - 1].Item1)
                    {
                        var min = _map[j - 1].Item1;
                        var max = _map[j].Item1;

                        var minColor = new Color(_map[j - 1].Item2);
                        var maxColor = new Color(_map[j].Item2);

                        var color = minColor.Lerp(maxColor, (float)((i - min) / (max - min)));

                        data[k * 4] = (byte)System.Math.Round(color.R * 255);
                        data[k * 4 + 1] = (byte)System.Math.Round(color.G * 255);
                        data[k * 4 + 2] = (byte)System.Math.Round(color.B * 255);
                        data[k * 4 + 3] = 255;

                        k += 1;
                    }
                }
            }

            texture.Image = new Image
            {
                Width = 1,
                Height = _n.Value,
                Data = data,
            };
            texture.Format = Constants.RGBAFormat;
            texture.NeedsUpdate = true;

            return texture;
        }
    }

}
