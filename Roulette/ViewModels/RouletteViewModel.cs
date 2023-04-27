using Roulette.Models;
using Roulette.Aids;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roulette.ViewModels
{
    public class RouletteViewModel
    {
        public RouletteModel RouletteModel { get; init; }
        public StandardBoxesViewModel StandardBoxesVM { get; set; }
        public SpecialBoxesViewModel SpecialBoxesVM { get; set; }
        public PopupViewModel PopupVM { get; set; }
        public List<SpecialBoxViewModel> ChangedSpecialBoxes { get; set; }
        public StandardBoxViewModel? ChangedStandardBox { get; set; }
        public RouletteViewModel()
        {
            ChangedSpecialBoxes = new();
            RouletteModel = new();
            StandardBoxesVM = InitializeStandardBoxesVM();
            SpecialBoxesVM = InitializeSpecialBoxesVM();
            PopupVM = InitializePopupVM();
            RouletteModel.OnWinningNumberCame += RouletteModel_OnWinningNumberCame;
            RouletteModel.On10SecondsPassed += RouletteModel_On10SecondsPassed;
        }

        private void RouletteModel_On10SecondsPassed(object? sender, int number)
        {
            foreach (var specialBox in ChangedSpecialBoxes)
            {
                SpecialBoxesVM.SpecialBoxes[specialBox.Name].BackgroundColor = specialBox.BackgroundColor;
                SpecialBoxesVM.SpecialBoxes[specialBox.Name].BorderColor = specialBox.BorderColor;
                SpecialBoxesVM.SpecialBoxes[specialBox.Name].ForegroundColor = specialBox.ForegroundColor;
            }
            StandardBoxesVM.StandardBoxes[number].BackgroundColor = ChangedStandardBox.BackgroundColor;
            StandardBoxesVM.StandardBoxes[number].BorderColor = ChangedStandardBox.BorderColor;
            StandardBoxesVM.StandardBoxes[number].ForegroundColor = ChangedStandardBox.ForegroundColor;
            PopupVM.IsVisible = false;
        }

        private void RouletteModel_OnWinningNumberCame(object? sender, int number)
        {
            ChangeStyleOfWinningBoxes(number);
        }

        private StandardBoxesViewModel InitializeStandardBoxesVM()
        {
            return new StandardBoxesViewModel(RouletteModel.GetStandardBoxModels());
        }

        private SpecialBoxesViewModel InitializeSpecialBoxesVM()
        {
            return new SpecialBoxesViewModel(RouletteModel.GetSpecialBoxModels());
        }

        private PopupViewModel InitializePopupVM()
        {
            return new PopupViewModel(RouletteModel.GetPopupModel());
        }

        private void ChangeStyleOfWinningBoxes(int number)
        {
            StandardBoxViewModel winningStandardBox = StandardBoxesVM.StandardBoxes[number];
            ChangedStandardBox = new StandardBoxViewModel(new StandardBoxModel()
            {
                BackgroundColor = winningStandardBox.BackgroundColor,
                ForegroundColor = winningStandardBox.ForegroundColor,
                BorderColor = winningStandardBox.BorderColor,
                Number = number,
                RowNumber = winningStandardBox.RowNumber,
                ColumnNumber = winningStandardBox.ColumnNumber
            });
            ChangedSpecialBoxes.Clear();
            List<string> winningPositions = new();

            winningStandardBox.BackgroundColor = Constants.Blue;
            winningStandardBox.ForegroundColor = Constants.Black;
            winningStandardBox.BorderColor = Constants.White;
            if (number != 0)
            {
                winningPositions.Add(GetWinningColor(ChangedStandardBox));
                winningPositions.Add(GetWinningColumn(ChangedStandardBox));
                winningPositions.Add(GetWinningOddOrEven(ChangedStandardBox));
                winningPositions.Add(GetWinningHighOrLow(ChangedStandardBox));
                winningPositions.Add(GetWinningDozen(ChangedStandardBox));
            }
            ChangesStyleOfPopup(ChangedStandardBox, winningPositions);
        }

        private void ChangesStyleOfPopup(StandardBoxViewModel winningStandardBox, List<string> winningPositions)
        {
            PopupVM.WinningNumber = winningStandardBox.Number;
            PopupVM.WinningPositions = winningPositions;
            PopupVM.BackgroundColor = winningStandardBox.BackgroundColor;
            PopupVM.ForegroundColor = winningStandardBox.ForegroundColor;
            PopupVM.IsVisible = true;
        }

        private string GetWinningColor(StandardBoxViewModel winningStandardBox)
        {
            var backgroundColor = winningStandardBox.BackgroundColor;
            if (backgroundColor == Constants.Red)
            {
                HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("NamelessRed"));
                return "Red";
            }
            HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("NamelessBlack"));
            return "Black";
        }

        private string GetWinningColumn(StandardBoxViewModel winningStandardBox)
        {
            var rouletteColumn = winningStandardBox.RowNumber;
            switch (rouletteColumn)
            {
                case 0:
                    HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("1st Column"));
                    return "Column C";
                case 1:
                    HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("2nd Column"));
                    return "Column B";
                default:
                    HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("3rd Column"));
                    return "Column A";
            }
        }

        private string GetWinningOddOrEven(StandardBoxViewModel winningStandardBox)
        {
            var number = winningStandardBox.Number;
            if (number % 2 == 0)
            {
                HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("Even"));
                return "Even";
            }
            HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("Odd"));
            return "Odd";
        }

        private string GetWinningHighOrLow(StandardBoxViewModel winningStandardBox)
        {
            var number = winningStandardBox.Number;
            if (number < 19)
            {
                HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("1 to 18"));
                return "Low";
            }
            HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("19 to 36"));
            return "High";
        }

        private string GetWinningDozen(StandardBoxViewModel winningStandardBox)
        {
            var number = winningStandardBox.Number;
            switch (number)
            {
                case < 13:
                    HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("1st 12"));
                    return "1st Dozen";
                case < 25:
                    HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("2nd 12"));
                    return "2nd Dozen";
                default:
                    HighlightSpecialBox(SpecialBoxesVM.GetSpecialBox("3rd 12"));
                    return "3rd Dozen";
            }
        }

        private void HighlightSpecialBox(SpecialBoxViewModel winningSpecialBox)
        {
            ChangedSpecialBoxes.Add(new SpecialBoxViewModel(new SpecialBoxModel()
            {
                BackgroundColor = winningSpecialBox.BackgroundColor,
                ForegroundColor = winningSpecialBox.ForegroundColor,
                BorderColor = winningSpecialBox.BorderColor,
                Name = winningSpecialBox.Name
            }));

            winningSpecialBox.BackgroundColor = Constants.Blue;
            winningSpecialBox.ForegroundColor = Constants.Black;
            winningSpecialBox.BorderColor = Constants.White;
        }
    }
}
