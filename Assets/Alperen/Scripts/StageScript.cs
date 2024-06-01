using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageScript : MonoBehaviour
{
    public int minutes = 5; // Geri sayým baþlangýç süresi (dakika)
    public int seconds = 0; // Geri sayým baþlangýç süresi (saniye)
    public TMP_Text timerText;  // Geri sayýmý gösterecek Text UI elementi
    public static int StageCounter;
    public float stageShower;

    private float remainingTime;

    void Start()
    {
        StageCounter = 1;
        remainingTime = minutes * 60 + seconds; // Toplam süreyi saniye olarak hesapla
    }

    void Update()
    {
        if (stageShower <= 4)
        {
            timerText.text = "STAGE" +" " + StageCounter;
            stageShower += Time.deltaTime;
        }
        else if (remainingTime > 0 && Zombiee.zombieDieCounter != 10)
        {
            remainingTime -= Time.deltaTime; // Geri sayýmý güncelle

            int displayMinutes = Mathf.FloorToInt(remainingTime / 60); // Dakikalarý hesapla
            int displaySeconds = Mathf.FloorToInt(remainingTime % 60); // Saniyeleri hesapla

            timerText.text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds); // Dakika ve saniyeleri formatla
        }
        else if (Zombiee.zombieDieCounter == 10)
        {
            timerText.text = "You passed the STAGE !";
        }
        else
        {
            timerText.text = "00:00"; // Süre bittiðinde gösterilecek metin
        }
    }
}
