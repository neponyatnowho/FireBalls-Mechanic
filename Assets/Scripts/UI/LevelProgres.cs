using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgres : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] Tower _tower;

    private int _maxProgress;

    private void OnEnable()
    {
        _maxProgress = 0;
        _tower.TowerCountChanged += OnLevelProgresChanged;
    }

    private void OnDisable()
    {
        _tower.TowerCountChanged -= OnLevelProgresChanged;
    }

    private void OnLevelProgresChanged(int progres)
    {
        if(_maxProgress == 0)
        {
            _maxProgress = progres;
            _slider.value = 0;
            return;
        }
        else if(progres == 0)
        {
            _slider.value = 1f;
            _maxProgress = 0;
            return;
        }

        _slider.value = ( 1 - ((float)progres / _maxProgress));
    }

}
