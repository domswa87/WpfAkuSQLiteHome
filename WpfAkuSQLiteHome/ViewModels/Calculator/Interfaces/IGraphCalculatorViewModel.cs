namespace WpfAkuSQLiteHome.ViewModels
{
    public interface IGraphCalculatorViewModel
    {
        string Head { get; set; }
        string HeadUR { get; set; }
        string HeadUL { get; set; }
        string HeadDR { get; set; }
        string HeadDL { get; set; }
        string ArmR { get; set; }
        string ArmRUR { get; set; }
        string ArmRUL { get; set; }
        string ArmL { get; set; }
        string ArmLUR { get; set; }
        string ArmLUL { get; set; }
        string LegR { get; set; }
        string LegRDR { get; set; }
        string LegRUL { get; set; }
        string LegL { get; set; }
        string LegLUR { get; set; }
        string LegLDL { get; set; }
        int HeadFontSize { get; set; }
        int ArmRFontSize { get; set; }
        int ArmLFontSize { get; set; }
        int LegLFontSize { get; set; }
        int LegRFontSize { get; set; }
    }
}