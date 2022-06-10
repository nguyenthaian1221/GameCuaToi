using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // xu ly kinh nghiem
    [SerializeField]private int level;
    [SerializeField] private int expwhendie;

    public int getLevel()
    {
        return level;
    }

    public int getExpWhenDie()
    {
        return expwhendie;
    }




}
