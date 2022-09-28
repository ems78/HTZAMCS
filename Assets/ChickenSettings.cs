using UnityEngine;

public class ChickenSettings : MonoBehaviour
{
    public GameObject deathPanel;

    public float fallSpeed = 5.0f;
    public float spinSpeed = 250.0f;
    Collider chickenCollider;
    public AudioSource SoundDeath;



    void Start()
    {
        chickenCollider = GetComponent<Collider>();
        chickenCollider.isTrigger = true;
    }



    // upravlja padanjem i rotacijom kokosa
    // -------------------------------------
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }



    // prati collision kokosa sa objektima
    // -------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }


        if(other.gameObject.CompareTag("Player"))
        {
            SoundDeath.Play();
            deathPanel.SetActive(true);
            Time.timeScale = 0;          // pauzira scenu levela dok nije vidljiva
        }
    }
}
