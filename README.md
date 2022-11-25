# BattleCity

</br>

## 1. 플레이 방법
- 깃허브 내의 파일을 받아서 플레이 해보실 수 있습니다.

## 2. 제작 기간 & 참여 인원
- 2022년 7월 15일 ~ 11월 16일
- 개인 프로젝트

</br>

## 3. 사용 기술
  - c# Form

</br>

## 4. 트러블 슈팅
  - enemy와 player의 총알이 맞부딪히면서 사라지도록 수정했어야 합니다.
  
  - 하지만 가끔씩 총알들이 눈으로는 부딪혔지만 시스템 상으로는 판정이 나오지 않아 여러번 버그가 발생하였습니다.

  - enemy와 player의 총알 위치를 잡아서 범위 설정 후 그 안에 겹쳤을 시 총알이 사라지도록 수정하였습니다.

<details>
<summary><b>코드</b></summary>
<div markdown="1">

~~~java
/**
 * 게시물 필터 (Tag Name)
 */
if (enemyTankArray.Count != 0) {
    for (int i = 0; i < enemyTankArray.Count; i++) {
        if (enemyTankArray[i].X - 17 < playerBulletPos.X && enemyTankArray[i].X + 17 > playerBulletPos.X &&
            enemyTankArray[i].Y - 17 < playerBulletPos.Y && enemyTankArray[i].Y + 17 > playerBulletPos.Y && enemyTankArray[i].isSpawn) {
            EnemyLifeCount--;
            BoomEffectNum.Add(1);
            BoomEffectPos.Add(new Point(playerBulletPos.X, playerBulletPos.Y));
            enemyBoomEffectNum.Add(1);
            enemyBoomEffectPos.Add(new Point(enemyTankArray[i].X, enemyTankArray[i].Y));
            enemyTankArray.RemoveAt(i);
            i--;
            playerBulletDir = -1;
        }
    }
}
~~~

</div>
</details>

## 5.그 외 오류들
  - 1스테이지에서 player 사망 시 게임종료가 아닌 다음 스테이지로 넘어가는 문제
  - 총알이 많아지면 성능 하락이 일어나는 문제
  - 창 크기를 최대화 했을 경우 맵이 늘어나는 문제
  
  
## 6.느낀점
- 옛날부터 많이 했었던 고전 게임이였고 모작을 하는 김에 최대한 따라 만들어보려고 했습니다.
   또다른 경험을 하고 실력이 향상되었기 때문에 만족합니다.
