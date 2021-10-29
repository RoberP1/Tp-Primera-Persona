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

    

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        
        
    }
    // Update is called once per frame
    void Update()
    {
        /*
        //obtener imput

        //imput movimiento personaje
        horizontalInput = Input.GetAxis("Horizontal")  ;
        verticalInput = Input.GetAxis("Vertical")  ;


        //movimiento personaje
        rb.AddRelativeForce(new Vector3(horizontalInput, 0, verticalInput).normalized * vel * Time.deltaTime * 500f);


        //imputs movimiento camara
        x = Input.GetAxis("Mouse X") * sensivilidad;
        y = Input.GetAxis("Mouse Y") * sensivilidad;
        xRotacion -= y;
        xRotacion -= disparo;
       



        xRotacion = Mathf.Clamp(xRotacion, -90f, 41f);  //limitador de movimiento de camara

        
        //movimiento camara
        FPSCamera.transform.localRotation = Quaternion.Euler(xRotacion , 0, 0);
        rb.transform.Rotate(0, x * Time.deltaTime * 250, 0);

        
        */

        

    }
    void FixedUpdate()
    {

        //obtener imput

        //imput movimiento personaje
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        //movimiento personaje
        rb.AddRelativeForce(new Vector3(horizontalInput, 0, verticalInput).normalized * vel );


        //imputs movimiento camara
        x = Input.GetAxis("Mouse X") * sensivilidad;
        y = Input.GetAxis("Mouse Y") * sensivilidad;
        xRotacion -= y;
        xRotacion -= disparo;




        xRotacion = Mathf.Clamp(xRotacion, -90f, 41f);  //limitador de movimiento de camara


        //movimiento camara
        FPSCamera.transform.localRotation = Quaternion.Euler(xRotacion, 0, 0);
        rb.transform.Rotate(0, x, 0);






    }

    public void Disparo(float fire)
    {

        disparo = fire;
        
    }
}
