using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eased
{
    public static class Helper
    {
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
        public static float ApplyEasing(EasingStyle style, float t)
        {
            switch (style)
            {
                case EasingStyle.Linear:
                    return t;

                case EasingStyle.Exponential:
                    return t == 0 ? 0 : (float)Math.Pow(2, 10 * (t - 1));

                case EasingStyle.Quadratic:
                    return t * t;

                case EasingStyle.Cubic:
                    return t * t * t;

                case EasingStyle.Bounce:
                    return BounceEase(t);

                default:
                    throw new ArgumentOutOfRangeException(nameof(style), style, null);
            }
        }

        private static float BounceEase(float t)
        {
            if (t < 1 / 2.75f)
            {
                return 7.5625f * t * t;
            }
            else if (t < 2 / 2.75f)
            {
                t -= 1.5f / 2.75f;
                return 7.5625f * t * t + 0.75f;
            }
            else if (t < 2.5 / 2.75f)
            {
                t -= 2.25f / 2.75f;
                return 7.5625f * t * t + 0.9375f;
            }
            else
            {
                t -= 2.625f / 2.75f;
                return 7.5625f * t * t + 0.984375f;
            }
        }

    }
}
