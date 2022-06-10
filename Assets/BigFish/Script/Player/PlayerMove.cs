using UnityEngine;
using DG.Tweening;
public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;

    public VariableJoystick variableJoystick;

    // di chuyen
    public float speed;
    public Rigidbody2D rigidbody;
    public Vector3 localScale;
    private bool facingRight = true;
    private float angle;

    public Transform transform;

    // Boundaries cho map
    public float minXRange;
    public float minYRange;
    public float maxYRange;

    private Vector2 offsetX = Vector2.zero;
    private Vector2 offsetY = Vector2.zero;

    public GameObject background;

    private void Awake()
    {
        Instance ??= this;
    }

    private void Start()
    {
        var playerRenderer = GetComponent<SpriteRenderer>();

        offsetX = new Vector2(
            playerRenderer.bounds.size.x / 2,
            0
            );
        offsetY = new Vector2(
            0,
         playerRenderer.bounds.size.y / 2
         );

        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        localScale = transform.localScale;

        minXRange = -background.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        minYRange = -background.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        maxYRange = -minYRange;
    }

    private void Update()
    {
        Move();

        //RotateItself();

        flip();

        Boundaries();



    }
    // T?o thêm 1 bi?n ?? l?u l?i h??ng g?n nh?t khác zero c?a cá. R?i set cho cá ?i theo h??ng m?c ??nh n?u th? tay ra kh?i joystick
    Vector3 last_direction_Input = Vector3.zero;
    private void Move()
    {

        Vector3 m_Input = new Vector3(variableJoystick.Horizontal, variableJoystick.Vertical, 0);
        //if (m_Input != Vector3.zero) last_direction_Input = m_Input;

        //rigidbody.MovePosition(transform.position + (last_direction_Input.normalized * speed * Time.deltaTime));
        Vector3 vector3 = m_Input.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + vector3);
        Debug.Log(vector3);


    }

    private void RotateItself()
    {
        Vector3 m_Input = new Vector3(variableJoystick.Horizontal, variableJoystick.Vertical, 0);
        angle = Vector2.SignedAngle(m_Input, Vector2.right);
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, -angle), Time.deltaTime);
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

    private void Boundaries()
    {
        if (transform.position.x > -minXRange - offsetX.x)
        {
            transform.position = new Vector2(-minXRange, transform.position.y) - offsetX;
        }
        else if (transform.position.x < minXRange + offsetX.x)
        {
            transform.position = new Vector2(minXRange, transform.position.y) + offsetX;
        }

        if (transform.position.y > maxYRange - offsetY.y)
        {
            transform.position = new Vector2(transform.position.x, maxYRange) - offsetY;
        }
        else if (transform.position.y < minYRange + offsetY.y)
        {
            transform.position = new Vector2(transform.position.x, minYRange) + offsetY;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Destroy(collision.gameObject);

    //    }
    //}


}

