using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject cam;
    public GameObject perso;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(perso.transform.position.x, perso.transform.position.y, -10);
    }
}
