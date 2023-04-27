using System.Collections.Generic;

namespace Roulette.Models
{
    public class PopupModel
    {
        public int WinningNumber { get; set; }
        public List<string> WinningPositions { get; set; }
        public PopupModel()
        {
            WinningPositions = new();
        }
        public string? BackgroundColor { get; set; }
        public string? ForegroundColor { get; set; }
        public bool IsVisible { get; set; }
    }
}
