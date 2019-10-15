using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameEnded = false;
    public GameObject gameOverUI;

    private void Start()
    {
        gameEnded = false;
    }

    // Update is called once per frame
    void Update() {
        if (PlayerStats.instance.getLives() <= 0)
        {
            if (gameEnded)
            {
                return;
            }
            EndGame();
        }
    }
    void EndGame()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("Turret");

        foreach (GameObject obj in array) {
            Turrent objTemp = obj.GetComponent<Turrent>();
            objTemp.explode();

        }
       
        gameEnded = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over");
    }
}
