using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform FinishPlatform;
    public Slider Slider;
    public float AcceptableFinishPlayerDistance = 1f;

    private float _startY;
    private float _minimumReachY;

    private void Start()
    {
        _startY = Player.transform.position.y;
    }

    private void Update()
    {
        _minimumReachY = Mathf.Min(_minimumReachY, Player.transform.position.y);
        float finishY = FinishPlatform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY + AcceptableFinishPlayerDistance, _minimumReachY);
        Slider.value = t;
    }
}
