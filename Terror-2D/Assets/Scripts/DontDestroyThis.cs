using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class DontDestroyThis : MonoBehaviour
{
    private Scene scene;
    private string sceneName;
    private void OnLevelWasLoaded(int level)
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;

        if (sceneName == "DefeatScene")
            Destroy(gameObject);
    }

    void Start()
    {
        // Este método impede que o objeto 
        // atual seja destruido durante o carregamento.
        DontDestroyOnLoad(gameObject);
    }
}
