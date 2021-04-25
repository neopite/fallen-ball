using System;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
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
        
        [SerializeField] private GameObject _coinIncomeField;


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
        
        public void AddCurrency(Currency currency)
        {
            _currencies[currency.CurrencyType] += currency.Value;
            ShowPlusCoin(currency);
            ChangeCurrencyCount(currency);
        }
        
        public void ShowPlusCoin(Currency currency)
        {
            GameObject incomeGm = Instantiate(_coinIncomeField, transform.position, Quaternion.identity);
            TextMeshPro text = incomeGm.GetComponent<TextMeshPro>();
            text.text = "+" + currency.Value;
            LeanTween.move(text.GetComponent<RectTransform>(),
                new Vector3(transform.position.x, transform.position.y + .5f, 0f), 1f).setEaseInOutQuart().setOnComplete(()=>Destroy(incomeGm));
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