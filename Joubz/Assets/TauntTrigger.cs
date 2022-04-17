using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TauntTrigger : MonoBehaviour
{
    private PlayerMovement scriptPlayer;
    private void Start()
    {
        scriptPlayer = GetComponent<PlayerMovement>();
    }
    public void Taunt(InputAction.CallbackContext context)
    {
        if (scriptPlayer.isGrounded)
        {
            scriptPlayer.animPerso.Play("Taunt"); 
        }
    }

    public void Dance(InputAction.CallbackContext context)
    {
        if (scriptPlayer.isGrounded)
        {
            scriptPlayer.animPerso.Play("Dance");
        }
    }

    public void Flair(InputAction.CallbackContext context)
    {
        if (scriptPlayer.isGrounded)
        {
            scriptPlayer.animPerso.Play("Flair");
        }
    }

    public void BackFlip(InputAction.CallbackContext context)
    {
        if (scriptPlayer.isGrounded)
        {
            scriptPlayer.animPerso.Play("BackFlip");
        }
    }
}
