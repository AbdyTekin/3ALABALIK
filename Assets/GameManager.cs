using UnityEngine;
using UnityEngine.Splines;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject sharkSmile;
    [SerializeField] private GameObject sharkSad;
    [SerializeField] private float sharkDuration;

    private SplineAnimate sharkSmileAnimator;
    private SplineAnimate sharkSadAnimator;


    private void Start()
    {
        sharkSmileAnimator = sharkSmile.GetComponent<SplineAnimate>();
        sharkSadAnimator = sharkSad.GetComponent<SplineAnimate>();
        SetSharkState(smileActive: true, sadActive: false);
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