using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceAnimations : MonoBehaviour
{
    
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void playFaceAnimation(string newanim)
    {
        animator.SetLayerWeight(animator.GetLayerIndex(newanim), 1f);
    }

    public void restoreFaceAnimation(string newanim)
    {
        animator.SetLayerWeight(animator.GetLayerIndex(newanim), 0f);
    }
}
