using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

  public Texture texture;
  private string gameOverText = "Your Final Score was:";

  void Start () {
    Screen.showCursor = true;
  }

  void OnGUI () {
    GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),
      texture);

    GUI.Box(new Rect(Screen.width / 2 - 120,Screen.height - 210,240,110),
      gameOverText);

    string playerScore = PlayerPrefs.GetInt("score").ToString();

    GUI.Label(new Rect(Screen.width / 2 - 110,Screen.height - 190,220, 100),
      playerScore);

    if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height - 80, 160,60), "Play Again")) {
      Application.LoadLevel("MainMenu");
      PlayerPrefs.DeleteAll();
    }

  }

}
