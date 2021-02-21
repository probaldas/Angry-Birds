using System.Collections;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] private Sprite deadSprite;
    [SerializeField] private new ParticleSystem particleSystem;
    
    private bool _hasDied;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
        }
    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        if (_hasDied)
            return false;
        
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
            return true;

        if (collision.contacts[0].normal.y < -0.5f)
            return true;

        return false;
    }

    private IEnumerator Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        particleSystem.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
