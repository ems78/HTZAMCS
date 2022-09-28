using UnityEngine;
using TMPro;

public class CoinSettings : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public int coinBag;

    public float fallSpeed = 5.0f;
    public float spinSpeed = 250.0f;

    public AudioSource audioSource;

    


    // upravlja padanjem i rotacijom novcica
    // -------------------------------------
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }




    // prati collision novcica sa objektima
    // ------------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        GameObject player = GameObject.Find("Game Control");
        GameControl gameControl = player.GetComponent<GameControl>();



        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();

            gameControl.coinBag += 1;
            gameControl.coinCurrent += 1;
            gameControl.scoreBonus += 5;
            coins.text = string.Format("COINS: {0}", gameControl.coinCurrent);

            Destroy(gameObject);
        }


        if(collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
