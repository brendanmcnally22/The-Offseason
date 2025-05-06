using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float damageamount = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Movement player = collision.GetComponent<Movement>();
        if (player != null )
        {
            player.health = damageamount;
        }

    }
}
