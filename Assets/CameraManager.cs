using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    SampleMessageListener input;    
    string[] axis;
    public float cameraMoveSpeed = 3f;
    public float sensitivity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<SampleMessageListener>();
    }
    // Update is called once per frame
    void Update()
    {
       axis = input.gyroInput.Split('\t');  

        float X = float.Parse(axis[0]) * sensitivity; 
        float Y = float.Parse(axis[1]) * sensitivity;
        float Z = float.Parse(axis[2]) * sensitivity;

        // transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, Quaternion.Euler(X, Z, -Y), Time.deltaTime * cameraMoveSpeed);
        //Interpolate Rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-X, Z, -Y), cameraMoveSpeed * Time.deltaTime);
    }
}
