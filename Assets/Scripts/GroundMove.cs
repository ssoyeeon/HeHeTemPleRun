using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    private bool _Run;

    public Camera cam;

    public int PlayPower = 16;

    void Start()
    {
        _Run = true;
    }
    void Run()
    {
        if (_Run == true)
        {
            Vector3 dir = cam.transform.localRotation * Vector3.back;
            gameObject.transform.Translate(dir * PlayPower * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Run();
    }
}
