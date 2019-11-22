using System;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface IDayViewModel
    {
        string DateString { get; set; }
        string DayString { get; set; }
        DateTime DatePickerDS { get; set; }
    }
}