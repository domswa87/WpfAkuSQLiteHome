using WpfAkuSQLiteHome.Models;
using WpfAkuSQLiteHome.Models.Calculator;

namespace WpfAkuSQLiteHome.ViewModels
{
    public interface IScrollCalculatorViewModel
    {
        ITableCalculatorViewModel TableCalculatorViewModel { get; }
        ITableRestCalculatorViewModel TableRestCalculatorViewModel { get; }

        void UpdateTableRestViewModel(CalculatorOutput CalculatorOutput);
        void UpdateTableViewModel(CalculatorOutput CalculatorOutput);
        void UpdateGraphViewModel(GraphModel GraphModel);
        void UpdateMissingElementsViewModel(MissingElementModel MissingElementModel);
    }
}