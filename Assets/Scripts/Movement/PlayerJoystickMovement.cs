using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickMovement : CharacterControllerMovementBase
{
    private Joystick _joystick;
    protected override void Awake()
    {
        base.Awake();

        _joystick = FindObjectOfType<Joystick>(true);
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Activate();
        }


        if (!Activated)
            return;
        base.Update();
        GetInput();
    }

    public override void Activate()
    {
        base.Activate();

        if (!_joystick)
            _joystick = FindObjectOfType<VariableJoystick>();
    }

    public void GetInput()
    {
        Vector3 movData;

        var joystickMov = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        movData = joystickMov;
        MoveTo(movData);
    }
}
