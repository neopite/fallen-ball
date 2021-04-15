using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace DefaultNamespace
{
    public class Wallet
    {
        private IDictionary<CurrencyType, int> _currencies;

        private void Awake()
        {
            _currencies = new Dictionary<CurrencyType, int>();
            _currencies.Add(CurrencyType.Common , 0);
            _currencies.Add(CurrencyType.Premium , 0);
        }
        /*
         TODO : event system for changing money (событие на которое дожны будуд подписаться все кому нужен счётчик валюты)
         */
        public void AddCurrency(Currency currency)
        {
            _currencies[currency.GetComponent<Currency>().CurrencyType] += currency.Value;
        }
    }
}