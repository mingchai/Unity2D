using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // like JS, we can simply leave a variable undeclared until we're ready.
        int max;
        int min;
        int guess;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = 1001;
        min = 9;
        guess = 500;

        Debug.Log("Welcome to Number Wizard!");
        // String interpolation can be donw via '$' outside the quotations. Interpolated variables to have curly braces around them.
        Debug.Log($"Think of a number between {min} and {max}");
        Debug.Log($"Tell me if your number is higher or lower than {guess}");
        Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = Correct");
        max = max + 1;
    }

    // Update is called once per frame, so it will then look to identify the below when playing.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            max = guess;
            NextGuess();
        }
        else if(Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("The correct number was guessed!");
            StartGame();
        }
    }

    void NextGuess()
    {
        guess = (max + min)/2;
        Debug.Log($"Is it higher or lower than {guess}?");
    }
}
