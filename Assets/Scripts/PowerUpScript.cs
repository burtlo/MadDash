using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

  private float floatSpeed = 0.5f;
  private float floatTime = 0f;
  private float rotateSpeed = 1f;

  private GameControlScript control;

	// Use this for initialization
	void Start () {
    control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
	}

	// Update is called once per frame
	void Update () {

    floatTime += Time.deltaTime * floatSpeed;
    float bounceAmount = Mathf.Sin(Mathf.PI * 2 * floatTime) * 0.02f;

    transform.Translate(0f,bounceAmount,0f);
    transform.Rotate(0f,rotateSpeed,0f);
	}

  void OnTriggerEnter (Collider other) {
    Debug.Log("PowerUp Collected");
    control.PowerUpCollected();
    Destroy(this.gameObject);
  }
}
