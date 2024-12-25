using Avalonia;
using Avalonia.OpenGL;
using Avalonia.Win32;
using System;
using System.Collections.Generic;

namespace SilkAvaloniaDemo
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .With(new Win32PlatformOptions
                {
                    RenderingMode = new[]
                    {
                        Win32RenderingMode.AngleEgl,
                    },
                    CompositionMode = new[]
                    {
                        Win32CompositionMode.RedirectionSurface,
                    },
                }).
                With(new AngleOptions
                {
                    GlProfiles = new[]
                    {
                        new GlVersion(GlProfileType.OpenGLES, 3, 1),
                    }
                })
                .With(new X11PlatformOptions
                {
                    RenderingMode = new[]
                    {
                          X11RenderingMode.Egl,
                    }
                })
                .WithInterFont()
                .LogToTrace();
    }
}
