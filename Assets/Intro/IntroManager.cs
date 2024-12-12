using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;

public class IntroManager : MonoBehaviour
{

    [SerializeField] private float dur1;
    [SerializeField] private float dur2;
    [SerializeField] private float dur3;

    [SerializeField] private GameObject fish1;
    [SerializeField] private GameObject fish2;
    [SerializeField] private GameObject fish3;

    [SerializeField] private SplineContainer sharkSpline1;
    [SerializeField] private SplineContainer sharkSpline2;

    [SerializeField] private SplineContainer fishSpline1;
    [SerializeField] private SplineContainer fishSpline2; 
    [SerializeField] private SplineContainer fishSpline3;
    [SerializeField] private SplineContainer fishSpline4;
    [SerializeField] private SplineContainer fishSpline5;

    [SerializeField] private SplineAnimate fish1Animator;
    [SerializeField] private SplineAnimate fish2Animator;
    [SerializeField] private SplineAnimate fish3Animator;

    [SerializeField] private SplineAnimate shark1Animator;
    [SerializeField] private SplineAnimate shark2Animator;


    protected void Start()
    {

        fish1.GetComponent<SplineAnimate>().Container = fishSpline1;
        fish1.GetComponent<SplineAnimate>().Duration = dur1;
        fish1.GetComponent<SplineAnimate>().Play();
        DOVirtual.DelayedCall(dur1, () =>
        {
            fish1.transform.localScale = new Vector3(1, -1, 1);
            fish1Animator.Container = fishSpline2;
            fish1.GetComponent<Animator>().SetBool("1", false);
            fish1.GetComponent<Animator>().SetBool("2", true);
            fish1Animator.Duration = dur2 / 2;
            fish1Animator.Restart(true);

            shark1Animator.Container = sharkSpline1;
            shark1Animator.Duration = dur2;
            shark1Animator.Restart(true);
            DOVirtual.DelayedCall(dur2, () =>
            {
                shark2Animator.Container = sharkSpline2;
                shark2Animator.Duration = dur3;
                shark2Animator.Restart(true);

                fish1.transform.localScale = new Vector3(1, 1, 1);
                fish1.GetComponent<Animator>().SetBool("2", false);
                fish1.GetComponent<Animator>().SetBool("3", true);

                fish2.GetComponent<Animator>().SetBool("1", false);
                fish2.GetComponent<Animator>().SetBool("3", true);

                fish3.GetComponent<Animator>().SetBool("1", false);
                fish3.GetComponent<Animator>().SetBool("3", true);


                fish1Animator.Container = fishSpline3;
                fish2Animator.Container = fishSpline4;
                fish3Animator.Container = fishSpline5;

                fish1Animator.Duration = dur3;
                fish2Animator.Duration = dur3;
                fish3Animator.Duration = dur3;

                fish1Animator.Restart(true);
                fish2Animator.Restart(true);
                fish3Animator.Restart(true);


                DOVirtual.DelayedCall(dur3, () =>
                {
                    // logoyu getir
                });
            });
        }, false);
    }
}