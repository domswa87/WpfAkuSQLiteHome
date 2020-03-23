using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    class ScrollCalculatorViewModel : Conductor<object>.Collection.AllActive, IScrollCalculatorViewModel
    {
        public IGraphCalculatorViewModel GraphCalculatorViewModel { get; }
        public ITableCalculatorViewModel TableCalculatorViewModel { get; }

        public ScrollCalculatorViewModel(IGraphCalculatorViewModel graphCalculatorViewModel, ITableCalculatorViewModel tableCalculatorViewModel)
        {
            GraphCalculatorViewModel = graphCalculatorViewModel;
            TableCalculatorViewModel = tableCalculatorViewModel;
        }


    }
}
