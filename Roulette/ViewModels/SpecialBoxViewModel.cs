using Roulette.Models;

namespace Roulette.ViewModels
{
    public class SpecialBoxViewModel : BoxViewModel
    {
        private readonly SpecialBoxModel SpecialBox;
        public SpecialBoxViewModel(SpecialBoxModel specialBox) : base(specialBox)
        {
            SpecialBox = specialBox;
        }

        public string? Name => SpecialBox.Name;
    }
}
