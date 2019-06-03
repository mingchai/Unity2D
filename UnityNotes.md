## C#
The programming language works a lot like Javascript/TypeScript in that types are specified. Loops, iterators, etc. work in a very similar fashion.

Types don't have to be specified for variables so long as the language knows what type the value will be upon assignment.

## Getting Player Input
* use _Input.GetKeyDown(KeyCode.XXX)_ to register keyboard input
  * refer to the documentation to determine the proper keycode (https://docs.unity3d.com/ScriptReference/KeyCode.html)

## Asset Hierarchy
The list is read from the top-down. Those higher on the list are rendered first with the items that follow being rendered on top. Because of this, you would want to set your background, then put assets, like buttons, below/underneath.

##### Example
For text adventures, you would want to start with an _image component_ (from the UI drop-down), followed by a _text component_. You can then mix and match the colors for the best effect that follows your theme.

#### Text Mesh Pro
To add additional styling to your text and titles, you can utilize __TextMeshPro__ (TMP) which can add things like glow effects to what you've typed out.

Additionally, you can then upload new fonts you've downloaded by going to _Window_ -> _TextMeshPro_ -> _Font Asset Creator_

* __CMD + D__ used to duplicate components

## Updating Components Programatically
* _Game Objects_ have Components
  * _Components_ have properties
    * _Properties_ are either values or references

* Create a game object, then add a script component. This generates a C# file that we can then alter

In order for us to alter a component in Unity, we need to speceify the _namespace_ in the script by using __"using UnityEngine.UI"__, for example. This allows us to then specify the type of component our variable would use (e.g. specifying "Text" would mean we're looking to use Text component from the UI menu in Unity. The text property of the variable that follows is the text field that we can alter in Unity. Know the difference!)

#### Example
When the game starts up, it will update the text property of the Text Component to read what has been input below
```
using UnityEngine.UI;
public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = "It was a dark and stormy night... That's how it would have started out, ideally. But this was a more idyllic day.";
    }
```

* use __[SerializeField]__ to make your variable available in the Unity Inspector. This allows us to assign the variable in a more visual manner in Unity (i.e. drag and drop or using the selector to choose an object).
  * By putting [TextArea(X,Y)] (where X & Y are integers), we can expand the text area in the inspector to accomodate more text

## Game States
_State_ refers to an action, process, or behaviour and a _State Machine_ assumes only 1 state at a time (much like a single page app) which will have conditions that determine when to transition to the next state (i.e. button presses, clicks, counters, etc.). Note that it's possible to have hundreds of states and each state can have many lines of story (if you were doing a choose-your-own-adventure type game)

We use __scriptable objects__ to allow for scaling of the game (because of the potential for hundreds of states). The alternative/naive solution would be to have a bunch of code that gets key inputs and updates the text, but this would be a very manual process with dense code that has a high potential for errors (the equivalent of creating a web page by manually putting in all the HTML and content yourself)

#### What are Scriptable Objects?
* a class that lets us store data in standalone classes
* helps keep our code clean and consistent by allowing our script to sort through the object to determine what will be used
* lightweight and convenient objects in Unity
* note that Scriptable Objects don't need to be attached to a game object

When coding Scriptable Objects, ensure that the class inherits from ScriptableObject:

```
public class State : ScriptableObject{
  <!-- Game Code Here -->
}
```

* [CreateAssetMenu(menuName = "State)] does what you might think - it creates a menu item called state that is available when you right-click in the _Assets_ folder in Unity.