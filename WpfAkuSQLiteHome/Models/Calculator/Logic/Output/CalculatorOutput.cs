using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfAkuSQLiteHome.Models.Calculator;

namespace WpfAkuSQLiteHome.Models
{
    public class CalculatorOutput 
    {
        public ColumnCLass Hour { get; set; }
        public ColumnCLass Day { get; set; }
        public ColumnCLass Month { get; set; }
        public ColumnCLass Year { get; set; }
        public AdditionalInfo AdditionalInfo { get; set; }


        public CalculatorOutput()
        {
            this.Year = new ColumnCLass();
            this.Month = new ColumnCLass();
            this.Day = new ColumnCLass();
            this.Hour = new ColumnCLass();
            this.AdditionalInfo = new AdditionalInfo();
        }
    }

    public class ColumnCLass 
    {
        public SolidColorBrush GMColour { get; set; }
        public SymbolClass Steam { get; set; }
        public SymbolClass Branch { get; set; }
        public string BelowRowTable { get; set; }

        public ColumnCLass()
        {
            this.Steam = new SymbolClass();
            this.Branch = new SymbolClass();
            this.GMColour = null;
            this.BelowRowTable = null;
        }
    }

    public class SymbolClass 
    {
        public SymbolClass()
        {
            this.ChineseSign = null;
            this.ChineseString = null;
            this.EnglishString = null;
            this.Colour = null;
        }

        public string ChineseSign { get; set; }
        public string ChineseString { get; set; }
        public string EnglishString { get; set; }
        public SolidColorBrush Colour { get; set; }
    }
   

    public class AdditionalInfo
    {
        public AdditionalInfo()
        {
            this.Division = null;
            this.CorrectiveEnergy = null;
        }

        public string Division { get; set; } 
        public string CorrectiveEnergy { get; set; }
        public string Season { get; set; } = null;

        public string Forbidden { get; set; }
        public string ForbiddenMeridians1 { get; set; }
        public string ForbiddenMeridians2 { get; set; }
        public string ForbiddenRegion { get; set; }
        public Hsiu Hsiu { get; set; } = new Hsiu();
    }

    public class Hsiu
    {
        public string Animal { get; set; }
        public string Direction { get; set; }
        public string Element { get; set; }
        public string Planet { get; set; }
        public string Elts { get; set; }
        public string Points { get; set; }
    }
}
