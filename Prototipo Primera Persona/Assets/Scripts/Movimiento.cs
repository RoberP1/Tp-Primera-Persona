using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb = new Rigidbody(); //jugador

    public GameObject FPSCamera; //cabeza

    public float vel = 1; //velocidad movimiento

    public float sensivilidad = 1; //sensivilidad del mouse

    //imputs
    private float horizontalInput;
    private float verticalInput;
    private float x;
    private float y;
    private float xRotacion;

    private bool MouseVisible;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        MouseVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //obtener imput
        horizontalInput = Input.GetAxis("Horizontal") * vel;
        verticalInput = Input.GetAxis("Vertical") * vel;
        x = Input.GetAxis("Mouse X") * sensivilidad;
        y = Input.GetAxis("Mouse Y") * sensivilidad ;
        xRotacion -= y;
        xRotacion = Mathf.Clamp(xRotacion, -90f, 31f);

        //movimiento camara
        FPSCamera.transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);
        rb.transform.Rotate(0, x, 0);

        
        

        //movimiento
        rb.AddRelativeForce(new Vector3(horizontalInput, 0, verticalInput));
        if (Input.GetKeyDown("escape"))
        {
            if (MouseVisible)
            {
                Cursor.lockState = CursorLockMode.None;
            } else Cursor.lockState = CursorLockMode.Locked;

        }

    }
}
