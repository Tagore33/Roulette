using Roulette.Models;

namespace Roulette.ViewModels
{
    public class StandardBoxViewModel : BoxViewModel
    {
        private readonly StandardBoxModel StandardBox;
        public StandardBoxViewModel(StandardBoxModel standardBox) : base(standardBox)
        {
            StandardBox = standardBox;
        }

        public int Number => StandardBox.Number;
        public int ColumnNumber => StandardBox.ColumnNumber;
        public int RowNumber => StandardBox.RowNumber;

    }
}
