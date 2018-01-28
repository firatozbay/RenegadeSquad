using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

public class ControllerManager
{
    public static ControllerManager Instance;

    public enum ControllerIndex { XInput0 = 0, XInput1 = 1, XInput2 = 2, XInput3 = 3 }
    public enum Command { Up = 0, Down = 1, Left = 2, Right = 3, Use = 4, UpLeft = 5, UpRight = 6, DownLeft = 7, DownRight = 8, Pause = 9, Fire = 10, ContFire = 11, Thrust=12, Break=13 }

    //XInput
    GamePadState[] _states;
    GamePadState[] _prevStates;

    private bool _escapePressed;

    public ControllerManager()
    {
        Instance = this;
        _escapePressed = false;
        _states = new GamePadState[4];
        _prevStates = new GamePadState[4];

    }

    public void ResetEscape()
    {
        _escapePressed = false;
    }

    public void GetCommand(Fighter fighter)
    {
        if (!_escapePressed && Input.GetKeyDown(KeyCode.Escape))
        {
            fighter.UseCommand(Command.Pause);
            _escapePressed = true;
        }

        //XINPUTS
        for(int i = 0; i < 4; i++)
        {
            if (fighter.ControllerIndex == (ControllerIndex)i)
            {
                _prevStates[i] = _states[i];
                _states[i] = GamePad.GetState((PlayerIndex)i);
                if (_states[i].IsConnected)
                {
                    if (!_escapePressed && _prevStates[i].Buttons.Start == ButtonState.Released && _states[i].Buttons.Start == ButtonState.Pressed)
                    {
                        fighter.UseCommand(Command.Pause);
                        _escapePressed = true;
                    }
                    /*
                    if (_states[i].ThumbSticks.Left.Y > 0.1f || _states[i].ThumbSticks.Left.X > 0.1f || _states[i].ThumbSticks.Left.X < -0.1 || _states[i].ThumbSticks.Left.Y < -0.1)
                    {
                        fighter.Move(_states[i].ThumbSticks.Left.X, _states[i].ThumbSticks.Left.Y);
                    }*/
                    if (_states[i].ThumbSticks.Left.Y > 0.1f)
                    {
                        if (_states[i].ThumbSticks.Left.X < -0.1f)
                            fighter.UseCommand(Command.UpLeft);
                        else if (_states[i].ThumbSticks.Left.X > 0.1f)
                            fighter.UseCommand(Command.UpRight);
                        else
                            fighter.UseCommand(Command.Up);
                    }
                    else if (_states[i].ThumbSticks.Left.Y < -0.1f)
                    {
                        if (_states[i].ThumbSticks.Left.X < -0.1f)
                            fighter.UseCommand(Command.DownLeft);
                        else if (_states[i].ThumbSticks.Left.X > 0.1f)
                            fighter.UseCommand(Command.DownRight);
                        else
                            fighter.UseCommand(Command.Down);
                    }
                    else if (_states[i].ThumbSticks.Left.X < -0.1f)
                    {
                        fighter.UseCommand(Command.Left);
                    }
                    else if (_states[i].ThumbSticks.Left.X > 0.1f)
                    {
                        fighter.UseCommand(Command.Right);
                    }
                    if (_prevStates[i].Buttons.A == ButtonState.Pressed && _states[i].Buttons.A == ButtonState.Pressed)
                    {
                        Debug.Log("asdf");
                        fighter.UseCommand(Command.Thrust);
                    }
                    if (_prevStates[i].Buttons.B == ButtonState.Pressed && _states[i].Buttons.B == ButtonState.Pressed)
                    {
                        fighter.UseCommand(Command.Break);
                    }
                    if (_states[i].Triggers.Right > 0.9f && _prevStates[i].Triggers.Right <  0.89f)
                    {
                        fighter.UseCommand(Command.Fire);
                    }
                    else if (_states[i].Triggers.Right > 0.9f && _prevStates[i].Triggers.Right > 0.9f)
                    {
                        fighter.UseCommand(Command.ContFire);

                    }
                }

            }
        }
    }
}