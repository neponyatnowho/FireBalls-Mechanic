using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _fillingTime;
    [SerializeField] private GameManager _gameMenager;

    private void OnEnable()
    {
        _gameMenager.LifeChanged += SetLifeCount;
    }

    private void OnDisable()
    {
        _gameMenager.LifeChanged -= SetLifeCount;

    }

    private void SetLifeCount(int count)
    {
        _slider.DOValue(count, _fillingTime);
    }
}
