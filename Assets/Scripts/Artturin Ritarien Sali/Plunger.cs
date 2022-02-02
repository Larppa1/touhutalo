using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TIKO4A2021
{
    public class Plunger : MonoBehaviour{
        private Vector2 plungerDirection;
        public float plungerSpeed;
        private Rigidbody2D plungerBody;
        private int totalActiveTweens;
        [SerializeField]
        private float plunSpeed = 0;
        private bool isMoving = false;

        void Start(){
            plungerBody = GetComponent<Rigidbody2D>();
        }
        void Update(){
            float directionX = Input.GetAxisRaw("Horizontal");
            plungerDirection = new Vector2(directionX, 0).normalized;
            PlungerProperties.position = transform.position;

            //totalActiveTweens = plungerAnim.TotalActiveTweens();
            if(Input.GetKeyDown("down") && !DOTween.IsTweening(transform)) {
                transform.DOMove(new Vector2(transform.position.x, -3), plunSpeed).SetLoops(2, LoopType.Yoyo);
                isMoving = true;
            }else if(transform.position.y > 3.34 && PlungerProperties.isCaught && !DOTween.IsTweening(transform) && isMoving == true) {
                isMoving = false;
                transform.DOMove(new Vector2(transform.position.x, 10), plunSpeed).SetLoops(2, LoopType.Yoyo);
            }
        }
        void FixedUpdate(){
            plungerBody.velocity = new Vector2(plungerDirection.x * plungerSpeed, 0);
        }
    }
}
