using UnityEngine;
using System.Collections;

public class WanderAI : MonoBehaviour
{
    [SerializeField]
    float Speed = 3;

    Vector3 wayPoint;

    [SerializeField]
    int Range = 10;

    void Start()
    {
        wander();
    }

    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * Speed * Time.deltaTime;
        if ((transform.position - wayPoint).magnitude < 3)
        {
            wander();
        }
    }
    
    //Creates a waypoint for the mob to walk to
    void wander()
    {
        wayPoint = new Vector3(Random.Range(transform.position.x - Range, transform.position.x + Range), 1, Random.Range(transform.position.z - Range, transform.position.z + Range));
        wayPoint.y = 1;
        transform.LookAt(wayPoint);
    }
}