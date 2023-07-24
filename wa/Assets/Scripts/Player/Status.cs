using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;

////////////////////////////////////
// �v���C���[�̃X�e�[�^�X���Ǘ�����X�N���v�g
////////////////////////////////////

public class Status : MonoBehaviour
{
    

    //�^�C�}�[
    float delta = 0;
    //�A���ŉ�]���������Ȃ����߂̃X�p��
    float rotationSpan = 1.0f;

    //�v���C���[�̏��
    public enum PlayerSituation
    { 
        walk,
        run,
        jump
    }
    PlayerSituation nowSituation = PlayerSituation.walk;

    //�v���C���[�̐������
    public enum PlayerSurvival
    { 
        life,                   //�������
        collisionDeath,         //�Փ˂ɂ�鎀�S���
        fallDeath               //�����ɂ�鎀�S���
    }
    PlayerSurvival nowSurvival = PlayerSurvival.life;

    //�����̌����Ă���p��O�̂������̌��݂̃v���C���[�����Ă������
    public enum PlayerDirection
    {
        front,
        right,
        back,
        left
    }
    PlayerDirection nowDirection = PlayerDirection.front;


    void Update()
    {
        //�f���^����
        this.delta += Time.deltaTime;
    }


    /// <summary>
    /// 3�b���Ԃ�؂肩����R���[�`��
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeSituation()
    {
        //3�b�ҋ@
        yield return new WaitForSeconds(3f);
        //Debug.Log("�X�e�[�^�X�R���[�`�����s");
        //��Ԃ�؂�ւ�
        this.nowSituation = PlayerSituation.run;
    }

    /// <summary>
    /// ���݂̃v���C���[�̏�Ԃ�Ԃ�
    /// </summary>
    public PlayerSituation GetNowPlayerSituation()
    {
        return this.nowSituation;
    }

    /// <summary>
    /// ���݂̃v���C���[�̕�����Ԃ�
    /// </summary>
    public PlayerDirection GetNowPlayerDirection()
    {
        return this.nowDirection;
    }

    /// <summary>
    /// ���݂̃v���C���[�̐�����Ԃ�Ԃ�
    /// </summary>
    public PlayerSurvival GetNowPlayerSurvival()
    {
        return this.nowSurvival;
    }

    /// <summary>
    /// ��Ԃ�ڒn��Ԃɉ����čX�V����
    /// </summary>
    /// <param name="GroundFlg">�ڒn�t���O</param>
    /// <param name="flick">���݂̓��͏��</param>
    /// <param name="turnGroundFlg">�^�[���\�Ȓn�ʂƂ̐ڒn�t���O</param>
    public void SituationUpdate(bool GroundFlg, ScreenInput.FlickDirection flick, bool turnGroundFlg)
    {
        //�W�����v��Ԃ���n�ʂɂ����ꍇ�X�e�[�^�X��ύX
        if (GroundFlg == true && this.nowSituation == PlayerSituation.jump)
        {
            this.nowSituation = PlayerSituation.run;
        }

        //�t���b�N�̏�Ԃɉ����ăX�e�[�^�X��ύX
        //�v���C���[�������Ă����Ԃ̂Ƃ��̓W�����v�ɐ؂�ւ���
        if (flick == ScreenInput.FlickDirection.UP && this.nowSituation == PlayerSituation.run) this.nowSituation = PlayerSituation.jump;
         
        //������ς��鏈��
        //�^�[���\�Ȓn�ʂɂ��邩�̊m�F
        //�����ԉ��̊m�F
        if(flick == ScreenInput.FlickDirection.RIGHT && this.delta > this.rotationSpan && nowSituation == PlayerSituation.run && turnGroundFlg == true)
        {
            ChangeDirection(true);
            //�f���^������
            this.delta = 0;
        }
        if(flick == ScreenInput.FlickDirection.LEFT && this.delta > this.rotationSpan && nowSituation == PlayerSituation.run && turnGroundFlg == true)
        {
            ChangeDirection(false);
            //�f���^������
            this.delta = 0;
        }
  
    }

    /// <summary>
    /// �v���C���[�̕�����ς���
    /// </summary>
    /// <param name="rightFlg">�E�����̉�]���̃t���O</param>
    void ChangeDirection(bool rightFlg)
    {
        //���݂̕����Ɖ�]�����ɉ���������
        switch(this.nowDirection)
        {
            case PlayerDirection.front:
                if(rightFlg == true)
                {
                    this.nowDirection = PlayerDirection.right;
                    Debug.Log("�v���C���[�̕����ύX(�E)");
                }
                else
                {
                    this.nowDirection = PlayerDirection.left;
                    Debug.Log("�v���C���[�̕����ύX(��)");
                }
                break;
            case PlayerDirection.right:
                if (rightFlg == true)
                {
                    this.nowDirection = PlayerDirection.back;
                    Debug.Log("�v���C���[�̕����ύX(��)");
                }
                else
                {
                    this.nowDirection = PlayerDirection.front;
                    Debug.Log("�v���C���[�̕����ύX(�O)");
                }
                break;
            case PlayerDirection.back:
                if (rightFlg == true)
                {
                    this.nowDirection = PlayerDirection.left;
                    Debug.Log("�v���C���[�̕����ύX(��)");
                }
                else
                {
                    this.nowDirection = PlayerDirection.right;
                    Debug.Log("�v���C���[�̕����ύX(�E)");
                }
                break;
            case PlayerDirection.left:
                if (rightFlg == true)
                {
                    this.nowDirection = PlayerDirection.front;
                    Debug.Log("�v���C���[�̕����ύX(�O)");
                }
                else
                {
                    this.nowDirection = PlayerDirection.back;
                    Debug.Log("�v���C���[�̕����ύX(��)");
                }
                break;
        }
        
    }
}
