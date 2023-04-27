using Roulette.Models;
using System.Collections.Generic;

namespace Roulette.Aids
{
    public static class UIElementsFactory
    {
        private static List<StandardBoxModel> StandardBoxes { get; set; }
        private static List<SpecialBoxModel> SpecialBoxes { get; set; }
        private static PopupModel Popup { get; set; }
        static UIElementsFactory()
        {
            StandardBoxes = CreateStandardBoxes();
            SpecialBoxes = CreateSpecialBoxes();
            Popup = CreatePopup();
        }

        public static List<StandardBoxModel> GetStandardBoxes()
        {
            return StandardBoxes;
        }

        public static List<SpecialBoxModel> GetSpecialBoxes()
        {
            return SpecialBoxes;
        }

        public static PopupModel GetPopup()
        {
            return Popup;
        }

        private static List<StandardBoxModel> CreateStandardBoxes()
        {
            List<StandardBoxModel> generatedBoxes = new();
            for (int i = 0; i <= 36; i++)
            {
                switch (i)
                {
                    case < 1:
                        generatedBoxes.Add(new StandardBoxModel() { Number = i, BackgroundColor = "#00FF00", BorderColor = "#00FF00", ForegroundColor = Constants.White, ColumnNumber = 0, RowNumber = 0 });
                        break;
                    case < 10:
                        generatedBoxes.Add(CreateStandardBox(i));
                        break;
                    case < 19:
                        generatedBoxes.Add(CreateStandardBoxWithException(i, 10));
                        break;
                    case < 28:
                        generatedBoxes.Add(CreateStandardBox(i));
                        break;
                    default:
                        generatedBoxes.Add(CreateStandardBoxWithException(i, 28));
                        break;
                }
            }
            return SetColumnsAndRows(generatedBoxes);
        }

        private static List<StandardBoxModel> SetColumnsAndRows(List<StandardBoxModel> boxes)
        {
            int boxCount = 1;
            for (int c = 1; c <= 12; c++)
            {
                for (int r = 2; r >= 0; r--)
                {
                    boxes[boxCount].ColumnNumber = c;
                    boxes[boxCount].RowNumber = r;
                    boxCount++;
                }
            }
            return boxes;
        }

        private static StandardBoxModel CreateStandardBox(int number)
        {
            StandardBoxModel standardBox;
            if (number % 2 != 0)
            {
                standardBox = new StandardBoxModel() { Number = number, BackgroundColor = Constants.Red, BorderColor = Constants.White, ForegroundColor = Constants.Black };
            }
            else
            {
                standardBox = new StandardBoxModel() { Number = number, BackgroundColor = Constants.Black, BorderColor = Constants.Green, ForegroundColor = Constants.White };
            }
            return standardBox;
        }

        private static StandardBoxModel CreateStandardBoxWithException(int number, int exception)
        {
            StandardBoxModel standardBox;
            if (number % 2 != 0)
            {
                standardBox = new StandardBoxModel() { Number = number, BackgroundColor = Constants.Black, BorderColor = Constants.Green, ForegroundColor = Constants.White };
            }
            else if (number != exception)
            {
                standardBox = new StandardBoxModel() { Number = number, BackgroundColor = Constants.Red, BorderColor = Constants.White, ForegroundColor = Constants.Black };
            }
            else
            {
                standardBox = new StandardBoxModel() { Number = number, BackgroundColor = Constants.Black, BorderColor = Constants.Green, ForegroundColor = Constants.White };
            }
            return standardBox;
        }

        private static List<SpecialBoxModel> CreateSpecialBoxes()
        {
            List<SpecialBoxModel> specialBoxes = new()
            {
                new SpecialBoxModel(){Name="1st 12", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
                new SpecialBoxModel(){Name="1 to 18", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
                new SpecialBoxModel(){Name="Even", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
                new SpecialBoxModel(){Name="2nd 12", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
                new SpecialBoxModel(){Name="NamelessBlack", BackgroundColor=Constants.Black, BorderColor=Constants.White},
                new SpecialBoxModel(){Name="NamelessRed", BackgroundColor=Constants.Red, BorderColor=Constants.White},
                new SpecialBoxModel(){Name="3rd 12", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
                new SpecialBoxModel(){Name="Odd", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
                new SpecialBoxModel(){Name="19 to 36", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
                new SpecialBoxModel(){Name="1st Column", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
                new SpecialBoxModel(){Name="2nd Column", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
                new SpecialBoxModel(){Name="3rd Column", BackgroundColor=Constants.Black, BorderColor=Constants.White,ForegroundColor=Constants.White},
            };
            return specialBoxes;
        }

        private static PopupModel CreatePopup()
        {
            return new PopupModel() { WinningNumber = 999, WinningPositions = new List<string>() { "one", "two", "three", "four" }, IsVisible = false, BackgroundColor = Constants.Green, ForegroundColor = Constants.Blue };
        }
    }
}
