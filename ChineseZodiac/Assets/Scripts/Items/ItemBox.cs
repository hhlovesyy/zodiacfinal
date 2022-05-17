using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{

    public enum ItemType { Key, Bomb, Ink, Landmine };

    public ItemType itemType;

    private GameObject itemUI;

    private GameObject keyUI;

    void Start()
    {
        // ����ʱ�����ȷ���Լ������
        int typeNumber = Random.Range(1, 4);  //ȡ1-3
        switch (typeNumber)
        {
            case 1:
                itemType = ItemType.Bomb;
                break;
            case 2:
                itemType = ItemType.Ink;
                break;
            case 3:
                itemType = ItemType.Landmine;
                break;
        }
        // �����û������Կ�׹�����ô��10%�ļ�����Կ��
        if (!ItemManager.hasKey)
        {
            // ��10%�ĸ�������Կ��
            int r = Random.Range(0, 10);
            if (r == 5)
            {
                addKey();
                Debug.Log("����Կ�ף�λ����" + transform.position);
            }
        }
        FindLand();
    }
    public void addKey()
    {
        itemType = ItemType.Key;
        ItemManager.hasKey = true;
        //DisplayInKeyPanel();
    }

    public bool isKey()
    {
        if(itemType == ItemType.Key)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// ͨ�����߼����棬ȷ�������ڵ�����
    /// </summary>
    public void FindLand()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;
        float heightAboveGround = 1.0f;
        if(Physics.Raycast(ray, out hitInfo))
        {
            transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + heightAboveGround, hitInfo.point.z);
            gameObject.SetActive(true);
        }
    }

    public void DestorySelf()
    {
        Debug.Log("��������Ϊ"+itemType);
        // ��������δ��
        if (FindItemUI())
        {
            SoundManager.Instance.OnPickUpAudio();
            DisplayInItemBar();
            Destroy(gameObject);
        }
    }

    // ���������Ƿ�������ѡ����һ��panel
    private bool FindItemUI()
    {
        if(GameObject.Find("ItemIcon_1").GetComponent<Image>().color.a == 0.0f)
        {
            itemUI = GameObject.Find("ItemIcon_1");
            return true;
        }
        else if (GameObject.Find("ItemIcon_2").GetComponent<Image>().color.a == 0.0f)
        {
            itemUI = GameObject.Find("ItemIcon_2");
            return true;
        }
        else if (GameObject.Find("ItemIcon_3").GetComponent<Image>().color.a == 0.0f)
        {
            itemUI = GameObject.Find("ItemIcon_3");
            return true;
        }
        return false;
    }
    private void DisplayInItemBar()
    {
        Debug.Log("������ʾ��UI�������������������������������������������������������");
        string imgPath;
        switch (itemType)
        {
            case ItemType.Bomb:
                // �ҵ��ļ�·��������Panel
                //string imgPath = Application.dataPath + "Images/ItemsIcon/" + "bomb.png
                imgPath = "Images/ItemsIcon/" + "bomb";
                itemUI.GetComponent<Image>().color = new Color(255, 255, 255, 1.0f);
                itemUI.GetComponent<Image>().sprite = Resources.Load(imgPath, typeof(Sprite)) as Sprite;
                Debug.Log("��ը������������������������������������������������������������");
                Debug.Log(imgPath);
                break;
            case ItemType.Ink:
                // �ҵ��ļ�·��������Panel
                //string imgPath = Application.dataPath + "Images/ItemsIcon/" + "bomb.png
                imgPath = "Images/ItemsIcon/" + "ink";
                itemUI.GetComponent<Image>().color = new Color(255, 255, 255, 1.0f);
                itemUI.GetComponent<Image>().sprite = Resources.Load(imgPath, typeof(Sprite)) as Sprite;
                Debug.Log("��ī֭����������������������������������������������������������");
                Debug.Log(imgPath);
                break;
            case ItemType.Landmine:
                // �ҵ��ļ�·��������Panel
                //string imgPath = Application.dataPath + "Images/ItemsIcon/" + "bomb.png
                imgPath = "Images/ItemsIcon/" + "landmine";
                itemUI.GetComponent<Image>().color = new Color(255, 255, 255, 1.0f);
                itemUI.GetComponent<Image>().sprite = Resources.Load(imgPath, typeof(Sprite)) as Sprite;
                Debug.Log("�ǵ��ף���������������������������������������������������������");
                Debug.Log(imgPath);
                break;
        }
    }

    public void DisplayInKeyPanel()
    {
        keyUI = GameObject.Find("KeyPanel");
        keyUI.GetComponent<Image>().color = new Color(255, 255, 255, 1.0f);
    }
}