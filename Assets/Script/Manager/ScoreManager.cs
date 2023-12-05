using UnityEngine;

public class ScoreManager
{
    public int RemainKill { get; private set; }
    public int Kill { get; private set; }

    public ScoreManager(int remainKill, int kill)
    {
        RemainKill = remainKill;
        Kill = kill;
    }

    private void AchieveScore()
    {
        Debug.Log("achieve kill");
        this.RemainKill = 10;
        //GameManager.Enemy.SpawnMonster();
        //Enemy에 레벨업이 됐으니 다음 레벨의 코드 돌리게 하는 용도로 method 실행
        //입력 없는 method 사용 -> 해당 method가 타 method 호출하여 실행
        //사실상 껍데기 method
    }

    // if a monster killed, call this method
    public void SubtractRemain()
    {
        Debug.Log("AddKill");
        Kill++;
        RemainKill--;

        if ( (RemainKill == 0) && (GameManager.Enemy.Level < 6) )
        {
            GameManager.Enemy.LevelUp();
        }
    }
}
