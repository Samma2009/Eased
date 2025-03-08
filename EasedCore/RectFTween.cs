﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eased
{
    public class RectFTween : ITween
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float W { get; set; }
        public float H { get; set; }
        public TweenSettings Settings { get; set; }
        float ITween.step { get => step; set { step = value; } }

        RectangleF Start;
        RectangleF End;

        float step;
        float elapsedTime;

        public RectFTween(RectangleF start, RectangleF end, TweenSettings settings)
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
                W = End.Width;
                H = End.Height;
            }
            else
            {
                X = Helper.Lerp(Start.X, End.X, Helper.ApplyEasing(Settings.easingStyle, step));
                Y = Helper.Lerp(Start.Y, End.Y, Helper.ApplyEasing(Settings.easingStyle, step));
                W = Helper.Lerp(Start.Width, End.Width, Helper.ApplyEasing(Settings.easingStyle, step));
                H = Helper.Lerp(Start.Height, End.Height, Helper.ApplyEasing(Settings.easingStyle, step));
            }
        }
    }

}
