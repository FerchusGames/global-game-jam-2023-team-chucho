using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Sprite[] kevinSprites;
    [SerializeField] private Sprite[] abrahamSprites;

    [SerializeField] private float _timeBetweenEachInput = 0.1f;

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

        if (Time.time > movingTimeFlag + _timeBetweenEachInput)
        {

            //Rotation

            //Right Rotation
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ChangeSpriteOnRightMove();
                movingTimeFlag = Time.time;
                GetCurrentTile().Turn();
            }

            //Left Rotation
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ChangeSpriteOnLeftMove();
                movingTimeFlag = Time.time;
                GetCurrentTile().Turn();
            }


            //Vertical movement only

            //Moves Upfront
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                Vector3 newPosition = default;

                switch (spritesState)
                {
                    case State.FrontRight:
                        newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y - 0.25f, 0);
                        if (!CheckIfWalkable(newPosition))
                        {
                            return;
                        }
                        gameObject.transform.position = newPosition;
                        break;
                    case State.BackLeft:
                        newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 0.25f, 0);
                        if (!CheckIfWalkable(newPosition))
                        {
                            return;
                        }
                        gameObject.transform.position = newPosition;
                        break;
                    case State.BackRight:
                        newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 0.25f, 0);
                        if (!CheckIfWalkable(newPosition))
                        {
                            return;
                        }
                        gameObject.transform.position = newPosition;
                        break;
                    case State.FrontLeft:
                        newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y - 0.25f, 0);
                        if (!CheckIfWalkable(newPosition))
                        {
                            return;
                        }
                        gameObject.transform.position = newPosition;
                        break;
                }

                this.GetComponent<PlayerStateController>().SetHumanState();

                UpdateSprite();
                movingTimeFlag = Time.time;
            }

            //Moves Backwards
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                Vector3 newPosition = default;

                switch (spritesState)
                {
                    case State.BackLeft:
                        newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y - 0.25f, 0);
                        if (!CheckIfWalkable(newPosition))
                        {
                            return;
                        }
                        gameObject.transform.position = newPosition;
                        break;
                    case State.FrontRight:
                        newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y + 0.25f, 0);
                        if (!CheckIfWalkable(newPosition))
                        {
                            return;
                        }
                        gameObject.transform.position = newPosition;
                        break;
                    case State.FrontLeft:
                        newPosition = new Vector3(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 0.25f, 0);
                        if (!CheckIfWalkable(newPosition))
                        {
                            return;
                        }
                        gameObject.transform.position = newPosition;
                        break;
                    case State.BackRight:
                        newPosition = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y - 0.25f, 0);
                        if (!CheckIfWalkable(newPosition))
                        {
                            return;
                        }
                        gameObject.transform.position = newPosition;
                        break;
                }

                this.GetComponent<PlayerStateController>().SetMonkeyState();

                UpdateSprite();
                movingTimeFlag = Time.time;
            }
        }
    }

    private TileLogic GetCurrentTile()
    {
        return Physics2D.OverlapCircle((Vector2)transform.position, 0.025f).GetComponent<TileLogic>();
    }

    private bool CheckIfWalkable(Vector3 nextPosition)
    {

        float radius = 0.025f;

        Collider2D collider = Physics2D.OverlapCircle((Vector2)nextPosition, radius);

        if (collider != null)
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
