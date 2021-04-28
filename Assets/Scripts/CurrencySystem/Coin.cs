using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class Coin : Currency
    {
        public override CurrencyType CurrencyType => CurrencyType.Common;
    }
}