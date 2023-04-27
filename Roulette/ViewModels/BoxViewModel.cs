using Roulette.Models;
using System.ComponentModel;

namespace Roulette.ViewModels
{
    public class BoxViewModel : INotifyPropertyChanged
    {
        private BoxModel BoxModel { get; set; }
        public BoxViewModel(BoxModel boxmodel)
        {
            BoxModel = boxmodel;
        }

        public string? ForegroundColor
        {
            get { return BoxModel.ForegroundColor; }
            set
            {
                BoxModel.ForegroundColor = value;
                OnPropertyChanged(nameof(ForegroundColor));
            }
        }

        public string? BorderColor
        {
            get { return BoxModel.BorderColor; }
            set
            {
                BoxModel.BorderColor = value;
                OnPropertyChanged(nameof(BorderColor));
            }
        }

        public string? BackgroundColor
        {
            get { return BoxModel.BackgroundColor; }
            set
            {
                BoxModel.BackgroundColor = value;
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
