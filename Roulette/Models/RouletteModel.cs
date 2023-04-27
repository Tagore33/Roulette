using System;
using System.Collections.Generic;
using Roulette.Aids;

namespace Roulette.Models
{
    public class RouletteModel
    {
        public JsonTcpServer? Server { get; set; }
        public List<int> WinningNumbers { get; set; }
        private PopupModel PopupModel { get; set; }
        private List<SpecialBoxModel> SpecialBoxModels { get; set; }
        private List<StandardBoxModel> StandardBoxModels { get; set; }
        public event EventHandler<int>? OnWinningNumberCame;
        public event EventHandler<int>? On10SecondsPassed;
        public RouletteModel()
        {
            PopupModel = UIElementsFactory.GetPopup();
            SpecialBoxModels = UIElementsFactory.GetSpecialBoxes();
            StandardBoxModels = UIElementsFactory.GetStandardBoxes();
            WinningNumbers = new();
            ToggleServerAsync();
        }

        public PopupModel GetPopupModel()
        {
            return PopupModel;
        }

        public List<SpecialBoxModel> GetSpecialBoxModels()
        {
            return SpecialBoxModels;
        }

        public List<StandardBoxModel> GetStandardBoxModels()
        {
            return StandardBoxModels;
        }

        private async void ToggleServerAsync()
        {
            Server = await JsonTcpServer.CreateAsync(Constants.Port, this);
        }

        public void Server_OnWinningNumberCame(object? sender, int number)
        {
            OnWinningNumberCame?.Invoke(this, number);
        }

        public void Server_On10SecondsPassed(object? sender, int number)
        {
            On10SecondsPassed?.Invoke(this, number);
        }
    }
}
