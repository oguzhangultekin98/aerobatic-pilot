using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SimplePathFollow : MonoBehaviour
{
    public PathCreator Path;
    public float speed;
    private float distanceTravelled;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = Path.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = Path.path.GetRotationAtDistance(distanceTravelled);
    }
}
