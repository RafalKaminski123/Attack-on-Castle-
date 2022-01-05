using TMPro;
using UnityEngine;

namespace SDA.UI
{
    public class GameView : BaseView
    {
        [SerializeField] private TextMeshProUGUI currencyValue;

        public void UpdateCurrency(int currency)
        {
            currencyValue.text = $"{currency}$";
        }
    }
}


