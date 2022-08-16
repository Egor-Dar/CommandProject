using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;

public class Chunk : MonoBehaviour, IEventHandler
{
    [SerializeField] private Transform posStarted;
    private PlayerDelegates.SetTransform _setTransform;
    private void Start()
    {
        _setTransform.Invoke(posStarted); 
    }
    public void InvokeEvents()
    {
        
    }
    public void Subscribe(params Delegate[] subscribers)
    {
        EventExtensions.Subscribe(ref _setTransform, subscribers);
    }
    public void Unsubscribe(params Delegate[] unsubscribers)
    {
       EventExtensions.Unsubscribe(ref _setTransform, unsubscribers);
    }
}
