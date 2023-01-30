using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;
using Color = UnityEngine.Color;

[RequireComponent(typeof(MeshRenderer))]
public class Pipe : MonoBehaviour
{
    [SerializeField] private List<Color> _colors;
    [SerializeField] private ParticleSystem _hitPArticle;

    private MeshRenderer _meshRenderer;
    private Color _color;


    public event UnityAction<Pipe> BulletHit;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _color = SetColor(_colors[Random.Range(0, _colors.Count)]);
    }

    private Color SetColor(Color color)
    {
        _meshRenderer.material.color = color;
        return color;
    }

    public void Brake()
    {
        BulletHit?.Invoke(this);
        _hitPArticle.startColor = _color;
        Instantiate(_hitPArticle, transform.position, Quaternion.Euler(-90f, 0, -50f));
        Destroy(gameObject);

    }
}
