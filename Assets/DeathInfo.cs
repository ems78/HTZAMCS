using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DeathInfo : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI coinBag;
    public TextMeshProUGUI bonus;
    public TextMeshProUGUI total;

    public GameObject deathPanel;




    // ispis svih podataka na Death Panelu
    // -----------------------------------
    void Start()
    {
        GameObject player = GameObject.Find("Game Control");
        GameControl gameControl = player.GetComponent<GameControl>();    // dohvacanje podataka iz druge skripte


        
        score.text = string.Format("SCORE: {0}", gameControl.score);
        coins.text = string.Format("COINS: {0}", gameControl.coinCurrent);
        coinBag.text = string.Format("COIN BAG: {0}", gameControl.coinBag);
        bonus.text = string.Format("COIN BONUS: {0}", gameControl.scoreBonus);
        gameControl.scoreTotal = gameControl.score + gameControl.scoreBonus;
        total.text = string.Format("TOTAL: {0}", gameControl.scoreTotal);
        

        if (gameControl.scoreTotal > gameControl.highscore)
        {
            gameControl.highscore = gameControl.scoreTotal;
        }
        highScore.text = string.Format("HIGH SCORE {0}", gameControl.highscore);


        gameControl.SavePlayerPrefs();     // spremanje podataka preko druge skripte
    }





    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }





    // ulazak u novu rundu nakon smrti
    // --------------------------------
    public void PlayAgain()
    {
        deathPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    




    // izlazak u Main Menu nakon smrti
    // -------------------------------
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
