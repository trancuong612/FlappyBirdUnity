using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager input;

    private const string Best_Score = "Best Score";

    void Awake() {
        Makeinput();
        GameStarForTheFirstTime();
    }

    // phai co de check xem game do phai la mo len lan dau khong
    void GameStarForTheFirstTime(){
        if(!PlayerPrefs.HasKey("GameStarForTheFirstTime")){
            PlayerPrefs.SetInt(Best_Score, 0);
            PlayerPrefs.SetInt("GameStarForTheFirstTime", 0);
        }
    }

    void Makeinput()
    {
        if (input != null)
        {
            Destroy(gameObject);
        }else
        {
            input = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetBestScore(int diem){
        PlayerPrefs.SetInt(Best_Score, diem);
    }

    public int GetBestScore(){
        return PlayerPrefs.GetInt(Best_Score);
    }
}
