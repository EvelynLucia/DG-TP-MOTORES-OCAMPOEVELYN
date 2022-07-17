using UnityEngine;
using System.Collections;

public class BulletCharacter: Bullet
{
    #region Unity Methods
    void Update() => Destroy(gameObject, 2.0f);

    void FixedUpdate() => BulletUp();
    #endregion

    void BulletUp() => rb.AddForce(GetVelocityImpulse() * Time.fixedDeltaTime * transform.up, ForceMode2D.Impulse);

}
