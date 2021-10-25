using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    
    Rigidbody rb = new Rigidbody(); //jugador

    

    public float vel = 1; //velocidad movimiento

    public float sensivilidad = 1; //sensivilidad del mouse

    [SerializeField] private GameObject FPSCamera; //cabeza
    
    //imputs
    private float horizontalInput;
    private float verticalInput;
    private float x;
    private float y;
    private float xRotacion;

    private float disparo = 0;

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

        //imput movimiento personaje
        horizontalInput = Input.GetAxis("Horizontal") * vel * Time.fixedDeltaTime * 15;
        verticalInput = Input.GetAxis("Vertical") * vel * Time.fixedDeltaTime * 15;

        //imputs movimiento camara
        x = Input.GetAxis("Mouse X") * sensivilidad * Time.fixedDeltaTime * 15;
        y = Input.GetAxis("Mouse Y") * sensivilidad * Time.fixedDeltaTime * 15;
        xRotacion -= y;
        xRotacion -= disparo;
        
        
        xRotacion = Mathf.Clamp(xRotacion, -90f, 41f);  //limitador de movimiento de camara

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

    public void Disparo(float fire)
    {

        disparo = fire;
        
    }
}
