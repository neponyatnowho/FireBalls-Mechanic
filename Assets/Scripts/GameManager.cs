using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Obstacle> _obstacle;
    [SerializeField] private int _maxLife = 3;

    private int _life;

    public event UnityAction<int> LifeChanged;
    private void Start()
    {
        _life = _maxLife;
    }
    private void OnEnable()
    {
        foreach (var obstacle in _obstacle)
        {
            obstacle.ObstacleHided += MisHit;

        }
    }

    private void OnDisable()
    {
        foreach (var obstacle in _obstacle)
        {
            obstacle.ObstacleHided -= MisHit;

        }
    }

    public void MisHit()
    {
        if(_life > 1)
            LifeChanged?.Invoke(--_life);
        else
            SceneManager.LoadScene(0);
    }
}
