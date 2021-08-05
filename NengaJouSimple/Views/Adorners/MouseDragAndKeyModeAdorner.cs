using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace NengaJouSimple.Views.Adorners
{
    public class MouseDragAndKeyModeAdorner : Adorner
    {
        public static readonly DependencyProperty CurrentPositionProperty =
            DependencyProperty.Register(nameof(CurrentPosition), typeof(Point), typeof(MouseDragAndKeyModeAdorner), new FrameworkPropertyMetadata(default(Point), FrameworkPropertyMetadataOptions.AffectsRender));

        private readonly UIElement adornedElement;

        public MouseDragAndKeyModeAdorner(Point positon, UIElement adornedElement)
            : base(adornedElement)
        {
            CurrentPosition = positon;
            this.adornedElement = adornedElement;

            if (adornedElement is FrameworkElement adornedFrameworkElement)
            {
                adornedFrameworkElement.FocusVisualStyle = null;
            }

            // クリックなどのコントロールイベントを適応しない
            IsHitTestVisible = false;
        }

        public Point CurrentPosition
        {
            get { return (Point)GetValue(CurrentPositionProperty); }
            set { SetValue(CurrentPositionProperty, value); }
        }

        public bool IsAttached { get; private set; }

        public void UpdatePosition(Point position)
        {
            CurrentPosition = position;
        }

        public void Attach()
        {
            if (!IsAttached)
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(adornedElement);

                if (adornerLayer != null)
                {
                    adornerLayer.Add(this);
                    IsAttached = true;
                }
            }
        }

        public void Detach()
        {
            if (IsAttached)
            {
                var adornerLayer = AdornerLayer.GetAdornerLayer(adornedElement);

                if (adornerLayer != null)
                {
                    adornerLayer.Remove(this);
                    IsAttached = false;
                }
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var rect = new Rect(AdornedElement.RenderSize);

            var renderBrush = new SolidColorBrush(Colors.Transparent);
            var pen = new Pen(new SolidColorBrush(Colors.Gray), 1)
            {
                DashStyle = new DashStyle(new[] { 5.0 }, 2),
            };

            drawingContext.DrawRectangle(renderBrush, pen, rect);
        }
    }
}
