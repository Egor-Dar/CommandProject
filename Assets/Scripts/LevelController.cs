using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour,IEventSubscriber
{
    [SerializeField] private GameObject[] obstales;
    private List<GameObject> _obstacles;
    private GameObject _currentObstacle;
    private int _currentLevel=0;

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
        SceneManager.LoadScene("Main");
    }
    public Delegate[] GetSubscribers()
    {
        return new Delegate[]
        {
            (PlayerDelegates.EndLevel)EndLevel
        };
    }
}
