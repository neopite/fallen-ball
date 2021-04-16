using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace DefaultNamespace
{
    public class Wallet : MonoBehaviour
    {
        public static Wallet Instance;
        
        private IDictionary<CurrencyType, int> _currencies;
        
          public event Action<Currency> OnChangeCurrencyCount;
        
          public void ChangeCurrencyCount(Currency currency)
          {
              OnChangeCurrencyCount?.Invoke(currency);
          }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }else Destroy(gameObject);
            
            _currencies = new Dictionary<CurrencyType, int>();
            _currencies.Add(CurrencyType.Common , 0);
            _currencies.Add(CurrencyType.Premium , 0);
        }
        /*
         TODO : event system for changing money (событие на которое дожны будуд подписаться все кому нужен счётчик валюты)
         */
        public void AddCurrency(Currency currency)
        {
            _currencies[currency.CurrencyType] += currency.Value;
            ChangeCurrencyCount(currency);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Currency>(out Currency currency))
            {
                AddCurrency(currency);
                Destroy(other.gameObject);
            }
        }
    }
}