using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FishMovement : MonoBehaviour
{
    // di chuyen 
    public float speed;
    public Rigidbody2D rigidbody;
    private bool facingRight = true;
    private float angle;
    public Vector3 localScale;
    private Vector2 randomDirection;
    public float AttackRange;
    private float currentDistance;
    private int _randomOptionMove;
    private Vector2 _direction;

    // Boundaries cho map
    private float minXRangeForBot;
    private float minYRangeForBot;
    private GameObject background;
    public static FishMovement instance;

    private void Awake()
    {
        instance ??= this;
        background = GameObject.Find("Undersea");
    }

    private void Start()
    {
        minXRangeForBot = -background.GetComponent<SpriteRenderer>().bounds.size.x / 2; ;
        minYRangeForBot = -background.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        rigidbody = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;

        InvokeRepeating("AIEmenySelectOptionMove", 0.1f, 8f);

    }

    private void Update()
    {
        currentDistance = GetDistance();
        //CurvMotion();
        Boundaries();
        Move();
        //ChasePlayer();



    }

    #region Tam thoi khong dung
    //private void CurvMotion()
    //{
    //    //angle = Vector2.SignedAngle(m_Input, Vector2.right);
    //    //transform.DORotateQuaternion(Quaternion.Euler(0, 0, -angle), Time.deltaTime);
    //    Quaternion rotation = transform.rotation;
    //    rotation.z = rotation.z + 0.1f; 
    //    transform.rotation = rotation;
    //}

    #endregion





    // Han che pham vi di chuyen cua nhung con ca enemy va doi huong ngay khi gap border
    private void Boundaries()
    {
        if (transform.position.x > -minXRangeForBot)
        {
            transform.position = new Vector3(-minXRangeForBot, transform.position.y, transform.position.z);
            MoveOppositely();
        }
        else if (transform.position.x < minXRangeForBot)
        {
            transform.position = new Vector3(minXRangeForBot, transform.position.y, transform.position.z);
            MoveOppositely();
        }

        if (transform.position.y > -minYRangeForBot)
        {
            transform.position = new Vector3(transform.position.x, -minYRangeForBot, transform.position.z);
            MoveOppositely();
        }
        else if (transform.position.y < minYRangeForBot)
        {
            transform.position = new Vector3(transform.position.x, minYRangeForBot, transform.position.z);
            MoveOppositely();
        }
    }




    public void Move()
    {

        //rigidbody.MovePosition((Vector2)transform.position + (_direction) * Time.deltaTime * speed);

        angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        //rigidbody.DORotate(angle, 0.25f);
        rigidbody.MovePosition((Vector2)transform.position + (_direction * speed * Time.deltaTime));
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        flip();

    }

    private void MoveRandomly()
    {

        //rigidbody.MovePosition((Vector2)transform.position + () * Time.deltaTime * speed);

        _direction = randomDirection.normalized;
    }

    private void MoveOppositely()
    {
        _direction *= -1;
    }
    private void MoveToPlayerPosition()
    {

        //rigidbody.MovePosition((Vector2)transform.position + () * Time.deltaTime * speed);

        _direction = (GameController.Instance.Player.transform.position - transform.position).normalized;

    }

    private void ChasePlayer()
    {

        if (currentDistance < 5)
        {
            //transform.DOMove(GameController.Instance.Player.transform.position, 10f);
            Vector3 direction1 = (GameController.Instance.Player.transform.position - transform.position).normalized;
            angle = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;

            rigidbody.MovePosition(transform.position + (direction1 * speed * Time.deltaTime));
            // rigidbody.DORotate(angle, 0.05f);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            flip();
        }

    }

    void flip()
    {
        if ((angle >= -180 && angle <= -90) || (angle >= 90 && angle <= 180))
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }

        if (((facingRight) && localScale.y > 0) || ((!facingRight) && (localScale.y < 0)))
        {
            localScale.y *= -1;
        }
        transform.localScale = localScale;
    }

    private float GetDistance()
    {
        float distance = Vector2.Distance(transform.position, GameController.Instance.Player.transform.position);
        return distance;
    }


    private void AIEmenySelectOptionMove()
    {
        if (currentDistance > 5)
        {
            _randomOptionMove = Random.Range(0, 7);

            if (_randomOptionMove == 0)
            {
                //MoveUp();
                randomDirection = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                MoveRandomly();
            }
            else if (_randomOptionMove == 1)
            {
                //MoveDown();
                randomDirection = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                MoveRandomly();
            }
            else if (_randomOptionMove == 2)
            {
                // MoveLeft();
                randomDirection = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                MoveRandomly();
            }
            else if (_randomOptionMove == 4)
            {
                //MoveRight();
                randomDirection = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                MoveRandomly();
            }
            else if (_randomOptionMove == 6)
            {
                MoveToPlayerPosition();
            }

            else if (_randomOptionMove == 5)
            {
                randomDirection = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                MoveRandomly();

            }
        }

    }
}


