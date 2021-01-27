using UnityEngine;

public class RotationFloating : MonoBehaviour
{
    //Rotational Speed
    public float speed = 0f;
   
    //Forward Direction
    public bool forwardX;
    public bool forwardY;
    public bool forwardZ;
   
    //Reverse Direction
    public bool reverseX;
    public bool reverseY;
    public bool reverseZ;

    public bool floatingY;

    public float floatingStrenght = 0.1f;
    public float floatingSpeed = 1f;
    public float firstYPos;

    private void Start()
    {
        firstYPos = transform.position.y;
        
    }

    void Update ()
    {
        ForwardDirection();
        ReverseDirection();
    }

    public void ForwardDirection()
    {
        if(forwardX)
            transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);
        if(forwardY)
            transform.Rotate(0, Time.deltaTime * speed,  0, Space.Self);
        if(forwardZ)
            transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
    }

    public void ReverseDirection()
    {
        if(reverseX)
            transform.Rotate(-Time.deltaTime * speed, 0, 0, Space.Self);
        if(reverseY)
            transform.Rotate(0, -Time.deltaTime * speed,  0, Space.Self);
        if(reverseZ)
            transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);

        if (floatingY)
        {
            Vector3 floatingPos = transform.position;
            transform.position = new Vector3(floatingPos.x,firstYPos+floatingStrenght*Mathf.Sin(floatingSpeed*Time.time),floatingPos.z);        
        }
    }
}
