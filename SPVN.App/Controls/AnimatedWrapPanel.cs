using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace SPVN.App.Controls
{
    public abstract class Interpolation
    {
        public abstract double GetAlpha(double progress);
    }

    public class LinearInterpolation : Interpolation
    {
        public override double GetAlpha(double progress)
        {
            return progress;
        }
    }

    public abstract class EasedInterpolation : Interpolation
    {
        public EasedInterpolation()
        {
            EdgeBehavior = EdgeBehaviorEnum.EaseOut;
        }

        public EasedInterpolation(EdgeBehaviorEnum edgeBehavior)
        {
            EdgeBehavior = edgeBehavior;
        }

        public enum EdgeBehaviorEnum { EaseIn, EaseOut, EaseInOut }

        public EdgeBehaviorEnum EdgeBehavior { get; set; }

        protected abstract double GetEaseInAlpha(double progress);
        protected abstract double GetEaseOutAlpha(double progress);

        protected virtual double GetEaseInOutAlpha(double timeFraction)
        {
            double returnValue = 0.0;

            // we cut each effect in half by multiplying the time fraction by two and halving the distance.
            if (timeFraction <= 0.5)
            {
                returnValue = 0.5 * this.GetEaseInAlpha(timeFraction * 2);
            }
            else
            {
                returnValue = 0.5 + 0.5 * this.GetEaseOutAlpha((timeFraction - 0.5) * 2);
            }
            return returnValue;
        }

        public override double GetAlpha(double progress)
        {
            switch (this.EdgeBehavior)
            {
                case EdgeBehaviorEnum.EaseIn:
                    return this.GetEaseInAlpha(progress);
                case EdgeBehaviorEnum.EaseOut:
                    return this.GetEaseOutAlpha(progress);
                case EdgeBehaviorEnum.EaseInOut:
                default:
                    return this.GetEaseInOutAlpha(progress);
            }
        }
    }

    public class BounceInterpolation : EasedInterpolation
    {
        public BounceInterpolation() : this(2, 3, EdgeBehaviorEnum.EaseOut) { }

        public BounceInterpolation(int bounces, double bounciness, EdgeBehaviorEnum edgeBehavior)
            : base(edgeBehavior)
        {
            Bounces = bounces;
            Bounciness = bounciness;
        }

        public int Bounces { get; set; }

        public double Bounciness { get; set; }

        protected override double GetEaseOutAlpha(double timeFraction)
        {
            double returnValue = 0.0;

            // math magic: The cosine gives us the right wave, the timeFraction is the frequency of the wave, 
            // the absolute value keeps every value positive (so it "bounces" off the midpoint of the cosine 
            // wave, and the amplitude (the exponent) makes the sine wave get smaller and smaller at the end.
            returnValue = Math.Abs(Math.Pow((1 - timeFraction), this.Bounciness)
                          * Math.Cos(2 * Math.PI * timeFraction * this.Bounces));
            returnValue = 1 - returnValue;
            return returnValue;
        }

        protected override double GetEaseInAlpha(double timeFraction)
        {
            double returnValue = 0.0;
            // math magic: The cosine gives us the right wave, the timeFraction is the amplitude of the wave, 
            // the absolute value keeps every value positive (so it "bounces" off the midpoint of the cosine 
            // wave, and the amplitude (the exponent) makes the sine wave get bigger and bigger towards the end.
            returnValue = Math.Abs(Math.Pow((timeFraction), this.Bounciness)
                          * Math.Cos(2 * Math.PI * timeFraction * this.Bounces));
            return returnValue;
        }
    }

    public class ElasticInterpolation : EasedInterpolation
    {
        public ElasticInterpolation() : this(4, 3, EdgeBehaviorEnum.EaseOut) { }

        public ElasticInterpolation(double springiness, double oscillations, EdgeBehaviorEnum edgeBehavior)
            : base(edgeBehavior)
        {
            Springiness = springiness;
            Oscillations = oscillations;
        }

        public double Springiness { get; set; }

        public double Oscillations { get; set; }

        protected override double GetEaseOutAlpha(double timeFraction)
        {
            double returnValue = 0.0;

            // math magic: The cosine gives us the right wave, the timeFraction * the # of oscillations is the 
            // frequency of the wave, and the amplitude (the exponent) makes the wave get smaller at the end
            // by the "springiness" factor. This is extremely similar to the bounce equation.
            returnValue = Math.Pow((1 - timeFraction), this.Springiness)
                          * Math.Cos(2 * Math.PI * timeFraction * this.Oscillations);
            returnValue = 1 - returnValue;
            return returnValue;
        }

        protected override double GetEaseInAlpha(double timeFraction)
        {
            double returnValue = 0.0;
            // math magic: The cosine gives us the right wave, the timeFraction * the # of oscillations is the 
            // frequency of the wave, and the amplitude (the exponent) makes the wave get smaller at the beginning
            // by the "springiness" factor. This is extremely similar to the bounce equation. 
            returnValue = Math.Pow((timeFraction), this.Springiness)
                          * Math.Cos(2 * Math.PI * timeFraction * this.Oscillations);
            return returnValue;
        }
    }

    public class BackInterpolation : EasedInterpolation
    {
        public BackInterpolation() : this(.5, 2, EdgeBehaviorEnum.EaseOut) { }

        public BackInterpolation(double amplitude, double suppression, EdgeBehaviorEnum edgeBehavior)
            : base(edgeBehavior)
        {
            Amplitude = amplitude;
            Suppression = suppression;
        }

        public double Amplitude { get; set; }

        public double Suppression { get; set; }

        protected override double GetEaseOutAlpha(double timeFraction)
        {
            double returnValue = 0.0;
            double frequency = 0.5;

            // math magic: The sine gives us the right wave, the timeFraction * 0.5 (frequency) gives us only half 
            // of the full wave, the amplitude gives us the relative height of the peak, and the exponent makes the 
            // effect drop off more quickly by the "suppression" factor. 
            returnValue = Math.Pow((timeFraction), this.Suppression)
                          * this.Amplitude * Math.Sin(2 * Math.PI * timeFraction * frequency) + timeFraction;
            return returnValue;
        }

        protected override double GetEaseInAlpha(double timeFraction)
        {
            double returnValue = 0.0;
            double frequency = 0.5;

            // math magic: The sine gives us the right wave, the timeFraction * 0.5 (frequency) gives us only half 
            // of the full wave (flipped by multiplying by -1 so that we go "backwards" first), the amplitude gives 
            // us the relative height of the peak, and the exponent makes the effect start later by the "suppression" 
            // factor. 
            returnValue = Math.Pow((1 - timeFraction), this.Suppression)
                          * this.Amplitude * Math.Sin(2 * Math.PI * timeFraction * frequency) * -1 + timeFraction;
            return returnValue;
        }
    }

    public class ExponentialInterpolation : EasedInterpolation
    {
        public ExponentialInterpolation() : this(2, EdgeBehaviorEnum.EaseInOut) { }

        public ExponentialInterpolation(double power, EdgeBehaviorEnum edgeBehavior)
            : base(edgeBehavior)
        {
            Power = power;
        }

        public double Power { get; set; }

        protected override double GetEaseInAlpha(double timeFraction)
        {
            double returnValue = 0.0;

            // math magic: simple exponential growth
            returnValue = Math.Pow(timeFraction, this.Power);
            return returnValue;
        }

        protected override double GetEaseOutAlpha(double timeFraction)
        {
            double returnValue = 0.0;

            // math magic: simple exponential decay
            returnValue = Math.Pow(timeFraction, 1 / this.Power);
            return returnValue;
        }
    }
    public class AnimatedWrapPanel : Panel
    {
        public AnimatedWrapPanel()
        {
            // This sets up the per-frame callback that we use for animation.

            _tick = new Storyboard();
            _tick.Duration = new Duration(TimeSpan.Zero);
            _tick.Completed += Tick;
            _tick.Begin();
        }

        /// <summary>
        /// This property controls the duration of the animation.
        /// </summary>
        public Duration Duration
        {
            get { return _duration; }
            set
            {
                // If the Duration is Forever or Automatic, it will not have a TimeSpan.
                // The Duration must have a TimeSpan and not be one of those special values.

                if (!value.HasTimeSpan)
                    throw new ArgumentOutOfRangeException();

                _duration = value;
            }
        }

        public Interpolation Interpolation
        {
            get { return _interpolation; }
            set
            {
                if (value == null)
                {
                    _interpolation = new LinearInterpolation();
                }
                else
                {
                    _interpolation = value;
                }
            }
        }

        /// <summary>
        /// This tells the layout system to call Arrange on the Panel if there are any elements that
        /// must be moved.
        /// </summary>
        private void Tick(object sender, EventArgs e)
        {
            // If there are still elements to be animated, make sure that ArrangeOverride will
            // get called. Note that the InvalidateArrange may already have been called due to
            // other operations, but calling it again does not hurt, and all of the work will
            // be done in ArrangeOverride regardless of where the invalidation came from.

            if (_animatingElements > 0)
            {
                InvalidateArrange();
            }

            // Restart the storyboard so we get called back on the next frame.
            _tick.Begin();
        }

        /// <summary>
        /// This method is required when subclassing from Panel. It figures out how big the childre are
        /// and where they should go. It attaches an object to each child to hold the data so that the
        /// panel itself does not have to maintain state.
        /// </summary>
        protected override Size MeasureOverride(Size availableSize)
        {
            // Measure each child first. This is inefficient, but it is necessary in order
            // to have smooth animations of new children. Otherwise, the animations may jump 
            // due to the time that template expansion can take.

            foreach (FrameworkElement child in Children)
            {
                child.Measure(availableSize);
            }

            double rowHeight = 0;
            int row = 0;
            _rowHeights.Clear();

            Size desiredSize = Size.Empty;

            Point nextChildPosition = new Point(0, 0);
            DateTime now = DateTime.Now;

            _animatingElements = 0;

            // Now each the position from each child is computed. If the child is not where it is supposed
            // to be, set up a virtual animation to move it there.

            foreach (FrameworkElement child in Children)
            {
                if (nextChildPosition.X + child.DesiredSize.Width > availableSize.Width)
                {
                    // Save old row information
                    _rowHeights.Add(rowHeight);
                    ++row;

                    nextChildPosition.X = 0;
                    nextChildPosition.Y += rowHeight;
                    rowHeight = 0;
                }

                AnimatedWrapPanelAttachedData data = GetAnimatedWrapPanelAttachedData(child);

                // If this is a new element, then start it off of the screen
                if (data.CurrentPosition == AnimatedWrapPanelAttachedData.Unset)
                {
                    data.CurrentPosition = new Point(-child.DesiredSize.Width, -child.DesiredSize.Height);
                }

                if (data.TargetPosition != nextChildPosition)
                {
                    // The target of this element is either brand new or has moved, so we need to 
                    // recalculate everything, and set up a virtual animation.

                    data.StartTime = now;
                    data.StartPosition = data.CurrentPosition;
                    data.TargetPosition = nextChildPosition;
                    data.Row = row;

                    // IsAnimating only gets set to true right here. This begins the virtual animation
                    // for this element.
                    data.IsAnimating = true;

                    ++_animatingElements;
                }
                else if (data.IsAnimating)
                {
                    // This item is still animating, so keep track of it, but since
                    // the target position has not changed, don't do anything else.

                    ++_animatingElements;
                }

                desiredSize.Width = Math.Max(desiredSize.Width, nextChildPosition.X + child.DesiredSize.Width);
                desiredSize.Height = Math.Max(desiredSize.Height, nextChildPosition.Y + child.DesiredSize.Height);

                // Keep track of the maximum height for this line.
                rowHeight = Math.Max(rowHeight, child.DesiredSize.Height);

                // Advance the position of the next element.
                nextChildPosition.X += child.DesiredSize.Width;
            }

            _rowHeights.Add(rowHeight);

            // Debug.WriteLine("Animating {0} elements", _animatingElements);

            return desiredSize;
        }

        /// <summary>
        /// A "normal" ArrangeOverride would just put things where they belong. What this one does
        /// is to move the children towards their destinations according to the virtual animation
        /// data that has been attached to each element. When they get there, the virtual animation
        /// is turned off.
        /// </summary>
        protected override Size ArrangeOverride(Size finalSize)
        {
            DateTime now = DateTime.Now;

            foreach (UIElement child in Children)
            {
                AnimatedWrapPanelAttachedData data = GetAnimatedWrapPanelAttachedData(child);

                TimeSpan elapsed = data.GetElapsed(now);

                if (elapsed < Duration || data.TargetPosition != data.CurrentPosition)
                {
                    // The virtual animation is not done yet, so figure out how far along it is...
                    double progress = (Duration.TimeSpan != TimeSpan.Zero) ? Math.Min(elapsed.TotalMilliseconds / Duration.TimeSpan.TotalMilliseconds, 1.0) : 1;

                    // ...and what the next position is.
                    Point newPosition = BlendPoint(_interpolation, data.StartPosition, data.TargetPosition, progress);
                    child.Arrange(new Rect(newPosition.X, newPosition.Y, child.DesiredSize.Width, _rowHeights[data.Row]));
                    data.CurrentPosition = newPosition;
                }
                else
                {
                    // This element is not animating, but it might have become invalid on its own, so it still
                    // needs to be arranged. The layout system will do as little as possible.
                    child.Arrange(new Rect(data.CurrentPosition.X, data.CurrentPosition.Y, child.DesiredSize.Width, _rowHeights[data.Row]));
                    if (data.IsAnimating)
                    {
                        --_animatingElements;

                        // This is the only place where IsAnimating is set to false. This turns off the virtual animation.
                        data.IsAnimating = false;
                    }
                }
            }

            return finalSize;
        }

        /// <summary>
        /// Given an interpolation, the starting and ending positions and a number from 0-1 that represents how
        /// far along the virtual animation is, calculate the new position.
        /// </summary>
        Point BlendPoint(Interpolation interpolation, Point from, Point to, double progress)
        {
            Point p = new Point();
            double alpha = interpolation.GetAlpha(progress);
            p.X = from.X + alpha * (to.X - from.X);
            p.Y = from.Y + alpha * (to.Y - from.Y);
            return p;
        }

        #region AttachedData DP (private)

        private static AnimatedWrapPanelAttachedData GetAnimatedWrapPanelAttachedData(DependencyObject obj)
        {
            // This uses a standard attached DP lazy-init pattern that will create the default value
            // for this property and set it if GetValue returned null. That means that this method
            // will never return null.

            object value = obj.GetValue(AnimatedWrapPanelAttachedDataProperty);
            if (value == null)
            {
                AnimatedWrapPanelAttachedData data = new AnimatedWrapPanelAttachedData();
                SetAnimatedWrapPanelAttachedData(obj, data);
                return data;
            }
            else
            {
                return (AnimatedWrapPanelAttachedData)value;
            }
        }

        private static void SetAnimatedWrapPanelAttachedData(DependencyObject obj, AnimatedWrapPanelAttachedData value)
        {
            obj.SetValue(AnimatedWrapPanelAttachedDataProperty, value);
        }

        private static readonly DependencyProperty AnimatedWrapPanelAttachedDataProperty =
            DependencyProperty.RegisterAttached("AnimatedWrapPanelAttachedData", typeof(AnimatedWrapPanelAttachedData), typeof(AnimatedWrapPanel), null);

        #endregion

        Duration _duration = new Duration(TimeSpan.FromSeconds(1));
        Interpolation _interpolation = new LinearInterpolation();

        Storyboard _tick;
        int _animatingElements;
        List<double> _rowHeights = new List<double>();

        /// <summary>
        /// This is an attached "property bag". Rather than have an attached property for data item we want to attach,
        /// it is more efficient to make the data items members of a class, and merely attach an instance of the class.
        /// </summary>
        private class AnimatedWrapPanelAttachedData
        {
            public AnimatedWrapPanelAttachedData()
            {
                IsAnimating = true;
                StartPosition = Unset;
                CurrentPosition = Unset;
                TargetPosition = Unset;
            }

            public bool IsAnimating { get; set; }
            public DateTime StartTime { get; set; }
            public Point StartPosition { get; set; }
            public Point CurrentPosition { get; set; }
            public Point TargetPosition { get; set; }
            public int Row { get; set; }

            public TimeSpan GetElapsed(DateTime currentTime) { return currentTime - StartTime; }

            public static readonly Point Unset = new Point(-1, -1);
        }
    }
}
