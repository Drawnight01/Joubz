using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalierAnimSequence : MonoBehaviour
{
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetTrigger("StairRotationTrigger"); 
    }
}
