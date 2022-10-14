using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    private int _startingSceneIndex;
    
    void Awake()
    {
        int count = FindObjectsOfType<ScenePersist>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        int curentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(curentSceneIndex != _startingSceneIndex)
            Destroy(gameObject);
    }
}
