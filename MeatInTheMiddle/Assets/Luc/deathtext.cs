using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    public TextMeshProUGUI frogDeathText;
    public TextMeshProUGUI toadDeathText;

    void Update()
    {
        if (GameManager.Instance != null)
        {
            frogDeathText.text = "Frog Deaths: " + GameManager.Instance.frogDeaths;
            toadDeathText.text = "Toad Deaths: " + GameManager.Instance.toadDeaths;
        }
    }
}