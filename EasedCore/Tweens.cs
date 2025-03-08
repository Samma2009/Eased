using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eased
{
    public static class Tweens
    {
        internal static List<ITween> tweens = new();

        public static void Register(ITween tween) => tweens.Add(tween);

        public static void Step(float deltaTime)
        {
            foreach (var item in tweens)
            {
                item.Step(deltaTime);

                if (item.step >= 1)
                {
                    tweens.Remove(item);
                }
            }
        }
    }
}
