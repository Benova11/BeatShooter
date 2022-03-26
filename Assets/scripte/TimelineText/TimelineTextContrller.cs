using System;
using System.Collections;
using UnityEngine;
using System.Linq;

public class TimelineTextContrller : MonoBehaviour
{
    [SerializeField] putSenets[] Senteans;
    [SerializeField] private TimelineTextManager _timelineTextManager;

    private void OnEnable() => StartCoroutine(startTake());

    IEnumerator startTake()
    {
        _timelineTextManager.TextObject.enabled = true;
        for (int i = 0; i < Senteans.Length; i++)
        {
            _timelineTextManager.TextObject.text = Senteans[i].Sentean;
            yield return new WaitForSeconds(Senteans[i].timeToRead);
            if (Senteans.Last() == Senteans[i])
            {
                _timelineTextManager.TextObject.enabled = false;
            }
        }

    }
}
[System.Serializable]
public class putSenets
{
    [TextArea] public string Sentean;
    public float timeToRead = 3;
}
