using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // This allows us to be able to use the SceneManagement functionality

public class SceneLoader : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadNextScene()
    {
        // This variable bellow is acessing the SceneManager class and running the GetActiveScene() Method, but only returning the buildIndex value
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); // The LoadScene Method inside the SceneManager class, will load a specified scene
    }

    public void QuitGame()
    {
        Application.Quit(); // This will make you close the game
    }
}