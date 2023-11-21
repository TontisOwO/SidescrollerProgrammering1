using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PhysicsController : MonoBehaviour
{
    [Header("Camera")]

    public Camera myCamera;
    public Transform target;
    public SceneLoader sceneLoader;
    public float cameraMovePos = 0.0f;

    [Header("Physics")]

    public Rigidbody2D myRigidbody = null;

    [Header("Movement")]

    public float MovementSpeedPerSecond = 100.0f;

    [Header("Jump")]

    public CharacterState JumpingState = CharacterState.Airborne;

    public float JumpSpeedFactor = 3.0f;
    public float JumpMaxHeight = 80.0f;
    public float JumpHeightDelta = 0.0f;

    [Header("Health")]

    public float HealthMaxPoints = 3.0f;
    public int HealthPoints = 1;


    [Header("Sprites")]
    public List<Sprite> HealthAmountSprite = new List<Sprite>();
    public SpriteRenderer mySpriteRenderer = null;
    public BoxCollider2D myBoxCollider2D = null;
    public BoxCollider2D groundCheckCollider = null;
    public BoxCollider2D headCheckCollider = null;

    private void Start()
    {
        myCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        if(HealthPoints <= 0)
        {
            SceneLoader mySceneLoader = gameObject.GetComponent<SceneLoader>();
            if (mySceneLoader != null)
            {
                mySceneLoader.LoadScene("GameOver");
            }
        }
        Vector3 characterVelocity = myRigidbody.velocity;
        characterVelocity.x = 0.0f;
        characterVelocity.y = 0.0f;

        Vector2 boxCollision = myBoxCollider2D.size;
        boxCollision.y = 32.0f;
        Vector2 GroundCheckCollision = groundCheckCollider.offset;
        GroundCheckCollision.y = 0.0f;
        Vector2 HeadCheckCollision = headCheckCollider.offset;
        HeadCheckCollision.y = 0.0f;

        int healthCopy = HealthPoints - 1;

        Vector3 screenPos = myCamera.WorldToScreenPoint(target.position);

        if (healthCopy < 0)
        {
            healthCopy = 0;
        }
        if (healthCopy >= HealthAmountSprite.Count)
        {
            healthCopy = HealthAmountSprite.Count - 1;
        }
        if (healthCopy == 0)
        {
            boxCollision.y = 16.0f;
            GroundCheckCollision.y = 8.0f;
            HeadCheckCollision.y = -8.0f;

        }

        myRigidbody.gravityScale = 500.0f;

        if (JumpingState == CharacterState.Grounded)
        {
            myRigidbody.gravityScale = 0.0f;
        }
     
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }

        if (JumpingState == CharacterState.Jumping)
        {
            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y += totalJumpMovementThisFrame;
            JumpHeightDelta += totalJumpMovementThisFrame * Time.deltaTime;

            if (JumpHeightDelta >= JumpMaxHeight || !Input.GetKey(KeyCode.W))
            {
                JumpingState = CharacterState.Airborne;
            }
        }

        if (Input.GetKey(KeyCode.S) && JumpingState == CharacterState.Airborne)
        {
            characterVelocity.y -= MovementSpeedPerSecond;
        }

        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
        }

        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }

        cameraMovePos = gameObject.transform.position.x;
        sceneLoader.MoveCamera(cameraMovePos);
        myRigidbody.velocity = characterVelocity;
        mySpriteRenderer.sprite = HealthAmountSprite[healthCopy];
        myBoxCollider2D.size = boxCollision;
        groundCheckCollider.offset = GroundCheckCollision;
        headCheckCollider.offset = HeadCheckCollision;
    }

    public void TakeDamage(int aHealthValue)
    {
        HealthPoints += aHealthValue;
    }
}
