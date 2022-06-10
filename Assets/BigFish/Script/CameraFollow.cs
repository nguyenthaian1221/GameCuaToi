
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private float smoothSpeed = 0.9f; //do muot cua camera khi theo doi vat the
    public Vector3 offset;

    Vector2 viewPort;
    public float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    private void Start()
    {
        viewPort = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        
    }

    private void LateUpdate()
    {
        
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPostion;

        //fix camera posiotion when it hit 4 wall

        #region ViewPort tu nghiem ra
        /*
         * viewPort.x = chinh la kich thuoc cua nua man hinh goc nhin,tính tu tam
         * viewPort.y = chinh la nua chieu rong cua view port tinh tu tam
         */
        #endregion
        _minX = PlayerMove.Instance.minXRange + viewPort.x;
        _maxX = -_minX;
        _maxY = PlayerMove.Instance.maxYRange - viewPort.y / 2;
        _minY = -(PlayerMove.Instance.maxYRange - viewPort.y);
        if (transform.position.x < _minX)
        {
            transform.position = new Vector2(_minX, transform.position.y);

        }
        else if (transform.position.x > _maxX)
        {
            transform.position = new Vector2(_maxX, transform.position.y);

        }

        if (transform.position.y < _minY)
        {
            transform.position = new Vector2(transform.position.x, _minY);
        }
        else if (transform.position.y > _maxY)
        {
            transform.position = new Vector2(transform.position.x, _maxY);

        }




    }
}
