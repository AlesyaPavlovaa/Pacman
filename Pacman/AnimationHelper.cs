using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Collections.Generic;

public static class AnimationHelper
{
    public static void FadeIn(UIElement element, double durationInSeconds = 0.5)
    {
        DoubleAnimation fadeInAnimation = new DoubleAnimation
        {
            From = 0.0,
            To = 1.0,
            Duration = TimeSpan.FromSeconds(durationInSeconds)
        };
        element.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
    }

    public static void Blink(UIElement element, double durationInSeconds = 0.5)
    {
        DoubleAnimation blinkAnimation = new DoubleAnimation
        {
            From = 1.0,
            To = 0.0,
            AutoReverse = true,
            RepeatBehavior = RepeatBehavior.Forever,
            Duration = TimeSpan.FromSeconds(durationInSeconds)
        };
        element.BeginAnimation(UIElement.OpacityProperty, blinkAnimation);
    }

    public static void ApplyBlinkAnimationByTag(DependencyObject root, string tag, double durationInSeconds = 0.5)
    {
        foreach (var element in FindVisualChildren<UIElement>(root))
        {
            if (element is FrameworkElement frameworkElement && frameworkElement.Tag != null && frameworkElement.Tag.ToString() == tag)
            {
                Blink(frameworkElement, durationInSeconds);
            }
        }
    }

    public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }

                foreach (T childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
}
