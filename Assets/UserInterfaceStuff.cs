using System.Collections;
using UnityEngine;
using TMPro;

public class UserInterfaceStuff : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI coinBag;

  

    void Start()
    {
        GameObject player = GameObject.Find("Game Control");              // dohvacanje podataka iz druge skripte
        GameControl gameControl = player.GetComponent<GameControl>();


        gameControl.score = 0;          // resetiranje vrijednosti na pocetku svake runde
        gameControl.coinCurrent = 0;
        gameControl.scoreBonus = 0;


        score.text = string.Format("SCORE: {0}", gameControl.score);
        coins.text = string.Format("COINS: {0}", gameControl.coinCurrent);
        coinBag.text = string.Format("COIN Bag: {0}", gameControl.coinBag);
        highScore.text = string.Format("HIGH SCORE: {0}", gameControl.highscore);


        StartCoroutine(ScoreTime());
    }





    // brojac score-a
    // ---------------
    IEnumerator ScoreTime()
    {
        GameObject player = GameObject.Find("Game Control");
        GameControl gameControl = player.GetComponent<GameControl>();

        while (true)
        {
            yield return new WaitForSeconds(1);  
            gameControl.score += 1;
            
            score.text = string.Format("SCORE: {0}", gameControl.score);

            if (gameControl.score > gameControl.highscore)  
            {
                gameControl.highscore = gameControl.score;
                highScore.text = string.Format("HIGH SCORE: {0}", gameControl.highscore);
            }
        }
    }
}
