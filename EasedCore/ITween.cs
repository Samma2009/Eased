namespace Eased
{
    public interface ITween
    {
        internal void Step(float deltatime);
        internal float step { get; set; }
    }

    public struct TweenSettings
    {
        public float duration;
        public EasingStyle easingStyle;
    }

    public enum EasingStyle
    {
        Linear,
        Exponential,
        Quadratic,
        Cubic,
        Bounce
    }
}
