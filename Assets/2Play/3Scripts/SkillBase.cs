using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace common
{
    public class SkillBase : MonoBehaviour
    {
        public bool canUse;
        private float skillCoolTime;

        protected void Start(float Cool) { 
            canUse = true;
            skillCoolTime = Cool;
        }

        public virtual void Activate()
        {

        }
        // 상속후 스킬 구현에 사용,
        // 예시 : 스킬 내용 후 coolThread.Start();
        

        protected IEnumerator CoolTime()
        {
            canUse = false;
            yield return new WaitForSecondsRealtime(skillCoolTime);
            canUse = true;
        }
        // 쿨타임이 지나면 canUse가 원래대로 되돌아오도록 함

    }
}
