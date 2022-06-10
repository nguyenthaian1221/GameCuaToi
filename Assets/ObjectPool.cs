using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // lai la 1 keiu singleton pattern

    public static ObjectPool Instance;
    public GameObject[] objToPool;
    
    public List<GameObject> gameObjects;
    public int amountObj;
    private int _randomFishType;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameObject temp;


        for (int i = 0; i < amountObj; i++)
        {
            _randomFishType = Random.Range(0, objToPool.Length);
            temp = Instantiate(objToPool[_randomFishType]);
            temp.SetActive(false);
            gameObjects.Add(temp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountObj; i++)
        {
            if (!gameObjects[i].activeInHierarchy)
            {
                return gameObjects[i];
            }
            
        }
        EnemyController.spawnAllowed = false;
        return null;
    }
}

