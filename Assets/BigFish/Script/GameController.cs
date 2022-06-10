using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//// Noi chua tham chieu toi Player's Fish
//public class GameController : MonoBehaviour
//{
//    public static GameController Instance;
//    public JoystickFish Player;
//    private void Awake()
//    {
//        Instance = this;
//    }
//}



public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public PlayerMove Player;

    //public FishMovement Enemy;


    private void Awake()
    {
        Instance = this;
    }


}







