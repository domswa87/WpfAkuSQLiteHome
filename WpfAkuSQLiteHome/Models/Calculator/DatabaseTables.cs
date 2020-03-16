using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.Models
{
    public class BranchTable
    {
        public Int64? Branches { get; set; }

        public String Symbol1 { get; set; }

        public String Symbol2 { get; set; }

        public String Symbol3 { get; set; }

        public String Colour { get; set; }

        public String BelowTableRow { get; set; }


    }

    public class DayTable
    {
        public Int64? Day { get; set; }

        public String Symbol1 { get; set; }

        public String Symbol2 { get; set; }

        public String Rest { get; set; }

    }

    public class DivisionTable
    {
        public Int64? Divisions { get; set; }

        public String Symbol1 { get; set; }

        public String Symbol2 { get; set; }

    }

    public class HsiuTable
    {
        public Int64? Hsiu { get; set; }

        public String Animal { get; set; }

        public String Direction { get; set; }

        public String Element { get; set; }

        public String Planet { get; set; }

        public String Elts { get; set; }

        public String Rest { get; set; }

    }

    public class SeasonTable
    {
        public Int64? Id { get; set; }

        public String Seasons { get; set; }

        public Int64? day { get; set; }

        public Int64? month { get; set; }

        public String Forbidden { get; set; }

    }

    public class StemsTable
    {
        public Int64? StemsID { get; set; }

        public String StemsSymbol1 { get; set; }

        public String StemsSymbol2 { get; set; }

        public String StemsSymbol3 { get; set; }

        public String StemColour { get; set; }

        public String GMColour { get; set; }

    }

    public class YearTable
    {
        public Int64? Id { get; set; }

        public String P1 { get; set; }

        public String P2 { get; set; }

        public String P3 { get; set; }

        public String P4 { get; set; }

        public String P5 { get; set; }

        public String P6 { get; set; }

        public String P7 { get; set; }

        public String P8 { get; set; }

        public String P9 { get; set; }

        public String P10 { get; set; }

        public String P11 { get; set; }

        public String P12 { get; set; }

        public String NextYear { get; set; }

    }
}
