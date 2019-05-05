using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    // [SerializeField] makes the variable available in the inspector, so textComponent is then available back in Unity under the game object it's attached to
    [SerializeField] State startingState;
    State state;
    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        // textComponent.text = "It was a dark and stormy night... That's how it would have started out, ideally. But this was a more idyllic day.";
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
