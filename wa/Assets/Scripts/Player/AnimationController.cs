using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //�e�I�u�W�F�N�g
    GameObject ParentObject;

    //�A�j���[�^�[������ϐ�
    Animator animator;

    void Start()
    {
        //�e�I�u�W�F�N�g���擾
        ParentObject = GameObject.Find("Player");
        //�R���|�[�l���g�擾
        this.animator = ParentObject.GetComponent<Animator>();
    }

    /// <summary>
    /// 3�b��g���K�[��؂�ւ���R���[�`��
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeAnimaiton()
    {
        //3�b�ҋ@
        yield return new WaitForSeconds(3f);
        //Debug.Log("�g���K�[�R���[�`�����s");
        //run�A�j���[�V�����̃g���K�[�ɐ؂�ւ���
        this.animator.SetTrigger("RunTrigger");
    }

    /// <summary>
    /// �A�j���[�V�����X�V
    /// </summary>
    /// <param name="flick">���͏��</param>
    /// <param name="situation">�v���C���[�̏��</param>
    public void AnimationUpdate(ScreenInput.FlickDirection flick, Status.situation situation)
    {
        //���͂��󂯂��g���K�[��؂�ւ���
        if(flick == ScreenInput.FlickDirection.UP && situation == Status.situation.run) this.animator.SetTrigger("JumpTrigger");
    }
}
