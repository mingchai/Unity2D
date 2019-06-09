using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    // The 'f' after the number denotes that the number is a float and not an integer

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosInUnits = (Input.mousePosition.x/Screen.width) * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        // set a variable of type Vector2 to a new Vector2 object with coordinates passed as arguments
        // we use 'transform.position.y' to use the existing y-coordinate to set the axis on which the paddle travels 
        transform.position = paddlePos;
        // 'transform.position' comes from the transform component of the paddle object that we see in the inspector. 
    }
}
