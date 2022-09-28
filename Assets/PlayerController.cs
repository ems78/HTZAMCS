using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody RB;
    public int movementSpeed = 7;
    public bool isGround = false;

    private bool isForward = true;
    public Quaternion rotateFrom = Quaternion.Euler(0f, 0f, 0f);
    public Quaternion rotateTo = Quaternion.Euler(0f, 180f, 0f);
    public Vector3 rotateForward = new Vector3(0, 90, 0);
    public Vector3 rotateBackward = new Vector3(0, 270, 0);
    public float rotateSpeed = 0.1f;
    public GameObject player;

    public Animation anim;
    public GameObject deathPanel;



    // kontrola movement-a, rotacije i animacije igraca
    // ------------------------------------------------
    void Update()
    {
        anim = GetComponent<Animation>();


        if (transform.position.y <= -3)
        {
            deathPanel.SetActive(true);
        }



        // livo
        if (Input.GetKey(KeyCode.A))
        {
            if (!isForward)
            {
                transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime), Space.Self);
            }


            if (isForward)
            {
                transform.Translate(new Vector3(0, 0, -movementSpeed * Time.deltaTime), Space.Self);
                player.transform.eulerAngles = rotateBackward;
                isForward = false;
            }


            if (isGround)
            {
                anim.Play("Run");
            }
        }




        // desno
        if (Input.GetKey(KeyCode.D))
        {
            if (!isForward)
            {
                player.transform.eulerAngles = rotateForward;
                isForward = true;
            }


            if (isForward)
            {
                transform.Translate(new Vector3(0, 0, movementSpeed * Time.deltaTime), Space.Self);
            }


            if (isGround)
            {
                anim.Play("Run");
            }
        }




        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            anim.Play("Attack1");
            RB.AddForce(0, 450, 0);
        }





        else
        {
            anim.CrossFade("Idle");
        }
    }



    // provjera dodirivanja poda
    // -------------------------
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = true;
        }
    }



    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGround = false;
        }
    }
}
