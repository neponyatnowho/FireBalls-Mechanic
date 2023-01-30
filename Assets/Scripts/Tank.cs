using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweenShoots;
    [SerializeField] private ParticleSystem _shootEffect;

    private float _timeAfterShoot = 0;
    private Animator _animator;

    public event UnityAction TankShooted;
    private void OnEnable()
    {
        _animator= GetComponent<Animator>();
    }

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (_timeAfterShoot > _delayBetweenShoots)
            {
                Shoot();
                _timeAfterShoot = 0;
            }
        }

    }

    private void Shoot()
    {
        TankShooted?.Invoke();
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
        _animator.Play("TankShoot");
        _shootEffect.Play();

    }
}
