using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public class LevelController : MonoBehaviour
{
    private Enemy[] _enemies;
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in _enemies)
            if (enemy != null)
                return;
        SceneManager.LoadScene("Level2");
    }
}
