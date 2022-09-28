using UnityEngine;

public class CoinFactory : MonoBehaviour
{
    public float delay = 7f;
    public GameObject coin;
    public GameObject ghoul;


    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
    }


    void Spawn()
    {
        Instantiate(coin, new Vector3(Random.Range(ghoul.transform.position.x - 50, ghoul.transform.position.x + 50), 30, 0), Quaternion.identity);
    }
}
