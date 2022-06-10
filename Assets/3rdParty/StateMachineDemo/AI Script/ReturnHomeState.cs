using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHomeState : State
{

    private Vector3 destination;


    // base keyword is used to access member of the base class from within a derived class
    // base gan tuong tu nhu super ben java
    // : base () chinh la goi phuong thuc khoi tao cua lop cha
    //
    public ReturnHomeState(Character character) : base(character) { }

    public override void Tick()
    {
        character.MoveToward(destination);

        if (ReachedHome())
        {
            character.SetState(new WanderState(character));
        }
    }

    public override void OnStateEnter()
    {
        character.GetComponent<Renderer>().material.color = Color.blue;
    }


    private bool ReachedHome()
    {
        return Vector3.Distance(character.transform.position, destination) < 0.5f;
    }


}
