using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovementBase : MovementBase
{
    private GravityHolder _gravityHolder = new GravityHolder();

    protected Vector3 impact;
    public CharacterController MovementComponent { get; private set; }
    public bool Activated { get; private set; }

    //private Animator _animator;

    [SerializeField] protected TransformInterpolator transformInterpolater;

    protected virtual void Awake()
    {
        //_animator = GetComponentInChildren<Animator>();
        MovementComponent = GetComponent<CharacterController>();

        transformInterpolater.oldVector = Vector3.zero;
        transformInterpolater.oldQuaternion = transform.rotation;
    }



    protected virtual void Update()
    {
        if (!Activated)
            return;

        impact = Vector3.Lerp(impact, Vector3.zero, Time.deltaTime);
    }


    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y;
        impact += dir.normalized * force;
    }

    protected bool rotateOnMoveTo = true;
    protected float onPushMultiplier = 1f;

    void DrawNextPosition()
    {
        Debug.DrawLine(nextLoc, nextLoc + Vector3.up);
    }

    public Vector3 nextLoc;
    public void MoveTo(Vector3 data)
    {
        data.Normalize();

        data *= (speedMultiplier * maxSpeed * Time.deltaTime * onPushMultiplier);


        Vector3 velocity = Vector3.Lerp(transformInterpolater.oldVector,
            data, transformInterpolater.vectorLerpCoefficient);

        if (impact != Vector3.zero && impact.sqrMagnitude < 0.1f)
            impact = Vector3.zero;

        nextLoc = velocity + Vector3.up * (_gravityHolder.gravityCoefficient * Time.deltaTime) +
                  impact * Time.deltaTime;
        MovementComponent.Move(nextLoc);
        DrawNextPosition();
        //            Debug.Log("HEllu");
        //////_animator.SetFloat("Speed", MovementComponent.velocity.sqrMagnitude);
        if (velocity != Vector3.zero && rotateOnMoveTo)
            Rotate(data);

        SetGravity();
    }

    protected void SetGravity()
    {
        if (MovementComponent.isGrounded)
            _gravityHolder.gravityCoefficient =
                Mathf.Lerp(_gravityHolder.gravityCoefficient, 0, Time.deltaTime * 10f);
        else
            _gravityHolder.gravityCoefficient += GravityHolder.Gravity * Time.deltaTime;
    }

    public void SetGravityToZero()
    {
        _gravityHolder.gravityCoefficient = 0f;
    }


    public void Rotate(Vector3 data)
    {
        var position = transform.position;

        var indicatorPos = new Vector3(position.x - data.x, position.y, position.z - data.z);

        Quaternion targetRotation = Quaternion.Lerp(transformInterpolater.oldQuaternion,
            Quaternion.LookRotation(transform.position - indicatorPos),
            transformInterpolater.quaternionLerpCoefficient);

        transformInterpolater.oldQuaternion = transform.rotation;

        transform.rotation = targetRotation;
    }

    public bool IsActive { get; }

    public void Deactivate()
    {
        //  MovementComponent.enabled = false;
        //////_animator.SetFloat("Speed", 0);
        Activated = false;
    }

    [ContextMenu("Start")]
    public virtual void Activate()
    {
        //  MovementComponent.enabled = true;
        Activated = true;
        // EnableMovementComponent();
    }

    // protected virtual void EnableMovementComponent()
    // {
    //     MovementComponent.enabled = true;
    //     impact = Vector3.zero;
    //     _gravityHolder.gravityCoefficient = 0;
    // }
}
