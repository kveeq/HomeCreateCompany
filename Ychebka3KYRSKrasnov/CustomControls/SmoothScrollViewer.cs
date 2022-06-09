using System.Windows;
using System.Windows.Controls;

namespace RichTextBoxDemo.SmoothScroll
{
    public class SmoothScrollViewer : ScrollViewer
    {
        /// <summary>
        /// Вертикальная нормализованная длина шага
        /// </summary>
        public double VerticalScrollRatio
        {
            get { return (double)GetValue(VerticalScrollRatioProperty); }
            set { SetValue(VerticalScrollRatioProperty, value); }
        }

        // Регистрируем свойство зависимости VerticalScrollRatio
        public static readonly DependencyProperty VerticalScrollRatioProperty =
            DependencyProperty.Register("VerticalScrollRatio", typeof(double), typeof(SmoothScrollViewer), new PropertyMetadata(0.0, new PropertyChangedCallback(V_ScrollRatioChangedCallBack)));

        private static void V_ScrollRatioChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = (ScrollViewer)(d);
            if (scrollViewer != null)
            {
                scrollViewer.ScrollToVerticalOffset((double)(e.NewValue) * scrollViewer.ScrollableHeight);
            }
        }

        /// <summary>
        /// Горизонтальная нормализованная длина шага
        /// </summary>
        public double HorizontalScrollRatio
        {
            get { return (double)GetValue(HorizontalScrollRatioProperty); }
            set { SetValue(HorizontalScrollRatioProperty, value); }
        }

        // Регистрируем свойство зависимости HorizontalScrollRatio
        public static readonly DependencyProperty HorizontalScrollRatioProperty =
            DependencyProperty.Register("HorizontalScrollRatio", typeof(double), typeof(SmoothScrollViewer), new PropertyMetadata(0.0, new PropertyChangedCallback(H_ScrollRatioChangedCallBack)));

        private static void H_ScrollRatioChangedCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = (ScrollViewer)(d);
            if (scrollViewer != null)
            {
                scrollViewer.ScrollToHorizontalOffset((double)(e.NewValue) * scrollViewer.ScrollableWidth);
            }
        }
    }
}