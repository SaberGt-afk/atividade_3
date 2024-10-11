using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWp : MonoBehaviour
{
    public GameObject[] waypoint;
    int currentWp = 0;
    public float speed = 10.0f;
    public float rotSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoint[currentWp].transform.position) < 10)
            currentWp++;

        if (currentWp >= waypoint.Length)
            currentWp = 0;

        Quaternion lookatWP = Quaternion.LookRotation(waypoint[currentWp].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
