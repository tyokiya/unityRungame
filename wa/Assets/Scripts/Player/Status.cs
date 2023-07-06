using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// �v���C���[�̃X�e�[�^�X���Ǘ�����X�N���v�g
////////////////////////////////////

public class Status : MonoBehaviour
{
    //�v���C���[�̗̑�
    //int HP = 10;
    //�v���C���[�̏��
    public enum situation
    { 
        walk,
        run,
        jump
    }
    situation nowSituation = situation.walk;

    /// <summary>
    /// 3�b���Ԃ�؂肩����R���[�`��
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeSituation()
    {
        //3�b�ҋ@
        yield return new WaitForSeconds(3f);
        Debug.Log("�X�e�[�^�X�R���[�`�����s");
        //��Ԃ�؂�ւ�
        this.nowSituation = situation.run;
    }

    /// <summary>
    /// ���݂̃v���C���[�̏�Ԃ�Ԃ�
    /// </summary>
    public situation GetNowPlayerSituation()
    {
        return this.nowSituation;
    }

    /// <summary>
    /// ��Ԃ�ڒn��Ԃɉ����čX�V����
    /// </summary>
    /// <param name="GroundFlg">�ڒn�t���O</param>
    /// <param name="flick">���݂̓��͏��</param>
    public void SituationUpdate(bool GroundFlg, ScreenInput.FlickDirection flick)
    {
        //�W�����v��Ԃ���n�ʂɂ����ꍇ�X�e�[�^�X��ύX
        if (GroundFlg == true && this.nowSituation == situation.jump) this.nowSituation = situation.run;

        //�t���b�N�̏�Ԃɉ����ăX�e�[�^�X��ύX
        //�v���C���[�������Ă����Ԃ̂Ƃ��̓W�����v�ɐ؂�ւ���
        if (flick == ScreenInput.FlickDirection.UP && this.nowSituation == situation.run) this.nowSituation = situation.jump;
  
    }

   
}
