using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{

    public event UnityAction ObstacleHided;

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            ObstacleHided?.Invoke();
        }
    }

}
