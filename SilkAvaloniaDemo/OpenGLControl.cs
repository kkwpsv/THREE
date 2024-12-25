using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Avalonia.Rendering;
using Silk.NET.OpenGLES;
using Silk.NET.OpenGLES.Extensions.ImGui;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using THREE.Silk.Example;

namespace SilkAvaloniaDemo
{
    public class OpenGLControl : OpenGlControlBase, ICustomHitTest
    {
        private GL? _gl;
        private Example? _example;
        private ExampleControlWrapper _wrapper;
        private ImGuiController _imGuiController;
        private Stopwatch _stopwatch = new Stopwatch();
        private double _lastStopwatchSeconds = 0;

        private DebugProc _debugMessageCallback;

        protected override void OnOpenGlInit(GlInterface gl)
        {
            _gl = GL.GetApi(gl.GetProcAddress);

            if (_gl != null)
            {
                var version = _gl.GetStringS(GLEnum.Version);
                var vendor = _gl.GetStringS(GLEnum.Vendor);
                var renderer = _gl.GetStringS(GLEnum.Renderer);
                Console.WriteLine($"OpenGL Init.");
                Console.WriteLine($"Vendor: {vendor}");
                Console.WriteLine($"Version: {version}");
                Console.WriteLine($"Renderer: {renderer}");

                _debugMessageCallback = DebugMessageCallback;
                _gl.Enable(GLEnum.DebugOutput);
                _gl.DebugMessageCallback(_debugMessageCallback, 0);

                try
                {
                    _wrapper = new ExampleControlWrapper(this, _gl);

                    _imGuiController = new ImGuiController(_gl, _wrapper, new InputContext(this));
                    InitExample();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void DebugMessageCallback(GLEnum source, GLEnum type, int id, GLEnum severity, int length, nint message, nint userParam)
        {
            var str = Marshal.PtrToStringUTF8(message);
            Console.WriteLine($"[{severity}] {str}");
        }

        private void InitExample()
        {
            _example = new MaterialsLightAnimationExample();
            _example.imGuiManager = _imGuiController;
            _example.Load(_wrapper);
            _example.OnResize(new THREE.Silk.ResizeEventArgs(_wrapper.Size));
            _stopwatch.Restart();
            _lastStopwatchSeconds = 0;
        }

        protected override void OnOpenGlRender(GlInterface gl, int fb)
        {
            var size = _wrapper.Size;
            _gl.Viewport(0, 0, (uint)size.X, (uint)size.Y);

            var seconds = _stopwatch.Elapsed.TotalSeconds;
            _imGuiController.Update((float)(seconds - _lastStopwatchSeconds));
            _lastStopwatchSeconds = seconds;

            if (_example != null)
            {
                _example.renderer.DefaultFrameBuffer = (uint)fb;
                _example.Render();
                _example.AddGuiControlsAction?.Invoke();
            }

            _imGuiController.Render();


            RequestNextFrameRendering();
        }

        protected override void OnSizeChanged(SizeChangedEventArgs e)
        {
            _example?.OnResize(new THREE.Silk.ResizeEventArgs(_wrapper.Size));
        }

        public bool IsLeftButtonDown { get; private set; }

        public Point MousePoint { get; private set; }

        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            var pointerPoint = e.GetCurrentPoint(this);
            if (pointerPoint.Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonPressed)
            {
                var pos = pointerPoint.Position;
                _example?.OnMouseDown(Silk.NET.Input.MouseButton.Left, (int)pos.X, (int)pos.Y);

                IsLeftButtonDown = true;
                MousePoint = pos;
            }
        }

        protected override void OnPointerMoved(PointerEventArgs e)
        {
            var pointerPoint = e.GetCurrentPoint(this);
            if (pointerPoint.Properties.IsLeftButtonPressed)
            {
                var pos = pointerPoint.Position;
                _example?.OnMouseMove(Silk.NET.Input.MouseButton.Left, (int)pos.X, (int)pos.Y);

                MousePoint = pos;
            }
        }

        protected override void OnPointerReleased(PointerReleasedEventArgs e)
        {
            var pointerPoint = e.GetCurrentPoint(this);
            if (pointerPoint.Properties.PointerUpdateKind == PointerUpdateKind.LeftButtonReleased)
            {
                var pos = pointerPoint.Position;
                _example?.OnMouseUp(Silk.NET.Input.MouseButton.Left, (int)pos.X, (int)pos.Y);

                IsLeftButtonDown = false;
                MousePoint = pos;
            }
        }

        protected override void OnPointerWheelChanged(PointerWheelEventArgs e)
        {
            var pos = e.GetCurrentPoint(this).Position;
            _example?.OnMouseWheel((int)pos.X, (int)pos.Y, (int)e.Delta.Y * 120);
        }

        public bool HitTest(Point point)
        {
            return true;
        }
    }


}
