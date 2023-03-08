using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class Player : Singleton<Player> //, IDamageable
{
    public List<Collider> colliders;
    public Animator animator;

    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = 9.8f;
    public float jumpForce = 100;

    public float runSpeed = 1.5f;

    private bool alive = true;
    private bool jumping = false;

    private float vSpeed = 0f;
    private float verticalAxis;
    private float horizontalAxis;

    public HealthBase healthBase;
    public List<FlashColor> flashColors;

    [SerializeField] private ChangeClothes changeClothes;
    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    protected override void Awake()
    {
        base.Awake();

        OnValidate();
        healthBase.OnDamage += Damage;
        healthBase.OnKill += OnKill;
    }
    public void Damage(float damage, Vector3 dir)
    {
    }

    public void Damage(HealthBase h)
    {
        flashColors.ForEach(i => i.Flash());
        EffectsManager.Instance.ChangeVignette();
    }

    private void OnKill(HealthBase h)
    {
        if(alive)
        {
            alive = false;
            animator.SetTrigger("Death");
            colliders.ForEach(i => i.enabled = false);

            Invoke(nameof(Revive), 3f);
        }
    }

    private void Revive()
    {
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        alive = true;
        Invoke(nameof(TurnOnColliders), 1f);
        Respawn();
    }

    private void TurnOnColliders()
    {

        colliders.ForEach(i => i.enabled = true);
    }
    private void Start()
    {
       
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

        transform.Rotate(0, horizontalAxis * turnSpeed, 0);
        var speedVector = speed * verticalAxis * transform.forward;

        if(characterController.isGrounded)
        {
            if(jumping)
            {
                jumping = false;
                animator.SetTrigger("Land");
            }
            vSpeed = 0;
            if(Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                vSpeed = jumpForce;
                jumping = true;
                animator.SetTrigger("Jump");
            }
        }

        var isWalking = verticalAxis != 0;
        if(isWalking)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speedVector *= runSpeed;
                animator.speed = runSpeed;
            }
            else
            {
                animator.speed = 1f;
            }
        }
        vSpeed -= gravity * Time.deltaTime;

        speedVector.y = vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", isWalking);
    }

    public void Respawn()
    { 
        if(CheckpointManager.Instance.HasCheckpoint())
        {
            transform.position = CheckpointManager.Instance.GetPositionFromLastCheckpoint();
        }
    }

    public void ChangeSpeed(float speed, float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(speed, duration));
    }

    IEnumerator ChangeSpeedCoroutine(float localSpeed, float duration)
    {
        var defaultSpeed = speed;
        speed = localSpeed;
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
    }
    
    public void ChangeTexture(ClothesSetup setup, float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(setup, duration));
    }

    IEnumerator ChangeSpeedCoroutine(ClothesSetup setup, float duration)
    {
        changeClothes.ChangeTexture(setup);
        yield return new WaitForSeconds(duration);
        changeClothes.ResetTexture();
    }
}
