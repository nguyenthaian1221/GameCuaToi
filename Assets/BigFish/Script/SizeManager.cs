using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    public static SizeManager instance;


    private void Awake()
    {
        instance ??= this;
    }
}
