using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float dur1;
    [SerializeField] private float dur2;
    [SerializeField] private float dur3;

    [SerializeField] private GameObject sharkSmile;
    [SerializeField] private GameObject sharkSad;
    [SerializeField] private float sharkDuration;

    [SerializeField] private GameObject fish1;
    [SerializeField] private GameObject fish2;
    [SerializeField] private GameObject fish3;

    [SerializeField] private SplineContainer sharkSpline1;
    [SerializeField] private SplineContainer sharkSpline2;

    [SerializeField] private SplineContainer fishSpline1;
    [SerializeField] private SplineContainer fishSpline2; 
    [SerializeField] private SplineContainer fishSpline3;


    private SplineAnimate sharkSmileAnimator;
    private SplineAnimate sharkSadAnimator;


    private void Start()
    {
        sharkSmileAnimator = sharkSmile.GetComponent<SplineAnimate>();
        sharkSadAnimator = sharkSad.GetComponent<SplineAnimate>();
        SetSharkState(smileActive: true, sadActive: false);

        fish1.GetComponent<SplineAnimate>().Container = fishSpline1;
        fish1.GetComponent<SplineAnimate>().Duration = dur1;
        fish1.GetComponent<SplineAnimate>().Play();
        Debug.Log(dur1);
        DOVirtual.DelayedCall(dur1, () =>
        {
            fish1.transform.localScale = new Vector3(1, -1, 1);
            fish1.GetComponent<SplineAnimate>().Container = fishSpline2;
            fish1.GetComponent<SplineAnimate>().Duration = dur2;
            fish1.GetComponent<SplineAnimate>().Play();

            DOVirtual.DelayedCall(dur2, () =>
            {
                Debug.Log("2");
                DOVirtual.DelayedCall(dur3, () =>
                {
                    Debug.Log("3");
                });
            });
        });
    }

    private void Update()
    {
        if (sharkSmile.activeSelf)
        {
            if(sharkSmileAnimator.ElapsedTime >= sharkDuration)
                SetSharkState(smileActive: true, sadActive: true);
        }
        else if (sharkSad.activeSelf)
        {
            if(sharkSadAnimator.ElapsedTime >= sharkDuration)
                SetSharkState(false, false);
        }
    }

    private void SetSharkState(bool smileActive, bool sadActive)
    {
        sharkSmile.SetActive(smileActive);
        sharkSad.SetActive(sadActive);
    }
}