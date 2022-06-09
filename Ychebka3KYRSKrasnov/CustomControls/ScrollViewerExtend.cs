using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace RichTextBoxDemo.SmoothScroll
{
    public static class ScrollViewerExtend
    {
        /// <summary>
        /// Обеспечение плавной прокрутки ScrollViewer
        /// </summary>
        /// <param name="scrollViewer"></param>
        /// <param name = "ScrollStepRatio"> Нормализованная длина шага </param>
        /// <param name = "ScrollPositionRatio"> Нормализованное положение </param>
        /// <param name = "direction"> Направление прокрутки </param>
        public static void SmoothScroll(this SmoothScrollViewer scrollViewer, double ScrollStepRatio, double ScrollPositionRatio, ScrollDirection direction)
        {
            if (double.IsNaN(ScrollStepRatio) || double.IsNaN(ScrollPositionRatio))
                return;
            DoubleAnimation Animation = new DoubleAnimation();

            Animation.From = ScrollPositionRatio;
            if (ScrollDirection.Down == direction || ScrollDirection.Right == direction)
            {
                double To = ScrollPositionRatio + ScrollStepRatio;
                Animation.To = To > 0.95 ? 1.0 : To; // Компенсация прокрутки вниз (вправо)
            }
            else if (ScrollDirection.Up == direction || ScrollDirection.Left == direction)
            {
                double To = ScrollPositionRatio - ScrollStepRatio;
                Animation.To = To < 0.05 ? 0.0: To; // Компенсация прокрутки вверх (влево)
            }
            Animation.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(Animation);
            Storyboard.SetTarget(Animation, scrollViewer);
            if (ScrollDirection.Down == direction || ScrollDirection.Up == direction)
                Storyboard.SetTargetProperty(Animation, new PropertyPath(SmoothScrollViewer.VerticalScrollRatioProperty));
            else if (ScrollDirection.Right == direction || ScrollDirection.Left == direction)
                Storyboard.SetTargetProperty(Animation, new PropertyPath(SmoothScrollViewer.HorizontalScrollRatioProperty));
            storyboard.Begin();
        }
    }

    public enum ScrollDirection
    {
        Up, Down, Left, Right
    }
}