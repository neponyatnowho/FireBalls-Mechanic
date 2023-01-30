using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Pipe _pipe;

    private List<Pipe> _pipes;


    public List<Pipe> Build()
    {
        _pipes = new List<Pipe>();

        Transform currentPoint = _buildPoint;

        for (int i = 0; i < _towerSize; i++)
        {
            Pipe newPipe = BuildPipe(currentPoint);
            _pipes.Add(newPipe);
            currentPoint = newPipe.transform;
        }
        return _pipes;
    }
    private Pipe BuildPipe(Transform currentBuildPoint)
    {
        return Instantiate(_pipe, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y / 2f + _pipe.transform.localScale.y / 2f - 0.22f, _buildPoint.position.z);
    }
}
