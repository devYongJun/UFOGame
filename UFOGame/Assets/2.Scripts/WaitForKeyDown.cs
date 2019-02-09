using UnityEngine;

public class WaitForKeyDown : CustomYieldInstruction
{
    private KeyCode _keyCode;
    public WaitForKeyDown(KeyCode keyCode)
    {
        _keyCode = keyCode;
    }

    public override bool keepWaiting
    {
        get { return !Input.GetKeyDown(_keyCode); }
    }
}
