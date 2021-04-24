using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class Coin : Currency
    {
        [SerializeField] private TextMeshProUGUI _coinIncomeField;
        public override CurrencyType CurrencyType => CurrencyType.Common;

        private void Start()
        {
            Wallet.Instance.OnChangeCurrencyCount += ShowPlusCoin;
        }

        private TMP_Text _text;

        public void ShowPlusCoin(Currency currency)
        {
            TextMeshProUGUI textMeshProUGUI = Instantiate(_coinIncomeField,transform.position, Quaternion.identity);
            textMeshProUGUI.text = "+" + currency.Value;
            LeanTween.move(textMeshProUGUI.GetComponent<RectTransform>(), new Vector3(0,2f,0f), 1f).setDelay(1f);
        }
    }
}