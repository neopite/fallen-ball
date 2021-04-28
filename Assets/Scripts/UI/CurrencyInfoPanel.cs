using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class CurrencyInfoPanel : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI _currencyAmount;

        public void Start()
        {
            Wallet.Instance.OnChangeCurrencyCount += ChangeCurrencyAmount;
        }
        
        private void ChangeCurrencyAmount(Currency currency)
        {
            _currencyAmount.text = (Convert.ToInt32(_currencyAmount.text) + currency.Value).ToString();
        }
    }
}