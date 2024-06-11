using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageScript : MonoBehaviour
{
    public int minutes = 5; // Geri sayým baþlangýç süresi (dakika)
    public int seconds = 0; // Geri sayým baþlangýç süresi (saniye)
    public TMP_Text timerText,missionText;  // Geri sayýmý gösterecek Text UI elementi
    public static int StageCounter;
    public float stageShower,passedShower;
    private int zombieLocalCounter;
    

    private float remainingTime, remainingTimeStage2, remainingTimeStageLast;

    void Start()
    {
        StageCounter = 1;
        remainingTime = minutes * 60 + seconds; // Toplam süreyi saniye olarak hesapla
        remainingTimeStage2 = minutes * 60 + seconds;
        remainingTimeStageLast = minutes * 60 + seconds;
    }

    void Update()
    {
        if(Zombiee.zombieDieCounter < 5)
        {
            zombieLocalCounter = Zombiee.zombieDieCounter;
        }
        else if (Zombiee.zombieDieCounter <= 15)
        {
            zombieLocalCounter = Zombiee.zombieDieCounter - 5;
        }
        else if(Zombiee.zombieDieCounter <= 30)
        {
            zombieLocalCounter = Zombiee.zombieDieCounter - 15;
        }
        missionText.text = "Kill"+" " +zombieLocalCounter+"/"+StageCounter*5+ " zombies and survive!";
        if (stageShower <= 3)
        {
            timerText.text = "STAGE" +" " + StageCounter;
            stageShower += Time.deltaTime;
        }
        else if (remainingTime > 0 && Zombiee.zombieDieCounter < 5)
        {
            remainingTime -= Time.deltaTime; // Geri sayýmý güncelle

            int displayMinutes = Mathf.FloorToInt(remainingTime / 60); // Dakikalarý hesapla
            int displaySeconds = Mathf.FloorToInt(remainingTime % 60); // Saniyeleri hesapla

            timerText.text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds); // Dakika ve saniyeleri formatla
        }
        else if (Zombiee.zombieDieCounter == 5 && StageCounter == 1)
        {
            timerText.text = "You passed the STAGE !";
            passedShower += Time.deltaTime;
            if (passedShower > 2)
            {
                stageShower = 0;
                StageCounter++;
            }
            
        }
        else if (remainingTimeStage2 > 0 && Zombiee.zombieDieCounter < 10)
        {
            remainingTimeStage2 -= Time.deltaTime; // Geri sayýmý güncelle

            int displayMinutes = Mathf.FloorToInt(remainingTimeStage2 / 60); // Dakikalarý hesapla
            int displaySeconds = Mathf.FloorToInt(remainingTimeStage2 % 60); // Saniyeleri hesapla

            timerText.text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds); // Dakika ve saniyeleri formatla
        }
        else if (Zombiee.zombieDieCounter == 15 && StageCounter == 2)
        {
            timerText.text = "You passed the STAGE !";
            passedShower += Time.deltaTime;
            if (passedShower > 2)
            { 
                stageShower = 0;
                StageCounter++;
                passedShower = 0;
            }
            
        }
        else if (remainingTimeStageLast > 0 && Zombiee.zombieDieCounter < 30)
        {
            remainingTimeStageLast -= Time.deltaTime; // Geri sayýmý güncelle

            int displayMinutes = Mathf.FloorToInt(remainingTimeStage2 / 60); // Dakikalarý hesapla
            int displaySeconds = Mathf.FloorToInt(remainingTimeStage2 % 60); // Saniyeleri hesapla

            timerText.text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds); // Dakika ve saniyeleri formatla
        }
        else
        {
            timerText.text = "00:00 loli"; // Süre bittiðinde gösterilecek metin
        }
    }
}
