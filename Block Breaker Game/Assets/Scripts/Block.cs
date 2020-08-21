using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blockCollisionSound;
    [SerializeField] GameObject blockSparklesVFX;

    // cached reference
    Level level;
    GameSession gameStatus;

    private void Start(){
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();
    }
    
   private void OnCollisionEnter2D(Collision2D collision)
  {
    TriggerSparklesVFX();
    DestroyBlock();
  }

  private void DestroyBlock()
  {
    PlaySoundOnBlockDestroy();
    Destroy(gameObject);
    level.BlockDestroyed();
  }

  private void PlaySoundOnBlockDestroy()
  {
    FindObjectOfType<GameSession>().AddToScore();
    AudioSource.PlayClipAtPoint(blockCollisionSound, Camera.main.transform.position);
  }

  private void TriggerSparklesVFX()
  {
    GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
    Destroy(sparkles, 1f);
  }
}
