using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector2[] spawnPoints;
    //public GameObject[] monsters;
    int randomSpawnPoint;
    //int randomMonster;
    public static bool spawnAllowed;
    

    private void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 0.1f, 0.3f);
    }

    void SpawnAMonster()
    {

        if (spawnAllowed)
        {
            //randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            //randomMonster = Random.Range(0, monsters.Length);
            //Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint], Quaternion.identity);
            GameObject fish = ObjectPool.Instance.GetPooledObject();
            if (fish != null)
            {
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                fish.transform.position = spawnPoints[randomSpawnPoint];
                fish.SetActive(true);
            }
        }
    }




}

