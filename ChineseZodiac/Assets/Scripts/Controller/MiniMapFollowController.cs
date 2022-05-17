using UnityEngine;

public class MiniMapFollowController : MonoBehaviour
{
    public Camera MiniMapCamera;
    public Transform player;
    public Transform miniPlayerIcon;

    // С��ͼ�������Ⱦ��С��Χ��ֵ
    public float minSize;
    public float maxSize;
    // С��ͼ��Ⱦ��Χ
    private float mapSize;

    private void Awake()
    {
        mapSize = MiniMapCamera.orthographicSize;
    }

    void Update()
    {
        // С��ͼλ���������ƶ�
        MiniMapCamera.transform.position = new Vector3(player.position.x, MiniMapCamera.transform.position.y, player.position.z);
        // ����icon�Ƕȸ����ͼ�ƶ�
        miniPlayerIcon.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y);
    }

    public void ChangeMapSize(float value)
    {
        mapSize += value;
        mapSize = Mathf.Clamp(mapSize, minSize, maxSize);
        MiniMapCamera.orthographicSize = mapSize;
    }
}
