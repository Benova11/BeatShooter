using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiPlayerHelath : MonoBehaviour
{
    private Health _playerHealth;
    [SerializeField] TMP_Text _textHealt;
    [SerializeField]
    Image _HealthBarFill;
    private void Start()
    {
        _playerHealth = FindObjectOfType<movement>().GetComponent<Health>();
        _playerHealth.onHealthChancged += UiPlayerHelath_onHealthChancged;

    }

    private void UiPlayerHelath_onHealthChancged(int cur, int max)
    {
      //  _textHealt.text = string.Format("{0}/{1}", cur, max);
        var pct = (float)cur / (float)max;
        _HealthBarFill.fillAmount = pct;
    }
}

