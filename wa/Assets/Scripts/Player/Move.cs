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
    //���ړ��X�s�[�h
    [SerializeField] Vector3 rightVelocity = new Vector3(0.1f, 0f, 1.5f);
    [SerializeField]Vector3 leftVelocity = new Vector3(-0.1f, 0f, 1.5f);

    //�^�C�}�[
    float delta = 0;
    //�ړ��\�^�C�~���O�̃X�p��
    float lateralMoveSpan = 0.1f;

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

    // Update is called once per frame
    void Update()
    {
        //delta����
        this.delta += Time.deltaTime;
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
            //�t���b�N�ɉ����ď���
            switch (flick)
            {
                case ScreenInput.FlickDirection.UP:             //�W�����v����
                    if (situation == Status.PlayerSituation.run)
                    {
                        //�W�����v
                        PlayerJump();
                    }
                    else//�W�����v�ł��ȏꍇ�O�֐i��
                    {
                        PlayerRun(direction);
                    }
                    break;
                case ScreenInput.FlickDirection.RIGHT:          //�E�ړ�����
                                                                //�A���ŏ������Ȃ��悤�X�p����݂���
                    if (this.delta > this.lateralMoveSpan && situation == Status.PlayerSituation.run)
                    {
                        //�E�Ɍ�������
                        PlayerLateralMoveMent(true);
                        //�������ς�������Ƃ��}�l�[�W���[�ɒm�点��
                        manager.PlayerChangeDirection(true);
                    }
                    else         //���ړ��ł��Ȃ��Ƃ��͑��菈���̎��s
                    {
                        PlayerRun(direction);
                    }
                    break;
                case ScreenInput.FlickDirection.LEFT:           //���ړ�����
                                                                //�A���ŏ������Ȃ��悤�X�p����݂���
                    if (this.delta > this.lateralMoveSpan && situation == Status.PlayerSituation.run)
                    {
                        //���Ɍ�������
                        PlayerLateralMoveMent(false);
                        //�������ς�������Ƃ��}�l�[�W���[�ɒm�点��
                        manager.PlayerChangeDirection(false);
                    }
                    else         //���ړ��ł��Ȃ��Ƃ��͑��菈���̎��s
                    {
                        PlayerRun(direction);
                    }
                    break;
                default:
                    //���菈��
                    PlayerRun(direction);
                    break;
            }
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
                pos.transform.Translate(0, 0, 0.2f);
                break;
            case PlayerDirection.right:
                pos.transform.Translate(0.2f, 0, 0);
                break;
            case PlayerDirection.back:
                pos.transform.Translate(0, 0, -0.2f);
                break;
            case PlayerDirection.left:
                pos.transform.Translate(-0.2f, 0, 0);
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

        pos.transform.Translate(0, 0, 0.1f);
    }

    /// <summary>
    /// �v���C���[�̉��ړ�
    /// </summary>
    /// <param name="rightFlg">�E�ړ��̃t���O(false�̂Ƃ��͍��ɓ���)</param>
    void PlayerLateralMoveMent(bool rightFlg)
    {
        if (rightFlg == true && this.pos.position.x < 0.8)    //�E�ړ�
        {
            //rd.velocity = rightVelocity;
            //������
            this.pos.Translate(0.8f, 0, 0.2f);
            //�E����������@
            this.pos.eulerAngles = new Vector3(0, 90.0f, 0);
            
            
        }
        else if (rightFlg == false && this.pos.position.x > -0.8)//���ړ� 
        {
            //rd.velocity = leftVelocity;
            //������
            this.pos.Translate(0.8f * -1, 0, 0.2f);
            //������������@
            this.pos.eulerAngles = new Vector3(0, -90.0f, 0);
        }

        //delta������
        this.delta = 0;
    }
}
