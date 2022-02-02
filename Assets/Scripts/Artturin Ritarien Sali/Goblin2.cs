using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TIKO4A2021 {
    public class Goblin2 : MonoBehaviour {
        private float goblinSpeed = 3;
        private Rigidbody2D goblinBody;
        private float xPos;
        private float yPos;
        private Vector2 cagePos;
        private bool isCaught = false;
        private Vector2 goblinDirection;

        void Start() {
            goblinBody = GetComponent<Rigidbody2D>();
        }

        void Update() {
            if(isCaught) {
                cagePos = PlungerProperties.position;
                transform.position = new Vector2(cagePos.x - xPos, cagePos.y - yPos);
            }else {
                goblinDirection = new Vector2(-1, 0).normalized;
            }
            xPos = PlungerProperties.position.x - transform.position.x;
            yPos = PlungerProperties.position.y - transform.position.y;
        }

        void FixedUpdate() {
            goblinBody.velocity = new Vector2(goblinDirection.x * goblinSpeed, 0);
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if(collision.tag == "Plunger") {
                isCaught = true;
                PlungerProperties.isCaught = true;
            } if(collision.tag == "Border") {
                isCaught = false;
                PlungerProperties.isCaught = false;
                Destroy(this.gameObject);
            }
        }

    }
}