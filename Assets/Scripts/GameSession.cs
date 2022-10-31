using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Configuration Parameters
    // You can determine the range of an field in the Inpector, to do this use the [Range(min float, max float)]
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // State Variables
    [SerializeField] int currentScore = 0;

    private void Start()
    {
       scoreText.text = currentScore.ToString();
    }

    private void Awake() // See the documentation for more informations
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length; // This checks how many file of this script exists
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject); // You can refer to this script file
        }
        else
        {
            DontDestroyOnLoad(gameObject); // This Method will not destroy a certain Object on Load
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        // currentScore = currentScore + pointsPerBlockDestroyed; or you can use +=
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

// The Singleton Pattern, is basically, when you're loading a next scene, you can tell Unity to not load/create another file, instead you can use the old file, but with the same values of the scene before the one we're currently in. And to do this you need to wite some "Don't destroy on load" code, and tell the file of the next scene to be destroyed, if there is that file.