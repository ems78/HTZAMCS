using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class FakeLoading : MonoBehaviour
{
    public GameObject loadingPanel;
    public TextMeshProUGUI progressTextValue;
    public Slider loadingSlider;
    float realProgress;
    float fakeProgress;


    public async void LoadScene(int sceneNumber)
    {
        loadingPanel.SetActive(true);

        realProgress = 0.0f;
        fakeProgress = 0.0f;
        loadingSlider.value = 0.0f;

        // loada scenu ali je ne pokrene
        var scene = SceneManager.LoadSceneAsync(sceneNumber);
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);    // pauza izmedu inkrementiranja progress-a
            fakeProgress += Random.Range(0.01f, 0.1f); // velicina inkrementa
            progressTextValue.text = fakeProgress.ToString("0.00%"); // prikaz u postotku
            loadingSlider.value = fakeProgress;
        } while (fakeProgress < 0.9f);


        loadingSlider.value = 1.0f;
        progressTextValue.text = "100.00%";


        do
        {
            realProgress = scene.progress;
        } while (realProgress < 0.9f);

        scene.allowSceneActivation = true;

        Time.timeScale = 1;   // u slucaju izlaska u main menu nakon zavrsetka runde, 
    }                        // pa ponovog ulazenja u rundu, scena se mora 'odpauzirati'

}

