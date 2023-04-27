using Roulette.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace Roulette.ViewModels
{
    public class PopupViewModel : INotifyPropertyChanged
    {
        public PopupModel PopupModel { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public PopupViewModel(PopupModel popupModel)
        {
            PopupModel = popupModel;
        }

        public int WinningNumber
        {
            get { return PopupModel.WinningNumber; }
            set
            {
                PopupModel.WinningNumber = value;
                OnPropertyChanged(nameof(WinningNumber));
            }
        }

        public List<string> WinningPositions
        {
            get { return PopupModel.WinningPositions; }
            set
            {
                PopupModel.WinningPositions = value;
                OnPropertyChanged(nameof(WinningPositions));
            }
        }

        public string? BackgroundColor
        {
            get { return PopupModel.BackgroundColor; }
            set
            {
                PopupModel.BackgroundColor = value;
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }

        public string? ForegroundColor
        {
            get { return PopupModel.ForegroundColor; }
            set
            {
                PopupModel.ForegroundColor = value;
                OnPropertyChanged(nameof(ForegroundColor));
            }
        }

        public bool IsVisible
        {
            get { return PopupModel.IsVisible; }
            set
            {
                PopupModel.IsVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
