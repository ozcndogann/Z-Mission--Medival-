using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageScript : MonoBehaviour
{
    public int minutes = 5; // Geri say�m ba�lang�� s�resi (dakika)
    public int seconds = 0; // Geri say�m ba�lang�� s�resi (saniye)
    public TMP_Text timerText;  // Geri say�m� g�sterecek Text UI elementi
    public static int StageCounter;
    public float stageShower;

    private float remainingTime;

    void Start()
    {
        StageCounter = 1;
        remainingTime = minutes * 60 + seconds; // Toplam s�reyi saniye olarak hesapla
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
            remainingTime -= Time.deltaTime; // Geri say�m� g�ncelle

            int displayMinutes = Mathf.FloorToInt(remainingTime / 60); // Dakikalar� hesapla
            int displaySeconds = Mathf.FloorToInt(remainingTime % 60); // Saniyeleri hesapla

            timerText.text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds); // Dakika ve saniyeleri formatla
        }
        else if (Zombiee.zombieDieCounter == 10)
        {
            timerText.text = "You passed the STAGE !";
        }
        else
        {
            timerText.text = "00:00"; // S�re bitti�inde g�sterilecek metin
        }
    }
}
