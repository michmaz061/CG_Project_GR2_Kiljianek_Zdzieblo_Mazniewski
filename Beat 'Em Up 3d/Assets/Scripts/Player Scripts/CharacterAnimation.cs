using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    public void Walk(bool move)
    {
        anim.SetBool(AnimationTags.MOVEMENT, move);
    }
}
