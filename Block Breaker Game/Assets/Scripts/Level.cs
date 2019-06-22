using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    // cached reference
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
}
