using Avalonia.VisualTree;
using Silk.NET.Input;
using Silk.NET.SDL;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace SilkAvaloniaDemo
{
    internal class InputContext : IInputContext
    {
        private OpenGLControl _control;

        public InputContext(OpenGLControl openGLControl)
        {
            _control = openGLControl;
            Keyboards = new Keyboard[] { new Keyboard(_control) };
            Mice = new Mouse[] { new Mouse(_control) };
        }

        public nint Handle => throw new NotImplementedException();

        public IReadOnlyList<IGamepad> Gamepads { get; } = Array.Empty<IGamepad>();

        public IReadOnlyList<IJoystick> Joysticks { get; } = Array.Empty<IJoystick>();

        public IReadOnlyList<IKeyboard> Keyboards { get; }

        public IReadOnlyList<IMouse> Mice { get; }

        public IReadOnlyList<IInputDevice> OtherDevices => throw new NotImplementedException();

        public event Action<IInputDevice, bool>? ConnectionChanged;

        public void Dispose()
        {
        }
    }

    internal class Keyboard : IKeyboard
    {
        private readonly OpenGLControl _control;

        public Keyboard(OpenGLControl control)
        {
            _control = control;
        }

        public IReadOnlyList<Key> SupportedKeys => throw new NotImplementedException();

        public string ClipboardText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => throw new NotImplementedException();

        public int Index => throw new NotImplementedException();

        public bool IsConnected => throw new NotImplementedException();

        public event Action<IKeyboard, Key, int>? KeyDown;
        public event Action<IKeyboard, Key, int>? KeyUp;
        public event Action<IKeyboard, char>? KeyChar;

        public void BeginInput()
        {
            throw new NotImplementedException();
        }

        public void EndInput()
        {
            throw new NotImplementedException();
        }

        public bool IsKeyPressed(Key key)
        {
            return false;
        }

        public bool IsScancodePressed(int scancode)
        {
            throw new NotImplementedException();
        }
    }

    internal class Mouse : IMouse
    {
        private readonly OpenGLControl _control;

        public Mouse(OpenGLControl control)
        {
            _control = control;
        }

        public IReadOnlyList<MouseButton> SupportedButtons { get; } = new List<MouseButton> { MouseButton.Left };

        public IReadOnlyList<ScrollWheel> ScrollWheels { get; } = new List<ScrollWheel>
        {
            new ScrollWheel(),
        };

        public Vector2 Position
        {
            get
            {
                var pos = _control.MousePoint;

                var scale = _control.GetVisualRoot()?.RenderScaling ?? 1;
                var result = new Vector2();
                result.X = (int)(pos.X * scale);
                result.Y = (int)(pos.Y * scale);
                return result;
            }
            set => throw new NotImplementedException();
        }

        public ICursor Cursor => throw new NotImplementedException();

        public int DoubleClickTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DoubleClickRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => "Mouse";

        public int Index => 0;

        public bool IsConnected => true;

        public event Action<IMouse, MouseButton> MouseDown;
        public event Action<IMouse, MouseButton> MouseUp;
        public event Action<IMouse, MouseButton, Vector2> Click;
        public event Action<IMouse, MouseButton, Vector2> DoubleClick;
        public event Action<IMouse, Vector2> MouseMove;
        public event Action<IMouse, ScrollWheel> Scroll;

        public bool IsButtonPressed(MouseButton btn)
        {
            if (btn == MouseButton.Left)
            {
                return _control.IsLeftButtonDown;
            }
            return false;
        }
    }
}