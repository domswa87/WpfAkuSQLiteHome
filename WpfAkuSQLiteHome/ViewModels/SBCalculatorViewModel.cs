using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAkuSQLiteHome.ViewModels
{
    public class SBCalculatorViewModel : Conductor<object>.Collection.AllActive, ISBCalculatorViewModel
    {

        public ISetBirthDateViewModel SetBirthDateViewModel { get; }
        public ISBTableVIewModel SBTableVIewModel { get; }

        public SBCalculatorViewModel(ISetBirthDateViewModel setBirthDateViewModel, ISBTableVIewModel sBTableVIewModel)
        {
            SetBirthDateViewModel = setBirthDateViewModel;
            SBTableVIewModel = sBTableVIewModel;
        }
    }
}
