using UnityEngine;

public class BulletTrap : MonoBehaviour
{
    public static BulletTrap BulletTrapInstance { get; private set; }

    [SerializeField] private GameObject[] _bullets;
    [SerializeField] private Transform[] _bulletPositions;
    [SerializeField] private Bullet[] _bulletLevels;

    [SerializeField] private Transform _playerPos;

    private Rigidbody2D _bulletRigid;

    private float[] _attackTimes = { 0.5f, 1f, 1.5f, 2f };
    private float[] _attackDelays = { 0f, 0f, 0f, 0f };

    private int _level;

    private int _maxBulletTrap;

    private void Awake()
    {
        //Singleton
        if (BulletTrapInstance == null)
        {
            BulletTrapInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _level = 1;
        _playerPos = GameObject.FindGameObjectWithTag("Character").GetComponent<Transform>();

        _maxBulletTrap = 4;
    }

    void Update()
    {
        for (int i = 0; i < _level; i++)
        {
            _attackDelays[i] += Time.deltaTime;

            if ((_attackDelays[i] >= _attackTimes[i]) && (_level >= i + 1))
            {
                ShootBullet(i);
                _attackDelays[i] = 0f;
            }
        }
    }

    public void InitBullets()
    {
        for(int i = 1; i <= _maxBulletTrap; i++)
        {
            _bullets[0] = Resources.Load<GameObject>($"Prefabs/Bullets/Level{i}_Bullet");
        }
    }

    public void CurrentLevel()
    {
        // Bullet 
        _level = (MonstersManager.Enemy.Level > 4) ? 4 : MonstersManager.Enemy.Level;
    }

    void ShootBullet(int trapIndex)
    {
        float bulletSpeed = _bulletLevels[trapIndex].speed;
        float bulletAtk = _bulletLevels[trapIndex].atk;

        GameObject bullet = Instantiate(_bullets[trapIndex], _bulletPositions[trapIndex].position, Quaternion.identity);
        _bulletRigid = bullet.GetComponent<Rigidbody2D>();

        Vector2 direction = (Vector2)_playerPos.position - (Vector2)_bulletPositions[trapIndex].position;
        direction.Normalize();

        _bulletRigid.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        _bulletRigid.transform.parent = transform;
    }
}
