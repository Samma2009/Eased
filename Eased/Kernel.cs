using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using Cosmos.HAL;
using Cosmos.System.Graphics;
using Sys = Cosmos.System;

namespace Eased
{
    public class Kernel : Sys.Kernel
    {
        RectTween t;
        Canvas c;
        DateTime date;
        protected override void BeforeRun()
        {
            c = FullScreenCanvas.GetFullScreenCanvas(new Mode(1280,720,ColorDepth.ColorDepth32));

            t = new(new(1280 / 2,720 / 2,0,0),new(188, 112, 903, 496),new() { duration=5f,easingStyle=EasingStyle.Bounce});
            Tweens.Register(t);
            date = DateTime.Now;
        }

        protected override void Run()
        {

            Tweens.Step(0.004f);

            c.Clear(Color.White);
            c.DrawFilledRectangle(Color.DarkGray,t.X, t.Y, t.W, t.H);
            c.Display();
        }
    }
}
