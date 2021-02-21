using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Sprite _deadSprite;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            Die();
        }
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;

        if (collision.contacts[0].normal.y < -0.5f)
            return true;

        return false;
    }

    private void Die()
    {
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        //gameObject.SetActive(false);
    }
}
