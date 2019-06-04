## C#
The programming language works a lot like Javascript/TypeScript in that types are specified. Loops, iterators, etc. work in a very similar fashion.

Types don't have to be specified for variables so long as the language knows what type the value will be upon assignment.

## Getting Player Input
* use _Input.GetKeyDown(KeyCode.XXX)_ to register keyboard input
  * refer to the documentation to determine the proper keycode (https://docs.unity3d.com/ScriptReference/KeyCode.html)
* we can cause the game to close if we assign an input that executes the following when pressed _Application.Quit()_
  * Note that this will only work in the production build of the game and not in the editor.

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

## Public Methods and Return Types
 ``` private void StartGame() ```
 _Access Modifier | Return Value | Method Name | Parameters_

 * The access modifiers are __private by default__
  * private methods are available in the class only, not globally; other functions can't call the private method
 * _void_ means it returns nothing
  * if there is a return type (e.g. 'string', 'int', etc.), that means we get data back from the function
 * everything else is like a JS or Ruby method/function (i.e. name of the method and the arguments it takes)

 ## Arrays
 * denote that you are using an array with square brackets __[]__
  * you can specify the type of data in the array with _'string'_, _'int'_, etc.

### Managing Packages
_Window_ -> _Package Manager_ to access various packages like TMP (if it's not already installed for some reason or if you need to reinstall the package.)

## For Loops
* Basically like JS for loops with incrementors,conditions, etc.
  * instead of __'let i = 0;'__ we'd put __'int i = 0;'__; the rest of the loop syntax is the same.
  * the _'.Length'_ property requires a capitalized L - don't forget!

## Building and Deploying Your Game
1. change the aspect ratio to __16:9 or any ratio that's appropriate__ rather than a fixed screen size in pixels. This allows the game to run in an aspect ratio that will fit most any screen.
2. Ensure the right build support is installed (e.g. WebGL, Android, etc.)
3. _File_ -> _Build Settings_ -> _Build and Run_
  * If the _Build and Run_ button is grayed out for your selected platform, you can usually click on the desired platform and then press _Switch Platform_ to have the option open up for you
4. Once the build completes, expect to see a locally hosted version available for preview. If everything looks good, you can now use zip and upload the build file to your desired marketplace, website, etc. to have the game deployed.

## Loading the next scene on button click
* create an empty game object
* give it a script component
* in the script, use namespace SceneManagement; use appropriate methods to get the scene index value
* load the new game object that was created into the component that will have the event handler to handle the transition to the next scene.