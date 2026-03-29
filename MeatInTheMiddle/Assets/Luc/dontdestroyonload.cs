using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int frogDeaths = 0;
    public int toadDeaths = 0;

    void Awake()
    {
        // Persist between scenes and ensure only one exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FrogDied()
    {
        frogDeaths++;
        Debug.Log("Frog deaths: ghhfghfghfgh " + frogDeaths);

        if (frogDeaths >= 2)
        {
            SceneManager.LoadScene(10);
            

        }else {
            SceneManager.LoadScene(1);
            
        }
    }

    public void ToadDied()
    {
        toadDeaths++;
        Debug.Log("Toad deaths: jhghjghjghjghj" + toadDeaths);

        if (toadDeaths >= 2)
        {
 
            SceneManager.LoadScene(11);
        }else {
            SceneManager.LoadScene(1);
            
        }
    }
}