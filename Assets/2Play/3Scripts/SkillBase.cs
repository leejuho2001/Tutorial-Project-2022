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
        // ����� ��ų ������ ���,
        // ���� : ��ų ���� �� coolThread.Start();
        

        protected IEnumerator CoolTime()
        {
            canUse = false;
            yield return new WaitForSecondsRealtime(skillCoolTime);
            canUse = true;
        }
        // ��Ÿ���� ������ canUse�� ������� �ǵ��ƿ����� ��

    }
}
