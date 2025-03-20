using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirection : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float GroundDistance = 0.05f;
    
    
    CapsuleCollider2D Touchingcol;
    Animator animator;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    [SerializeField]
    private bool _isGrounded;

    public bool IsGround {
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        }
        }
    // Start is called before the first frame update

    private void Awake()
    {
        Touchingcol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGround = Touchingcol.Cast(Vector2.down, castFilter, groundHits, GroundDistance) > 0;
    }
}
