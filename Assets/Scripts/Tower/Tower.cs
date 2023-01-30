using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;

    private List<Pipe> _pipes;

    public event UnityAction<int> TowerCountChanged;
    public event UnityAction PipDestroyed;

    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _pipes = _towerBuilder.Build();

        foreach (var pipe in _pipes)
        {
            pipe.BulletHit += OnBulletHit;
        }

        TowerCountChanged?.Invoke(_pipes.Count);
    }

    private void OnBulletHit(Pipe hitetPipe)
    {

        hitetPipe.BulletHit -= OnBulletHit;

        _pipes.Remove(hitetPipe);

        foreach (var pipe in _pipes)
        {
            pipe.transform.position = new Vector3(pipe.transform.position.x, pipe.transform.position.y - pipe.transform.localScale.y + 0.22f, pipe.transform.position.z);
        }
        TowerCountChanged?.Invoke(_pipes.Count);
        PipDestroyed?.Invoke();


    }
}
