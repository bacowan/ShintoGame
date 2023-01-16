using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float WalkSpeed = 1;

    public Sprite UpSprite;
    public Sprite UpRightSprite;
    public Sprite RightSprite;
    public Sprite DownRightSprite;
    public Sprite DownSprite;
    public Sprite DownLeftSprite;
    public Sprite LeftSprite;
    public Sprite UpLeftSprite;

    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = new Sprite[] { RightSprite, UpRightSprite, UpSprite, UpLeftSprite, LeftSprite, DownLeftSprite, DownSprite, DownRightSprite };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputValue value)
    {
        var vel = value.Get<Vector2>() * WalkSpeed;
        rigidbody.velocity = vel;
        if (vel.magnitude > 0)
        {
            var angleFromLeft = Vector2.SignedAngle(Vector2.left, vel);
            var spriteIndex = Mathf.FloorToInt(((angleFromLeft + 180) % 360) / 45);
            if (spriteIndex < 8 && spriteIndex >= 0)
            {
                spriteRenderer.sprite = sprites[spriteIndex];
            }
        }
    }
}
