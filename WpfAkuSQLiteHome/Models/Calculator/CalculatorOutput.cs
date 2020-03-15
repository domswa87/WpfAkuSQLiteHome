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
    public class FinalOutput : INotifyPropertyChanged
    {
        public ColumnCLass Hour { get; set; }
        public ColumnCLass Day { get; set; }
        public ColumnCLass Month { get; set; }
        public ColumnCLass Year { get; set; }
        public DateTime GivenDate { get; set; }
        public AdditionalInfo AdditionalInfo { get; set; }



        public FinalOutput(DateTime givenDate)
        {
            this.Year = new ColumnCLass();
            this.Month = new ColumnCLass();
            this.Day = new ColumnCLass();
            this.Hour = new ColumnCLass();
            this.GivenDate = givenDate;
            this.AdditionalInfo = new AdditionalInfo();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertname));
            }
        }
    }

    public class ColumnCLass : INotifyPropertyChanged
    {

        private SolidColorBrush _gmcolour;
        public SolidColorBrush GMColour
        { get { return _gmcolour; } set { _gmcolour = value; OnPropertyRaised("GMColour"); } }


        private SymbolClass _steam;
        public SymbolClass Steam
        { get { return _steam; } set { _steam = value; OnPropertyRaised("Steam"); } }


        private SymbolClass _branch;
        public SymbolClass Branch
        { get { return _branch; } set { _branch = value; OnPropertyRaised("Branch"); } }


        private string _belowRowTable;
        public string BelowRowTable
        { get { return _belowRowTable; } set { _belowRowTable = value; OnPropertyRaised("BelowRowTable"); } }


        public ColumnCLass()
        {
            this.Steam = new SymbolClass();
            this.Branch = new SymbolClass();
            this.GMColour = null;
            this.BelowRowTable = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertname));
            }
        }
    }

    public class SymbolClass : INotifyPropertyChanged
    {
        public SymbolClass()
        {
            this.ChineseSign = null;
            this.ChineseString = null;
            this.EnglishString = null;
            this.Colour = null;
        }


        private string _chineseSign;
        public string ChineseSign
        { get { return _chineseSign; } set { _chineseSign = value; OnPropertyRaised("ChineseSign"); } }


        private string _chineseString;
        public string ChineseString
        { get { return _chineseString; } set { _chineseString = value; OnPropertyRaised("ChineseString"); } }


        private string _englishString;
        public string EnglishString
        { get { return _englishString; } set { _englishString = value; OnPropertyRaised("EnglishString"); } }


        private SolidColorBrush _colour;
        public SolidColorBrush Colour
        { get { return _colour; } set { _colour = value; OnPropertyRaised("Colour"); } }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertname));
            }
        }
    }
   

    public class AdditionalInfo
    {
        public string Division { get; set; }
        public string CorrectiveEnergy { get; set; }
        public string Season { get; set; }

        public string Forbidden { get; set; }
        public string ForbiddenMeridians { get; set; }
        public string ForbiddenRegion { get; set; }

        public string Hsiu { get; set; }
        public string Planet { get; set; }
        public string Points { get; set; }

    }
}
