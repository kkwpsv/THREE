using Avalonia.VisualTree;
using Silk.NET.Core.Contexts;
using Silk.NET.Maths;
using Silk.NET.OpenGLES;
using Silk.NET.Windowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkAvaloniaDemo
{
    class ExampleControlWrapper : IView
    {
        private readonly OpenGLControl _control;

        public ExampleControlWrapper(OpenGLControl control, GL gl)
        {
            _control = control;
            GLContext = new GLContext(gl);
        }

        public nint Handle => throw new NotImplementedException();

        public bool IsClosing => throw new NotImplementedException();

        public double Time => throw new NotImplementedException();

        public Vector2D<int> FramebufferSize => Size;

        public bool IsInitialized => throw new NotImplementedException();

        public bool ShouldSwapAutomatically { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsEventDriven { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsContextControlDisabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Vector2D<int> Size
        {
            get
            {
                var result = new Vector2D<int>();
                var scale = _control.GetVisualRoot()?.RenderScaling ?? 1;
                result.X = (int)Math.Round(_control.Bounds.Size.Width * scale);
                result.Y = (int)Math.Round(_control.Bounds.Size.Height * scale);
                return result;
            }
        }

        public double FramesPerSecond { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double UpdatesPerSecond { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public GraphicsAPI API => throw new NotImplementedException();

        public bool VSync { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public VideoMode VideoMode => throw new NotImplementedException();

        public int? PreferredDepthBufferBits => throw new NotImplementedException();

        public int? PreferredStencilBufferBits => throw new NotImplementedException();

        public Vector4D<int>? PreferredBitDepth => throw new NotImplementedException();

        public int? Samples => throw new NotImplementedException();

        public IGLContext? GLContext { get; }

        public IVkSurface? VkSurface => throw new NotImplementedException();

        public INativeWindow? Native => throw new NotImplementedException();

        public event Action<Vector2D<int>>? Resize;
        public event Action<Vector2D<int>>? FramebufferResize;
        public event Action? Closing;
        public event Action<bool>? FocusChanged;
        public event Action? Load;
        public event Action<double>? Update;
        public event Action<double>? Render;

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void ContinueEvents()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void DoEvents()
        {
            throw new NotImplementedException();
        }

        public void DoRender()
        {
            throw new NotImplementedException();
        }

        public void DoUpdate()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public object Invoke(Delegate d, params object[] args)
        {
            throw new NotImplementedException();
        }

        public Vector2D<int> PointToClient(Vector2D<int> point)
        {
            throw new NotImplementedException();
        }

        public Vector2D<int> PointToFramebuffer(Vector2D<int> point)
        {
            throw new NotImplementedException();
        }

        public Vector2D<int> PointToScreen(Vector2D<int> point)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Run(Action onFrame)
        {
            throw new NotImplementedException();
        }
    }

    internal class GLContext : IGLContext
    {
        private GL _gl;

        public GLContext(GL gl)
        {
            _gl = gl;
        }

        public nint Handle => throw new NotImplementedException();

        public IGLContextSource? Source => throw new NotImplementedException();

        public bool IsCurrent => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public nint GetProcAddress(string proc, int? slot = null)
        {
            return _gl.Context.GetProcAddress(proc, slot);
        }

        public void MakeCurrent()
        {
            throw new NotImplementedException();
        }

        public void SwapBuffers()
        {
            throw new NotImplementedException();
        }

        public void SwapInterval(int interval)
        {
            throw new NotImplementedException();
        }

        public bool TryGetProcAddress(string proc, out nint addr, int? slot = null)
        {
            throw new NotImplementedException();
        }
    }
}
