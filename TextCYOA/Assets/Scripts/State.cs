using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "State")]
// creates a new item in the menu called 'State' which we can then modify below.
public class State : ScriptableObject
// structure:
// access modifier | return type (think primitive values) | name of object (function name, object name, etc.)
{
        [TextArea(14,9)] [SerializeField] string storyText;
        // TextArea allows us to expand the text box in the inspector
        [SerializeField] State[] nextStates;

    public string GetStateStory(){
        return storyText;
        // When this method is executed, we are returned what's in the textbox of storyText (look in th editor/inspector)
    }

    public State[] GetNextStates(){
        return nextStates;
    }
}
