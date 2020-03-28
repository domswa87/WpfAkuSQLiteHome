using System.Windows;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface IGraphCalculatorViewModel
    {
        string Division { get; set; }
        string HeadSignB { get; set; }
        string ArmRSignB { get; set; }
        string ArmLSignB { get; set; }
        string LegRSignB { get; set; }
        string LegLSignB { get; set; }
        string Head { get; set; }
        string ArmR { get; set; }
        string ArmL { get; set; }
        string LegR { get; set; }
        string LegL { get; set; }
        string HeadSignS { get; set; }
        string ArmRSignS { get; set; }
        string ArmLSignS { get; set; }
        string LegRSignS { get; set; }
        string LegLSignS { get; set; }
        string HeadUR { get; set; }
        string HeadUL { get; set; }
        string HeadDR { get; set; }
        string HeadDL { get; set; }
        string ArmRUR { get; set; }
        string ArmRUL { get; set; }
        string ArmLUR { get; set; }
        string ArmLUL { get; set; }
        string LegRDR { get; set; }
        string LegRUL { get; set; }
        string LegLUR { get; set; }
        string LegLDL { get; set; }
        string HeadURUnderline { get; set; }
        string HeadULUnderline { get; set; }
        string HeadDRUnderline { get; set; }
        string HeadDLUnderline { get; set; }
        string ArmRURUnderline { get; set; }
        string ArmRULUnderline { get; set; }
        string ArmLURUnderline { get; set; }
        string ArmLULUnderline { get; set; }
        string LegRDRUnderline { get; set; }
        string LegRULUnderline { get; set; }
        string LegLURUnderline { get; set; }
        string LegLDLUnderline { get; set; }
        Visibility Div1 { get; set; }
        Visibility Div2 { get; set; }
        Visibility Div3 { get; set; }
        Visibility Div4 { get; set; }
        Visibility Div5 { get; set; }
        Visibility Div6 { get; set; }
        string HeadDot1 { get; set; }
        string ArmRDot1 { get; set; }
        string ArmLDot1 { get; set; }
        string LegRDot1 { get; set; }
        string LegLDot1 { get; set; }
        string HeadDot2 { get; set; }
        string ArmRDot2 { get; set; }
        string ArmLDot2 { get; set; }
        string LegRDot2 { get; set; }
        string LegLDot2 { get; set; }
        string HeadDot3 { get; set; }
        string ArmRDot3 { get; set; }
        string ArmLDot3 { get; set; }
        string LegRDot3 { get; set; }
        string LegLDot3 { get; set; }
    }
}