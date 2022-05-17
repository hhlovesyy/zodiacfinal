using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public static string id = "";


    // Use this for initialization
    void Start()
    {
        //�������
        NetManager.AddEventListener(NetManager.NetEvent.Close, OnConnectClose);
        NetManager.AddMsgListener("MsgKick", OnMsgKick);
        //��ʼ��
        PanelManager.Init();
        BattleManager.Init();
        //�򿪵�½���
        PanelManager.Open<LoginPanel>();
        //PanelManager.Open<MinimapPanel>();
    }


    // Update is called once per frame
    void Update()
    {
        NetManager.Update();
    }

    //�ر�����
    void OnConnectClose(string err)
    {
        Debug.Log("�Ͽ�����");
    }

    //��������
    void OnMsgKick(MsgBase msgBase)
    {
        PanelManager.Open<TipPanel>("��������");
    }
}
