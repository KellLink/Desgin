using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SceneStateController _sceneStateController;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _sceneStateController = SceneStateController.Instance();
        _sceneStateController.SetState(new StartState(_sceneStateController),false);
    }

    private void Update()
    {
        _sceneStateController.StateUpdate();
    }
}