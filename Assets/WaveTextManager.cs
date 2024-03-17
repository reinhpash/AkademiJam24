using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveTextManager : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    public void StartWaveText()
    {
        if (EnemySpawner.Instance.currentWave + 1 == 3)
        {
            Time.timeScale = .5f;
            Invoke("SetTimeNormal", 1f);
            waveText.gameObject.SetActive(false);
            waveText.SetText("Boss ortaya çýktý");
            waveText.gameObject.SetActive(true);
        }
        else
        {
            waveText.gameObject.SetActive(false);
            waveText.SetText(EnemySpawner.Instance.currentWave + 1 + ". Aþama");
            waveText.gameObject.SetActive(true);
        }
    }

    private void SetTimeNormal()
    {
        Time.timeScale = 1f;
    }
}
