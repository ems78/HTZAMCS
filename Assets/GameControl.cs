using UnityEngine;

public class GameControl : MonoBehaviour  // sluzi za spremanje podataka koji se stalno mijenjaju i ispisuju
{
    public static GameControl control;

    public int score;
    public int highscore;
    public int coinBag;
    public int coinCurrent;
    public int scoreBonus;
    public int scoreTotal;



    
    void Awake()
    {
        if(control == null)    // u slucaju koristenja vise scena osigurava da postoji samo jedna instanca
        {
            DontDestroyOnLoad(gameObject);  // i omogucava prenosenje vrijednosti varijabli medu scenama
            control = this;
        }
        else if(control != null)
        {
            Destroy(gameObject);
        }


        if (PlayerPrefs.HasKey("HighScore") == false)  
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        else
        {
            highscore = PlayerPrefs.GetInt("HighScore");
        }


        if (PlayerPrefs.HasKey("CoinBag") == false)
        {
            PlayerPrefs.SetInt("CoinBag", 0);
        }
        else
        {
            coinBag = PlayerPrefs.GetInt("CoinBag");
        }
    }




    // sprema bitne podatke nakon svake runde
    // --------------------------------------
    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("HighScore", highscore);
        PlayerPrefs.SetInt("CoinBag", coinBag);
    }
}
