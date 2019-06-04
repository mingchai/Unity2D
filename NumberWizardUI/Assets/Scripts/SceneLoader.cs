using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // returns the build index value from the SceneManager class' GetActiveScene method
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
