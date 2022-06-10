using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    private State currentState;

    private void Start()
    {
        SetState(new ReturnHomeState(this));
    }

    private void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;
        gameObject.name = "Cube - " + state.GetType().Name;

        if (currentState != null)
            currentState.OnStateEnter();
    }

    public void MoveToward(Vector3 destination)
    {
        var direction = GetDirection(destination);
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }

    private Vector3 GetDirection(Vector3 destination)
    {
        return (destination - transform.position).normalized;
    }
}