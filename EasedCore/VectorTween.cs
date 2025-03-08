using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Eased
{
    public class VectorTween : ITween
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public TweenSettings Settings { get; set; }
        float ITween.step { get => step; set { step = value; } }

        Vector3 Start;
        Vector3 End;

        float step;
        float elapsedTime;

        public VectorTween(Vector3 start,Vector3 end, TweenSettings settings)
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
                Z = End.Z;
            }
            else
            {
                X = Helper.Lerp(Start.X, End.X, Helper.ApplyEasing(Settings.easingStyle, step));
                Y = Helper.Lerp(Start.Y, End.Y, Helper.ApplyEasing(Settings.easingStyle, step));
                Z = Helper.Lerp(Start.Z, End.Z, Helper.ApplyEasing(Settings.easingStyle, step));
            }
        }
    }

}
