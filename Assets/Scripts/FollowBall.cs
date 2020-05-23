using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {

    public Transform ball; // Si queremos la posición, lo más facil es usar un transform
    public float speed; // Enemy velocity for follow the ball

    // Update is called once per frame
    void Update() {
        // Checar si el juego ya inicio o no
        if(ball.GetComponent<BallBehavior>().gameStarted) {
            // Lo siguiente definira hacia donde se mueve la barra del enemigo dependiendo de la posición de la pelota
            if(transform.position.y < ball.position.y) {
                transform.position = new Vector3(transform.position.x,transform.position.y + speed, transform.position.z);
            } else if(transform.position.y > ball.position.y) {
                transform.position = new Vector3(transform.position.x,transform.position.y - speed, transform.position.z);
            }
        }
    }
}
