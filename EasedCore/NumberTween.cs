using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eased
{
    public class NumberTween : ITween
    {
        public int Value { get; set; }
        public TweenSettings Settings { get; set; }
        float ITween.step { get => step; set { step = value; } }

        int Start;
        int End;

        float step;
        float elapsedTime;

        public NumberTween(int start, int end, TweenSettings settings)
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
                Value = End;
            }
            else
            {
                Value = (int)Helper.Lerp(Start, End, Helper.ApplyEasing(Settings.easingStyle,step));
            }
        }
    }

}
