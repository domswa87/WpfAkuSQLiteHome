using System;
using System.Windows;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface IDayViewModel
    {
        string DateString { get; set; }
        string DayString { get; set; }
        void LoadEvents();
        void ClearSelection();
        DateTime ActualDay { get; set; }
        Visibility VisibilityConfirmationWindow { get; set; }
    }
}