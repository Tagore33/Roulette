using Roulette.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Roulette.ViewModels
{
    public class StandardBoxesViewModel
    {
        public ObservableCollection<StandardBoxViewModel> StandardBoxes { get; }
        public StandardBoxesViewModel(IEnumerable<StandardBoxModel> standardBoxes)
        {
            StandardBoxes = new ObservableCollection<StandardBoxViewModel>(standardBoxes.Select(b => new StandardBoxViewModel(b)));
        }
    }
}
