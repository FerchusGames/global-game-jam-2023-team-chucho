using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Sprite kevinFrente;
    [SerializeField] private Sprite kevinDetras;

    private float movingTimeFlag = 0f;
    private SpriteRenderer kevinSpriteRenderer = default;

    private void Start()
    {
        kevinSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Debug.DrawRay(transform.position, Vector3.right * 0.5f, Color.red);

        float playerMovementHorizontal = Input.GetAxis("Horizontal");
        float playerMovementVertical = Input.GetAxis("Vertical");

        if (Time.time > movingTimeFlag + 0.4f)
        {

            //Horizontal movement only
            if (playerMovementHorizontal != 0 && playerMovementVertical == 0)
            {
                //Right
                if (playerMovementHorizontal > 0)
                {
                    Vector3 newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y - 0.25f, 0);
                    Debug.Log("Se mueve a la der uwu");
                    kevinSpriteRenderer.sprite = kevinFrente;
                    gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                    gameObject.transform.position = newPosition;
                    movingTimeFlag = Time.time;
                }

                //Left
                if (playerMovementHorizontal < 0)
                {
                    Vector3 newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 0.25f, 0);
                    Debug.Log("Se mueve a la izq uwu");
                    kevinSpriteRenderer.sprite = kevinDetras;
                    gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                    gameObject.transform.position = newPosition;
                    movingTimeFlag = Time.time;
                }
            }

            //Vertical movement only
            if (playerMovementHorizontal == 0 && playerMovementVertical != 0)
            {
                //Up
                if (playerMovementVertical > 0)
                {

                    /*
                    if (!CheckIfWalkable())
                    {
                        return;
                    }
                    */

                    Vector3 newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 0.25f, 0);
                    Debug.Log("Se mueve arriba uwu");
                    kevinSpriteRenderer.sprite = kevinDetras;
                    gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                    gameObject.transform.position = newPosition;
                    movingTimeFlag = Time.time;
                }

                //Down
                if (playerMovementVertical < 0)
                {
                    Vector3 newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y - 0.25f, 0);
                    Debug.Log("Se mueve abajo uwu");
                    kevinSpriteRenderer.sprite = kevinFrente;
                    gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                    gameObject.transform.position = newPosition;
                    movingTimeFlag = Time.time;
                }
            }
            
        }


    }

    private bool CheckIfWalkable()
    {


        if (Physics2D.Raycast(transform.position, Vector3.right, 2f))
        {
            return false;
        }

        return true;
    }
}
