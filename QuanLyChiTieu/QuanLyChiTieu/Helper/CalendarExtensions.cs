using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace QuanLyChiTieu.Helper
{
    public static class CalendarExtensions
    {
        public static readonly DependencyProperty AutoReleaseMouseProperty =
            DependencyProperty.RegisterAttached(
                "AutoReleaseMouse",
                typeof(bool),
                typeof(CalendarExtensions),
                new PropertyMetadata(false, OnAutoReleaseMouseChanged));

        public static bool GetAutoReleaseMouse(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoReleaseMouseProperty);
        }

        public static void SetAutoReleaseMouse(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoReleaseMouseProperty, value);
        }

        private static void OnAutoReleaseMouseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Calendar calendar)
            {
                bool newValue = (bool)e.NewValue;
                if (newValue)
                {
                    calendar.GotMouseCapture += OnCalendarGotMouseCapture;
                }
                else
                {
                    calendar.GotMouseCapture -= OnCalendarGotMouseCapture;
                }
            }
        }

        private static void OnCalendarGotMouseCapture(object sender, MouseEventArgs e)
        {
            if (e.OriginalSource is CalendarDayButton || e.OriginalSource is CalendarItem)
            {
                Mouse.Capture(null);
            }
        }
    }
}
