using UnityEngine;

class Character : MonoBehaviour
{
    #region Unity Ref
    [Header("Ref platey and values")]
    [SerializeField] PlayerControls playerControls = null;
    [SerializeField] byte speedCharacter;

    [Space(2.0f)]
    [Header("Bullet reference")]
    [SerializeField] Transform bulletspawnPos = null;
    [SerializeField] GameObject bulletPrefab;
    [Space(2.0f)]

    #endregion

    #region Vars
    Rigidbody2D rb;
    float movHorizontal;
    #endregion

    #region Unity Methods

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Update() => ReadAxisValuesToMove();

    private void FixedUpdate() => Move(movHorizontal);

    private void LateUpdate() => ReadFireAxisValues();
    #endregion

    #region Public Methods


    public void ReadFireAxisValues()
    {
        if (Input.GetButtonDown(playerControls.fire) && movHorizontal == 0) OnPlayerFire();
        else
            return;
    }
    #endregion

    #region Private Methods

    private void ReadAxisValuesToMove() => movHorizontal = (sbyte)Input.GetAxis(playerControls.movHorizontal);

    private void Move(float axisValue) => rb.velocity = axisValue * speedCharacter * Time.fixedDeltaTime * transform.right;

    private void OnPlayerFire()
    {
        GameObject bulletShoot = Instantiate(bulletPrefab);
        bulletShoot.transform.position = bulletspawnPos.position;
    }

    #endregion
}
