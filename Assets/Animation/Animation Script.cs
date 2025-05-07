using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public string animationToPlay;
    private Animator animator;
     void Start()

    {
        animator = GetComponent<Animator>();

        if (animator && !string.IsNullOrEmpty(animationToPlay))
        {
            animator.Play(animationToPlay);
        }

        else
        {
            Debug.LogWarning("Missing animation state or Animator or: " + gameObject.name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
