using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {

  public Transform[] spawnPoints;
  public GameObject powerUp;

  private float timeLeft = 25f;
  private float timeAddedByPowerUp = 1f;
  private float timeIncrement = 0.05f;
  private float spawnDelay = 1f;
  private int powerUpsCollected = 0;

	// Use this for initialization
	void Start () {
    Screen.showCursor = false;
    SpawnPowerUp();
	}

	// Update is called once per frame
	void Update () {
    timeLeft -= Time.deltaTime;

    if(timeLeft < 0.0f) {
      PlayerPrefs.SetInt("score",powerUpsCollected);
      Application.LoadLevel("GameOver");
    }

	}

  private void SpawnPowerUp () {
    int location = Random.Range(0,spawnPoints.Length);
    float xOffset = Random.Range(-1.5f, 1.5f);
    float zOffset = Random.Range(-1.5f, 1.5f);

    Vector3 spawnOrigin = spawnPoints[location].position;

    Vector3 spawnPosition = new Vector3(spawnOrigin.x + xOffset,
                                        spawnOrigin.y,
                                        spawnOrigin.z + zOffset);


    Instantiate(powerUp,spawnPosition,Quaternion.identity);

    Invoke("SpawnPowerUp",spawnDelay);

  }

  public void PowerUpCollected () {

    Debug.Log("PowerUp Collected");

    timeLeft += timeAddedByPowerUp;
    powerUpsCollected++;

    spawnDelay += timeIncrement;
    timeAddedByPowerUp += (timeIncrement / 2);
  }

  void OnGUI () {

    GUI.Label(new Rect(Screen.width / 2 - 10,Screen.height - 70,90,40),
      "Time Left: " + (int)timeLeft);

    GUI.Label(new Rect(Screen.width / 2 - 10,Screen.height - 50,90,40),
      "PowerUps Collected: " + powerUpsCollected);



  }
}
