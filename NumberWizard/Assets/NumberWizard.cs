using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // like JS, we can simply leave a variable undeclared until we're ready.
        int max = 1001;
        int min = 9;
        int average = (max + min)/2;
        Debug.Log("Welcome to Number Wizard!");
        Debug.Log("Think of a number!");
        // String interpolation can be donw via '$' outside the quotations. Interpolated variables to have curly braces around them.
        Debug.Log($"The highest number should be {max}");
        Debug.Log($"The lowest number should be {min}");
        Debug.Log($"Tell me if your number is higher or lower than {average}");
        Debug.Log("Push Up = Higher, Push Down = Lower, Push Enter = Correct");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            Debug.Log("Up Arrow key was pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)){
            Debug.Log("Down Arrow key was pressed.");
        }
        else if(Input.GetKeyDown(KeyCode.Return)){
            Debug.Log("Return key was pressed.");
        }
    }
}
