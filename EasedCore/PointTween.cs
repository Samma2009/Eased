using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eased
{
    public class PointTween : ITween
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TweenSettings Settings { get; set; }
        float ITween.step { get => step; set { step = value; } }

        Point Start;
        Point End;

        float step;
        float elapsedTime;

        public PointTween(Point start, Point end, TweenSettings settings)
        {
            Start = start;
            End = end;
            Settings = settings;
            step = 0;
            elapsedTime = 0;
        }

        void ITween.Step(float deltatime)
        {
            if (step >= 1) return;

            elapsedTime += deltatime;
            step = elapsedTime / Settings.duration;

            if (step >= 1)
            {
                step = 1;
                X = End.X;
                Y = End.Y;
            }
            else
            {
                X = (int)Helper.Lerp(Start.X, End.X, Helper.ApplyEasing(Settings.easingStyle, step));
                Y = (int)Helper.Lerp(Start.Y, End.Y, Helper.ApplyEasing(Settings.easingStyle, step));
            }
        }
    }

}
