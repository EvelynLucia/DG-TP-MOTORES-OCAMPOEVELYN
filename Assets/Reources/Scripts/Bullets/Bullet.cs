using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Unity ref
    [SerializeField] byte velocityImpulse;
    #endregion

    public byte GetVelocityImpulse() { return this.velocityImpulse; }

    protected Rigidbody2D rb = null;

    void Awake () => rb = GetComponent<Rigidbody2D>();

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("envirovent"))
        {
            VfxManager.instance.SetParticlesDestroyShip(transform.position);
            Destroy(gameObject);
        }
    }


}
