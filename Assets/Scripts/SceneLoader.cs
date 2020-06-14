using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float waitUntilLoad = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("LoadNextScene", waitUntilLoad);
    }

   

    void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = sceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
