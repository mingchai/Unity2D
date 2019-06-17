using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        // We play the audio clip at the Camera's position to ensure the sound is heard clearly by the player as the PlayClipAtPoint method uses a 3D vector. If we set it to the block, we would likely not get the audio quality we are looking for as the block may be far away or too close to the Audio Listener component or we may even hear the sound in the left or right speaker only due to the block's position in space. This is fine for 3D games, but would be especially odd for 2D games like this block breaker project.
        Destroy(gameObject);
    }
}
