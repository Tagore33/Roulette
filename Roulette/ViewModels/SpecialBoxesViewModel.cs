using NSwag.Collections;
using Roulette.Models;
using System.Collections.Generic;

namespace Roulette.ViewModels
{
    public class SpecialBoxesViewModel
    {
        public ObservableDictionary<string, SpecialBoxViewModel>? SpecialBoxes { get; }
        public SpecialBoxesViewModel(IEnumerable<SpecialBoxModel> specialBoxes)
        {
            SpecialBoxes = new();
            foreach (var sb in specialBoxes)
            {
                if (sb.Name != null)
                    SpecialBoxes?.Add(sb.Name, new SpecialBoxViewModel(sb));
            }
        }

        public SpecialBoxViewModel GetSpecialBox(string key)
        {
            return SpecialBoxes[key];
        }
    }
}
