using Microsoft.Xaml.Behaviors;
using NengaJouSimple.Views.Adorners;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace NengaJouSimple.Views.Behaviors
{
    public class MouseDragAndKeyMoveBehavior : Behavior<FrameworkElement>
    {
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register(nameof(X), typeof(double), typeof(MouseDragAndKeyMoveBehavior), new PropertyMetadata(0.0, new PropertyChangedCallback(OnXChanged)));

        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register(nameof(Y), typeof(double), typeof(MouseDragAndKeyMoveBehavior), new PropertyMetadata(0.0, new PropertyChangedCallback(OnYChanged)));

        private bool isUpdatingPosition;

        private Point dragStartPosition;

        private MouseDragAndKeyModeAdorner mouseDragAndKeyModeAdorner;

        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnMouseLeftButtonDown), false);
            AssociatedObject.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(OnKeyDown), false);
            AssociatedObject.AddHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnSizeChanged), false);
            AssociatedObject.AddHandler(UIElement.PreviewGotKeyboardFocusEvent, new RoutedEventHandler(OnPreviewGotKeyboardFocus), false);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.RemoveHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(OnMouseLeftButtonDown));
            AssociatedObject.RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(OnKeyDown));
            AssociatedObject.RemoveHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(OnSizeChanged));
            AssociatedObject.RemoveHandler(UIElement.PreviewGotKeyboardFocusEvent, new RoutedEventHandler(OnPreviewGotKeyboardFocus));
        }

        private static void OnXChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mouseDragAndKeyMoveBehavior = (MouseDragAndKeyMoveBehavior)sender;

            if (mouseDragAndKeyMoveBehavior.AssociatedObject != null)
            {
                mouseDragAndKeyMoveBehavior.Translate();
            }
        }

        private static void OnYChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var mouseDragAndKeyMoveBehavior = (MouseDragAndKeyMoveBehavior)sender;

            if (mouseDragAndKeyMoveBehavior.AssociatedObject != null)
            {
                mouseDragAndKeyMoveBehavior.Translate();
            }
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AssociatedObject.Focus();

            StartDrag(e.GetPosition(AssociatedObject));
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AssociatedObject.ReleaseMouseCapture();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            HandleDrag(e.GetPosition(AssociatedObject));
        }

        private void OnLostMouseCapture(object sender, MouseEventArgs e)
        {
            EndDrag();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Tab)
            {
                e.Handled = true;
            }

            TranslateByKey(e.Key);
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Translate();
        }

        private void OnPreviewGotKeyboardFocus(object sender, RoutedEventArgs e)
        {
            if (mouseDragAndKeyModeAdorner == null)
            {
                mouseDragAndKeyModeAdorner = new MouseDragAndKeyModeAdorner(new Point(X, Y), AssociatedObject);
                mouseDragAndKeyModeAdorner.Attach();
            }

            AssociatedObject.AddHandler(UIElement.PreviewLostKeyboardFocusEvent, new RoutedEventHandler(OnPreviewLostKeyboardFocus), false);
        }

        private void OnPreviewLostKeyboardFocus(object sender, RoutedEventArgs e)
        {
            if (mouseDragAndKeyModeAdorner != null)
            {
                if (mouseDragAndKeyModeAdorner.IsAttached)
                {
                    mouseDragAndKeyModeAdorner.Detach();
                }

                mouseDragAndKeyModeAdorner = null;
            }

            AssociatedObject.RemoveHandler(UIElement.PreviewLostKeyboardFocusEvent, new RoutedEventHandler(OnPreviewLostKeyboardFocus));
        }

        private void StartDrag(Point dragStartPosition)
        {
            if (AssociatedObject.CaptureMouse())
            {
                AssociatedObject.MouseLeftButtonUp += OnMouseLeftButtonUp;
                AssociatedObject.MouseMove += OnMouseMove;
                AssociatedObject.LostMouseCapture += OnLostMouseCapture;

                this.dragStartPosition = dragStartPosition;

                AssociatedObject.Focus();
            }
        }

        private void HandleDrag(Point currentMousePosition)
        {
            if (AssociatedObject.Parent is Visual parentElement)
            {
                var vector = currentMousePosition - dragStartPosition;
                var endPosition = AssociatedObject.TransformToVisual(parentElement).Transform((Point)vector);

                Translate(endPosition);
            }
        }

        private void EndDrag()
        {
            AssociatedObject.MouseLeftButtonUp -= OnMouseLeftButtonUp;
            AssociatedObject.MouseMove -= OnMouseMove;
            AssociatedObject.LostMouseCapture -= OnLostMouseCapture;
        }

        private void TranslateByKey(Key key)
        {
            var currentPosition = new Point(X, Y);

            switch (key)
            {
                case Key.Left:
                    currentPosition.Offset(-1, 0);
                    break;
                case Key.Right:
                    currentPosition.Offset(1, 0);
                    break;
                case Key.Up:
                    currentPosition.Offset(0, -1);
                    break;
                case Key.Down:
                    currentPosition.Offset(0, 1);
                    break;
            }

            if (currentPosition != new Point(X, Y))
                Translate(currentPosition);
        }

        private void Translate(Point position)
        {
            UpdatePosition(position.X, position.Y);

            Translate();
        }

        private void UpdatePosition(double x, double y)
        {
            if (x == X && y == Y) return;

            isUpdatingPosition = true;

            if (x != X) X = x;
            if (y != Y) Y = y;

            isUpdatingPosition = false;
        }

        private void Translate()
        {
            if (isUpdatingPosition) return;

            ConfineInParentElementBouds();

            var translate = AssociatedObject.RenderTransform as TranslateTransform;

            if (translate is null)
            {
                translate = new TranslateTransform();
                AssociatedObject.RenderTransform = translate;
            }

            translate.X = X;
            translate.Y = Y;

            UpdateAdornerPosition();
        }

        private void ConfineInParentElementBouds()
        {
            if (AssociatedObject.Parent is FrameworkElement parentElement)
            {
                var x = X;
                var y = Y;

                if (AssociatedObject.ActualWidth < parentElement.ActualWidth)
                {
                    if (x < 0)
                    {
                        x = 0;
                    }
                    else if (x + AssociatedObject.ActualWidth > parentElement.ActualWidth)
                    {
                        x = parentElement.ActualWidth - AssociatedObject.ActualWidth;
                    }
                }

                if (AssociatedObject.ActualHeight < parentElement.ActualHeight)
                {
                    if (y < 0)
                    {
                        y = 0;
                    }
                    else if (y + AssociatedObject.ActualHeight > parentElement.ActualHeight)
                    {
                        y = parentElement.ActualHeight - AssociatedObject.ActualHeight;
                    }
                }

                UpdatePosition(x, y);
            }
        }

        private void UpdateAdornerPosition()
        {
            if (mouseDragAndKeyModeAdorner != null && mouseDragAndKeyModeAdorner.IsAttached)
            {
                mouseDragAndKeyModeAdorner.UpdatePosition(new Point(X, Y));
            }
        }
    }
}
