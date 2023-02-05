using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private Sprite[] kevinSprites;
    [SerializeField] private Sprite[] abrahamSprites;

    private float movingTimeFlag = 0f;
    private SpriteRenderer playerSpriteRenderer = default;

    private enum State
    {
        FrontRight,
        FrontLeft,
        BackLeft,
        BackRight
    }

    private State spritesState = default;

    private void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
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
                    //kevinSpriteRenderer.sprite = kevinMonoFrente;
                    gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                    gameObject.transform.position = newPosition;
                    movingTimeFlag = Time.time;
                }

                //Left
                if (playerMovementHorizontal < 0)
                {
                    Vector3 newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 0.25f, 0);
                    Debug.Log("Se mueve a la izq uwu");
                    //kevinSpriteRenderer.sprite = kevinMonoDetras;
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
                    Vector3 newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 0.25f, 0);

                    /*
                    if (!CheckIfWalkable(newPosition))
                    {
                        return;
                    }
                    */

                    Debug.Log("Se mueve arriba uwu");
                    //kevinSpriteRenderer.sprite = kevinMonoDetras;
                    gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                    gameObject.transform.position = newPosition;
                    movingTimeFlag = Time.time;
                }

                //Down
                if (playerMovementVertical < 0)
                {
                    Vector3 newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y - 0.25f, 0);
                    Debug.Log("Se mueve abajo uwu");
                    //kevinSpriteRenderer.sprite = kevinMonoFrente;
                    gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                    gameObject.transform.position = newPosition;
                    movingTimeFlag = Time.time;
                }
            }
            
        }


    }

    private bool CheckIfWalkable(Vector3 nextPosition)
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(nextPosition), Vector2.zero);

        if (hit.collider)
        {
            return true;
        }

        return false;
    }

    private void ChangeSpriteOnLeftMove()
    {
        switch (spritesState)
        {
            case State.FrontRight:
                spritesState = State.FrontLeft;
                break;
            case State.FrontLeft:
                spritesState = State.BackLeft;
                break;
            case State.BackLeft:
                spritesState = State.BackRight;
                break;
            case State.BackRight:
                spritesState = State.FrontRight;
                break;
        }
    }

    private void ChangeSpriteOnRightMove()
    {
        switch (spritesState)
        {
            case State.FrontRight:
                spritesState = State.BackRight;
                break;
            case State.BackRight:
                spritesState = State.BackLeft;
                break;
            case State.BackLeft:
                spritesState = State.FrontLeft;
                break;
            case State.FrontLeft:
                spritesState = State.FrontRight;
                break;
        }
    }

}
