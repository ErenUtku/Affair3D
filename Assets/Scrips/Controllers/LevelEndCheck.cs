using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class LevelEndCheck : MonoBehaviour
{
    [SerializeField] private GameObject levelEndPanel;
    public Action levelEndAction;

    public static LevelEndCheck instance;

    private void Awake()
    {
        instance = this;

        levelEndPanel.SetActive(false);
    }
    private void Start()
    {
        levelEndAction += EndLevel;
    }

    public void TriggerLevelEnd()
    {
        levelEndAction.Invoke();
    }
    
    private void EndLevel()
    {
        levelEndPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
