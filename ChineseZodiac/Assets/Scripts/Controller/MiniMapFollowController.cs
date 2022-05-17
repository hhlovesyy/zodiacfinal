using UnityEngine;

public class MiniMapFollowController : MonoBehaviour
{
    public Camera MiniMapCamera;
    public Transform player;
    public Transform miniPlayerIcon;

    // 小地图摄像机渲染大小范围阈值
    public float minSize;
    public float maxSize;
    // 小地图渲染范围
    private float mapSize;

    private void Awake()
    {
        mapSize = MiniMapCamera.orthographicSize;
    }

    void Update()
    {
        // 小地图位置随人物移动
        MiniMapCamera.transform.position = new Vector3(player.position.x, MiniMapCamera.transform.position.y, player.position.z);
        // 人物icon角度跟随地图移动
        miniPlayerIcon.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y);
    }

    public void ChangeMapSize(float value)
    {
        mapSize += value;
        mapSize = Mathf.Clamp(mapSize, minSize, maxSize);
        MiniMapCamera.orthographicSize = mapSize;
    }
}
