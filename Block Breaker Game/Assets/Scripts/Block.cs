using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
  [SerializeField] AudioClip blockCollisionSound;
  [SerializeField] GameObject blockSparklesVFX;
  [SerializeField] int maxHits;
  int timesHit;
  [SerializeField] Sprite[] hitSprites;

  // cached reference
  Level level;
  GameSession gameStatus;

  private void Start()
  {
    CountBlocksToBreak();
    gameStatus = FindObjectOfType<GameSession>();
  }

  private void CountBlocksToBreak()
  {
    level = FindObjectOfType<Level>();
    if (tag == "Breakable")
    {
      level.CountBreakableBlocks();
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (tag == "Breakable")
    {
      HandleHit();
    }

  }

  private void HandleHit()
  {
    timesHit++;
    if (timesHit >= maxHits)
    {
      DestroyBlock();
    }
    else
    {
      ShowNextHitSprite();
    }
  }

  private void ShowNextHitSprite()
  {
    int spriteIndex = timesHit - 1;
    if (hitSprites[spriteIndex] != null)
    {
      GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
    else
    {
      Debug.LogError($"Block sprite is missing from array. Check {gameObject.name}");
    }
  }

  private void DestroyBlock()
  {
    PlaySoundOnBlockDestroy();
    TriggerSparklesVFX();
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
