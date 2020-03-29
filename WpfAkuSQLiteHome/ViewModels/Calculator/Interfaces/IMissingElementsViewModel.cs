using System.Windows;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface IMissingElementsViewModel
    {
        string EL1 { get; set; }
        string EL2 { get; set; }
        string EL3 { get; set; }
        string EL4 { get; set; }
        string EL5 { get; set; }
        string EM1 { get; set; }
        string EM2 { get; set; }
        string EM3 { get; set; }
        string EM4 { get; set; }
        string EM5 { get; set; }
        string MissingOrgans { get; set; }
        TextDecorationCollection EL1Underline { get; set; }
        TextDecorationCollection EL2Underline { get; set; }
        TextDecorationCollection EL3Underline { get; set; }
        TextDecorationCollection EL4Underline { get; set; }
        TextDecorationCollection EL5Underline { get; set; }
        TextDecorationCollection EM1Underline { get; set; }
        TextDecorationCollection EM2Underline { get; set; }
        TextDecorationCollection EM3Underline { get; set; }
        TextDecorationCollection EM4Underline { get; set; }
        TextDecorationCollection EM5Underline { get; set; }
    }
}