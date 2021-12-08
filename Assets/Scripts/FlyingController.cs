using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is just for flying camera forward to show off endless terrain
 * Used in video documentation for project
 */
public class FlyingController : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(speed, 0,0) * Time.deltaTime);
    }
}
