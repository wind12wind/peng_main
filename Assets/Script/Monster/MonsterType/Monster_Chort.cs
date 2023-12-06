
public class Monster_Chort : Monster
{
    private void Awake()
    {
        base.Awake();

        monsterType = 2;

        Hp = 30;
        speed = 7;
        level = 3;
    }

    void Start()
    {
        isDead = false ;
    }
}
