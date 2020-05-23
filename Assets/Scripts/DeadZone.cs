using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour {

    public Text scorePlayerText;
    public Text scoreEnemyText;

    int scorePlayerQuantity;
    int scoreEnemyQuantity;

    public SceneChanger sceneChanger;

    public AudioSource pointAudio;

    private void OnTriggerEnter2D(Collider2D collisionBall) {
        pointAudio.Play();
        
        if(gameObject.tag == "Left") { // cuando una colisión entró al gameObject izquierdo
            scoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText,scoreEnemyQuantity);
        } else if(gameObject.CompareTag("Right")) {
            scorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText,scorePlayerQuantity);
        }

        collisionBall.GetComponent<BallBehavior>().gameStarted = false;
    
        CheckScore();
    }

    void CheckScore(){
        if(scorePlayerQuantity >= 3) {
            sceneChanger.ChangeSceneTo("WinScene");
        } else if(scoreEnemyQuantity >= 3) {
            sceneChanger.ChangeSceneTo("LoseScene");
        }
    }

    void UpdateScoreLabel(Text label, int score) {
        label.text = score.ToString();
    }
}
