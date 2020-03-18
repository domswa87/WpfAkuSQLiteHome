using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfAkuSQLiteHome.Models;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface ITableCalculatorViewModel
    {
        string H1 { get; set; }
        string H2 { get; set; }
        string H3 { get; set; }
        string H4 { get; set; }
        string H5 { get; set; }
        string H6 { get; set; }
        string H7 { get; set; }
        string H8 { get; set; }
        Brush HourGMColor { get; set; }
        Brush HourSteamColor { get; set; }
        Brush HourBranchColor { get; set; }
        string D1 { get; set; }
        string D2 { get; set; }
        string D3 { get; set; }
        string D4 { get; set; }
        string D5 { get; set; }
        string D6 { get; set; }
        string D7 { get; set; }
        string D8 { get; set; }
        Brush DayGMColor { get; set; }
        Brush DaySteamColor { get; set; }
        Brush DayBranchColor { get; set; }
        string M1 { get; set; }
        string M2 { get; set; }
        string M3 { get; set; }
        string M4 { get; set; }
        string M5 { get; set; }
        string M6 { get; set; }
        string M7 { get; set; }
        string M8 { get; set; }
        Brush MonthGMColor { get; set; }
        Brush MonthSteamColor { get; set; }
        Brush MonthBranchColor { get; set; }
        string Y1 { get; set; }
        string Y2 { get; set; }
        string Y3 { get; set; }
        string Y4 { get; set; }
        string Y5 { get; set; }
        string Y6 { get; set; }
        string Y7 { get; set; }
        string Y8 { get; set; }
        Brush YearGMColor { get; set; }
        Brush YearSteamColor { get; set; }
        Brush YearBranchColor { get; set; }
    }
}
