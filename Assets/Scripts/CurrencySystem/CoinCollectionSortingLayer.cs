using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class CoinCollectionSortingLayer : MonoBehaviour
{
    [SerializeField] private LayerMask _mySortingLayer;

    private void Awake()
    {
        GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
    }
}
