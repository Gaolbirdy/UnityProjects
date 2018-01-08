using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class API19SceneManager : MonoBehaviour 
{
    private void Start()
    {
        print(SceneManager.sceneCount);
        print(SceneManager.sceneCountInBuildSettings);

        print(SceneManager.GetActiveScene().name);
        print(SceneManager.GetSceneAt(0).name);

        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        SceneManager.sceneLoaded += OnSceneLoaded;z
    }

    void OnActiveSceneChanged(Scene a, Scene b)
    {
        print(a.name);
        print(b.name);
    }

    void OnSceneLoaded(Scene a, LoadSceneMode mode)
    {
        print(a.name + " " + mode);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
            //SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(1).name);
        }
    }
}
