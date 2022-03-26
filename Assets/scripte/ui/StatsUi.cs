using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatsUi: MonoBehaviour
{
    public Image WaterFill;
    public Image FoodFill;

    public Text ob;

    public int _good, _bad, _cop;
    private IEnumerator Start()
    {
        playerStats.instanc.OnStatChance += Instanc_OnStatChance;
        yield return new WaitForSeconds(0.1f);
        NpcManager.instanc.passTheNewStat += PassTheNewStat;
        

    }

    private void PassTheNewStat(int good, int bad, int cop)
    {
        _good = good;
        _bad = bad;
        _cop = cop;
        ob.text = "good: " + _good + "\n"
                  + "bad: " + _bad + "\n" +
                  "cops: " + _cop;

    }

    private void Instanc_OnStatChance(float maxWater, float currentWater, float maxFood, float currentFood)
    {
        WaterFill.fillAmount = currentWater / maxWater;
        FoodFill.fillAmount = currentFood / maxFood;
    }
}
