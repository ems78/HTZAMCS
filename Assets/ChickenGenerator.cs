using UnityEngine;

public class ChickenGenerator : MonoBehaviour
{
    public float delay = 0.5f;
    public GameObject chicken;
    public GameObject ghoul;

    
    void Start()
    {
        InvokeRepeating("Spawn", delay, delay * 2f);
    }


    void Spawn()
    {
        Instantiate(chicken, new Vector3(Random.Range(ghoul.transform.position.x - 50, ghoul.transform.position.x + 50), 30, 0), Quaternion.identity);
    }
}
