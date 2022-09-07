using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using CorePlugin.Core;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour,IEventSubscriber, IEventHandler
{
    [SerializeField] private GameObject[] obstales;
    private List<GameObject> _obstacles;
    private GameObject _currentObstacle;
    private int _currentLevel=0;
    private BanksDelegates.AddRate _addRate;

    private void Awake()
    {
        _obstacles = new List<GameObject>(obstales.Length);
        foreach (GameObject t in obstales)
        {
            _obstacles.Add(t);
        }
        if (PlayerPrefs.HasKey("currentLevel")) _currentLevel = PlayerPrefs.GetInt("currentLevel");
       _currentObstacle = Instantiate(_obstacles[_currentLevel], transform);
    }
    private void EndLevel()
    {
        _currentLevel += 1;
        if (_currentLevel >= _obstacles.Count) _currentLevel = 0;
        PlayerPrefs.SetInt("currentLevel",_currentLevel);
        _addRate.Invoke(1);
        SceneManager.LoadScene("Main");
    }
    public Delegate[] GetSubscribers()
    {
        return new Delegate[]
        {
            (PlayerDelegates.EndLevel)EndLevel
        };
    }
    public void InvokeEvents()
    {
        
    }
    public void Subscribe(params Delegate[] subscribers)
    {
        EventExtensions.Subscribe(ref _addRate, subscribers);
    }
    public void Unsubscribe(params Delegate[] unsubscribers)
    {
        EventExtensions.Unsubscribe(ref _addRate,unsubscribers);
    }
}
