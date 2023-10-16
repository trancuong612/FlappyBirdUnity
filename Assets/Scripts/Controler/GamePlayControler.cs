using System.Reflection;
using System;
using System.Net.Mime;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayControler : MonoBehaviour
{
   public static  GamePlayControler input;

   [SerializeField]
   private UnityEngine.UI.Button clickButton;
    
   [SerializeField]
   private Text scoretext, endScoreText, bestScoreText;

   [SerializeField]
   private GameObject gameOver, pausePanel, pause;

   void Awake() {
   Time.timeScale = 0;
   Makeinput();
   }
   void Makeinput(){
      if (input == null)
      {
         input = this;
      }
   }
   public void _InstructionButton(){
    Time.timeScale = 1;
    clickButton.gameObject.SetActive(false);
   }
   public void Setscore(int diem){
      scoretext.text = "" + diem;
   }
   public void BirdDide(int diem){
      gameOver.SetActive(true);
      // diem 
      endScoreText.text = "" + diem;
      if (diem > Manager.input.GetBestScore())
      {
         Manager.input.SetBestScore(diem);
      }
      bestScoreText.text = ""+Manager.input.GetBestScore();
      //diem
      pause.SetActive(false);
   }
   public void MenuButton(){
      Application.LoadLevel("MainMenu");
   }
   public void RestartGame(){
      Application.LoadLevel("GamePlay");
   }
   public void Pause(){
      Time.timeScale = 0;
      pausePanel.SetActive(true);
   }
   public void UnPause(){
      Time.timeScale = 1;
      pausePanel.SetActive(false);
   }
}
