using UnityEngine;

namespace DefaultNamespace
{
    public class Currency : MonoBehaviour
    {
        [SerializeField]private int _value;
        public int Value { get { return _value; } private set { _value = value; } }
        
        [SerializeField] private CurrencyType _currencyType;
        public virtual CurrencyType CurrencyType { get { return _currencyType;} private set { _currencyType = value; } }
    }

    public enum CurrencyType
    {
        Common,Premium
    }
}