using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Assert = UnityEngine.Assertions.Assert;

public class MouseController : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    float xRotation = 0f, yRotation = 0f;

    public float topClamp = -90f, bottomClamp = 90f;


    [SerializeField]
    private GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       /* Assert.IsNotNull(Camera);
        Assert.IsTrue(Camera.transform.parent.Equals(this));*/
    }

    // Update is called once per frame
    void Update()
    {


        float xNew = xRotation;
        float yNew = yRotation;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity * Time.deltaTime);


        xNew -= mouseY;
        xNew = Mathf.Clamp(xNew, topClamp, bottomClamp);


        yNew += mouseX;
        
        
        transform.localRotation = Quaternion.Euler(0f, yNew, 0f);
        Camera.transform.localRotation = Quaternion.Euler(xNew, 0f, 0f);

        xRotation = xNew;
        yRotation = yNew;
            
            
    }
}
