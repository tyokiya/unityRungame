using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using static Status;

////////////////////////////////////
// �v���C���[�̓������Ǘ�����X�N���v�g
////////////////////////////////////

public class Move : MonoBehaviour
{
    //�e�I�u�W�F�N�g
    GameObject ParentObject;

    //���W�b�h�{�f�B������ϐ�
    Rigidbody rd;
    Transform pos;

    [SerializeField]
    //�W�����v��
    private float jumpForce = 500.0f;

    //�����X�s�[�h
    [SerializeField] Vector3 walkVelocity = new Vector3 (0f, 0f, 1f);
    //����X�s�[�h
    [SerializeField] Vector3 runVelocity = new Vector3(0f, 0f, 2f);
    //float runSpeed = 0.2f;
    //�e�X�g�p
    float runSpeed = 0.001f;


    //�C���X�y�N�^�[����ݒ�
    //�v���C���[�}�l�[�W���[�̃X�N���v�g
    public PlayerManager manager;

    void Awake()
    {
        //�e�I�u�W�F�N�g���擾
        ParentObject = GameObject.Find("Player");
        //�R���|�[�l���g�擾
        this.rd = ParentObject.GetComponent<Rigidbody>();
        this.pos = ParentObject.GetComponent<Transform>();
    }

    /// <summary>
    /// �v���C���[����͏�Ԃɉ����ē�����
    /// </summary>
    /// <param name="flick">���݂̓��͏��</param>
    /// <param name="situation">���݂̃v���C���[�̏��</param>
    /// <param name="direction">���݂̃v���C���[�̌����Ă����</param>
    public void MovePlayerUpdate(ScreenInput.FlickDirection flick, Status.PlayerSituation situation, Status.PlayerDirection direction)
    {
        //������Ԃ̂Ƃ��͂��邫�����̂�
        if(situation == Status.PlayerSituation.walk)
        {
            PlayerWalk();
        }
        else     //�����Ԃ̂Ƃ��̓t���b�N���󂯎�肻��ɍ��킹���������s��
        {
            //�W�����v����
            if (flick == ScreenInput.FlickDirection.UP && situation == Status.PlayerSituation.run)
            {
                //�W�����v
                PlayerJump();
            }
            //���菈��
            PlayerRun(direction);
            //���݂̌����ɍ��킹�ăv���C���[����]
            RotationPlayer(direction);
        }
        
    }

    /// <summary>
    /// �v���C���[�̃W�����v����
    /// </summary>
    void PlayerJump()
    {
        //y���ɗ͂�������
        this.rd.AddForce(transform.up * this.jumpForce);
        //������
        transform.Translate(0, 0, 0.2f);
        //z���̈ړ���������
        //rd.velocity = this.runVelocity;
    }

    /// <summary>
    /// �v���C���[�̑���ړ�
    /// </summary>
    /// <param name="direction">�v���C���[�̕���</param>
    void PlayerRun(Status.PlayerDirection direction)
    {
        //rd.velocity = this.runVelocity;
        //�v���C���[�̕����ɍ��킹���ړ�����
        switch (direction)
        {
            case PlayerDirection.front:
                pos.transform.Translate(0, 0, runSpeed);
                break;
            case PlayerDirection.right:
                pos.transform.Translate(runSpeed, 0, 0);
                break;
            case PlayerDirection.back:
                pos.transform.Translate(0, 0, -runSpeed);
                break;
            case PlayerDirection.left:
                pos.transform.Translate(-runSpeed, 0, 0);
                break;
        }

    }

    /// <summary>
    /// �v���C���[�̕����ړ�
    /// </summary>
    void PlayerWalk()
    {
        //z���̈ړ���������
        //rd.velocity = this.walkVelocity;

        //pos.transform.Translate(0, 0, 0.1f);
        //�����p
        pos.transform.Translate(0, 0, 0.001f);
    }

    /// <summary>
    /// �v���C���[�̌�������]��
    /// </summary>
    /// <param name="direction">�v���C���[�̌����Ă����</param>
    void RotationPlayer(Status.PlayerDirection direction)
    {
        //�X�e�[�^�X�̌����Ă�����ɉ����ĉ�]
        switch(direction)
        {
            case PlayerDirection.front:
                //�O����������@
                this.pos.eulerAngles = new Vector3(0, 0, 0);
                break;
            case PlayerDirection.right:
                //�E����������@
                this.pos.eulerAngles = new Vector3(0, 90.0f, 0);
                break;
            case PlayerDirection.back:
                //�����������@
                this.pos.eulerAngles = new Vector3(0, 180.0f, 0);
                break;
            case PlayerDirection.left:
                //������������@
                this.pos.eulerAngles = new Vector3(0, 270.0f, 0);
                break;
        }
    }
}
