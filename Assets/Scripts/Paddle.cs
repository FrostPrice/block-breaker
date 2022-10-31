using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration paramaters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f; // the float type uses decimals points, when using float put an f after the number
    
    // Cached Components References
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.mousePosition.x / Screen.width will return the mouse position on the screen, but in porcentage going from 0.0 to 1. And you multiply by the total amount of units in the current axis
        // To acess the Width of the Screen use the Screen.width, it's in pixels
        Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y); // the Vector2 type is a compact way to store x and y coordinates // the new keyword will create a new Object
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
        // The Mathf.Clamp Method will return a value between a min and a max determined
    }

    private float GetXPos()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits; // The Input.mousePosition will show the current cordinates of the mouse, the output is like this: (x,y,z). And .x will only output the x axis
        }
    }
}
