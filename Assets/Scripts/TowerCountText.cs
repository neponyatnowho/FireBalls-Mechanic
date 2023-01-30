using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerCountText : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private TextMeshPro _countTowerText;

    private void OnEnable()
    {
        _tower.TowerCountChanged += SetCountToText;
    }

    private void OnDisable()
    {
        _tower.TowerCountChanged -= SetCountToText;

    }

    private void SetCountToText(int count)
    {
        _countTowerText.text = count.ToString();
    }
}
