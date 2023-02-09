using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagicInventory : MonoBehaviour
{
    public MagicSlotUI[] magicslotUI;

    public List<GameObject> allMagicInPosession;

    //����� ������ ������ -1 �� � ������ ������� �ʴ´�.
    public int currentMagicIndex = -1;

    //[HideInInspector]
    public GameObject currentWeapon;

    private PlayerMagic PM;

    void Awake() // ��ũ��Ʈ ������� ������ ������ �غ���� �ʾƼ� Start -> Awake�� ����
    {
        //ó�� ���� ������ ���� ��ο� ������ ���õȴ�.
        //magicslotUI[currentMagicIndex].MagicImage.color = Color.gray;
        //���� ���� ���� MagicSlotUI ������Ʈ�� �����Ѵ�.        
        magicslotUI[0] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("FireMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[1] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("FireMagicSlotPanel2").GetComponent<MagicSlotUI>();
        magicslotUI[2] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("AquaMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[3] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("AquaMagicSlotPanel2").GetComponent<MagicSlotUI>();
        magicslotUI[4] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("ThunderMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[5] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("ThunderMagicSlotPanel2").GetComponent<MagicSlotUI>();
        magicslotUI[6] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("EarthMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[7] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("EarthMagicSlotPanel2").GetComponent<MagicSlotUI>();
        magicslotUI[8] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("WindMagicSlotPanel1").GetComponent<MagicSlotUI>();
        magicslotUI[9] = GameObject.Find("Canvas").transform.Find("MagicPanel").transform.Find("WindMagicSlotPanel2").GetComponent<MagicSlotUI>();

        //�� ó�� ������ ���õǾ� �ִ�.
        currentWeapon = allMagicInPosession[default];
        //���õ� ù��° ������ ������Ʈ�� Ȱ��ȭ �ȴ�.
        //magicslotUI[0].MagicImage.color = Color.white;

        PM = this.GetComponent<PlayerMagic>();
    }

    // Update is called once per frame
    void Update()
    {
        TrySwitchMagic();
    }

    private void TrySwitchMagic()
    {
        int MagicIndexToGoTo = currentMagicIndex;
        //q�Ǵ� QŰ�� ������
        if(Input.GetKeyDown(KeyCode.Q))
        {
            //���� ���⸦ �����Ѵ�.
            MagicIndexToGoTo--;
        }
        //e�Ǵ� EŰ�� ������
        else if(Input.GetKeyDown(KeyCode.E))
        {
            //���� ���⸦ �����Ѵ�.
            MagicIndexToGoTo++;
        }

        /*���� MagicIndexToGoTo���� 0���� ���ų�
         allMagicInPosesion.Length���̶� ���ų�
        currentMagicIndex�� ������ �������� �ʴ´�.*/
        if (MagicIndexToGoTo<0
            ||MagicIndexToGoTo==allMagicInPosession.Count
            ||MagicIndexToGoTo==currentMagicIndex)
        {
            return;
        }

        //currentWeapon�� MagicIndexToGoTo�� ���� ������.
        currentWeapon = allMagicInPosession[MagicIndexToGoTo];
        currentMagicIndex = MagicIndexToGoTo;
    }
    
    //��ưŬ������ ������ ���� �ٲٱ�
    public void MagicChange(int magicIndex)
    {
        //�ش� ������ ���õǾ� ���� ������
        if (currentMagicIndex != magicIndex)
        {
            //�����ϴ� �����̸�
            if (currentMagicIndex != -1)
            {
                //������ ���õ� ���� �̹����� ���� ��Ӱ� �ȴ�.
                magicslotUI[currentMagicIndex].MagicImage.color = Color.gray;
            }
            //���� ���õ� ���� �̹����� ���� ��� �ȴ�.
            magicslotUI[magicIndex].MagicImage.color = Color.white;

            //���� ����ϴ� ������ ���õ� ������ ������ ����Ѵ�.
            currentWeapon = allMagicInPosession[magicIndex];
            //���� ������ ���� ���õ� ������ ������ �ȴ�.
            currentMagicIndex = magicIndex;

            PM.SetMagicNum(currentMagicIndex);
        }
        else  //���õǾ� �ִ� ������ ��ġ�ϸ�
        {
            //��Ӱ� ���Ѵ�.
            magicslotUI[magicIndex].MagicImage.color = Color.gray;

            //� �����̵� ������ �ʴ´�.
            currentWeapon = null;
            //���� ������ ���Ե��� �ʴ´�.
            currentMagicIndex = -1;
        }
    }
}
