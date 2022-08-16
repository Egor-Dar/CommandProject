using System;
using Player;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public event Action TriggerEnter;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerAction>(out _))
            TriggerEnter?.Invoke();
    }
}