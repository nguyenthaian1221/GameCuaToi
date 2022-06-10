using Unity.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
    public int level = 1;
    public int currentEXP = 0;
    private int[] requiredEXPForEachLevel = { 100, 700, 3000, 9999 };

    int i = 0;
    public int amount;
    public void AddEXP()
    {
        if (level == 4)
        {
            amount = 0;
        }
        else
            currentEXP += amount;
    }

    public void LevelUp()
    {
        if (currentEXP >= requiredEXPForEachLevel[i])
        {
            currentEXP = 0;
            level++;
            i++;
            
        }
        if (level == 4 || i == 4)
        {
            amount = 0;
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<Enemy>().getLevel() <= this.level)
        {
            amount = collision.gameObject.GetComponent<Enemy>().getExpWhenDie();
            AddEXP();
            LevelUp();
            collision.gameObject.SetActive(false);

        }
    }

    private void Update()
    {
        //LevelUp();
    }
}
