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
                //Right Rotation
                if (playerMovementHorizontal > 0)
                {
                    ChangeSpriteOnRightMove();
                    movingTimeFlag = Time.time;
                }

                //Left Rotation
                if (playerMovementHorizontal < 0)
                {
                    ChangeSpriteOnLeftMove();
                    movingTimeFlag = Time.time;
                }
            }

            //Vertical movement only
            if (playerMovementHorizontal == 0 && playerMovementVertical != 0)
            {
                //Moves Upfront
                if (playerMovementVertical > 0)
                {

                    Vector3 newPosition = default;

                    switch (spritesState)
                    {
                        case State.FrontRight:
                            newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y - 0.25f, 0);
                            gameObject.transform.position = newPosition;
                            break;
                        case State.BackLeft:
                            newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 0.25f, 0);
                            gameObject.transform.position = newPosition;
                            break;
                        case State.BackRight:
                            newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 0.25f, 0);
                            gameObject.transform.position = newPosition;
                            break;
                        case State.FrontLeft:
                            newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y - 0.25f, 0);
                            gameObject.transform.position = newPosition;
                            break;
                    }

                    this.GetComponent<PlayerStateController>().SetHumanState();

                    UpdateSprite();
                    movingTimeFlag = Time.time;
                }

                //Moves Backwards
                if (playerMovementVertical < 0)
                {

                    Vector3 newPosition = default;

                    switch (spritesState)
                    {
                        case State.BackLeft:
                            newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y - 0.25f, 0);
                            gameObject.transform.position = newPosition;
                            break;
                        case State.FrontRight:
                            newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 0.25f, 0);
                            gameObject.transform.position = newPosition;
                            break;
                        case State.FrontLeft:
                            newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 0.25f, 0);
                            gameObject.transform.position = newPosition;
                            break;
                        case State.BackRight:
                            newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y - 0.25f, 0);
                            gameObject.transform.position = newPosition;
                            break;
                    }

                    this.GetComponent<PlayerStateController>().SetMonkeyState();

                    UpdateSprite();
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

    private void ChangeSpriteOnRightMove()
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
        UpdateSprite();
    }

    private void ChangeSpriteOnLeftMove()
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
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        switch (spritesState)
        {
            case State.FrontRight:
                if (this.GetComponent<PlayerStateController>().IsHuman)
                {
                    playerSpriteRenderer.sprite = abrahamSprites[0];
                }
                else
                {
                    playerSpriteRenderer.sprite = kevinSprites[0];
                }
                break;
            case State.FrontLeft:
                if (this.GetComponent<PlayerStateController>().IsHuman)
                {
                    playerSpriteRenderer.sprite = abrahamSprites[1];
                }
                else
                {
                    playerSpriteRenderer.sprite = kevinSprites[1];
                }
                break;
            case State.BackLeft:
                if (this.GetComponent<PlayerStateController>().IsHuman)
                {
                    playerSpriteRenderer.sprite = abrahamSprites[2];
                }
                else
                {
                    playerSpriteRenderer.sprite = kevinSprites[2];
                }
                break;
            case State.BackRight:
                if (this.GetComponent<PlayerStateController>().IsHuman)
                {
                    playerSpriteRenderer.sprite = abrahamSprites[3];
                }
                else
                {
                    playerSpriteRenderer.sprite = kevinSprites[3];
                }
                break;
        }
    }
}
