using TMPro;
using UnityEngine;

public class Horario : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] float targetTime = 960f;  // 16 minutes in seconds
    private float elapsedTime = 470f;

    void Update()
    {
        if (elapsedTime < targetTime)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            // Quando atingir o tempo alvo, você pode decidir o que fazer
            timerText.text = "16:00";  // Tempo limite atingido
        }
    }
}
