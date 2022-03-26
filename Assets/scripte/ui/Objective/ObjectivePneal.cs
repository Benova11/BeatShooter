using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class ObjectivePneal : MonoBehaviour
{
    [SerializeField] TMP_Text ObjectiveHeadline;
    [SerializeField] TMP_Text ObjectiveDiscrpsion;
    [SerializeField] Image firstImage;
    [SerializeField] Image SecondImage;
    [SerializeField] GameObject completedObject;
    [SerializeField] GameObject questButton;
   
    public Transform questList;

    List<Objective> questButtontList = new List<Objective>();
    private void Start()
    {
        ObjectiveManager.instance.OnGetingNewObjective += Instance_OnGetingNewObjective;
        ObjectiveManager.instance.OnEndingObjective += Instance_OnEndingObjective;

        ObjectiveHeadline.SetText("Objective");
        ObjectiveDiscrpsion.SetText("no active Objective");
        firstImage.gameObject.SetActive(false);
        SecondImage.gameObject.SetActive(false);
        completedObject.SetActive(false);
    }

    private void Instance_OnEndingObjective()
    {
        completedObject.SetActive(true);
    }

    private void Instance_OnGetingNewObjective(Objective obj)
    {

        foreach (var item in ObjectiveManager._listOfQuest)
        {
            if (!questButtontList.Contains(item))
            {
                var newItem = Instantiate(questButton);
                newItem.transform.SetParent(questList);
                newItem.GetComponent<Button>().onClick.AddListener(() => showObjective(item));
                newItem.GetComponentInChildren<TMP_Text>().SetText(item.ObjectiveHeadline);
            }
            questButtontList.Add(item);

        }
       

    }

    private void showObjective(Objective obj)
    {
        ObjectiveHeadline.SetText(obj.ObjectiveHeadline);
        if (obj is ObjectiveBool objectiveBool)
        {
            ObjectiveDiscrpsion.SetText(objectiveBool.ObjectiveDiscrpsion);
        }
        else if (obj is ObjectiveInt objectiveInt)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(objectiveInt.ObjectiveDiscrpsion);
            string rgb = objectiveInt.MissionAccomplished ? "green" : "red";
            builder.AppendLine($"<color={rgb}>{objectiveInt.RequiredQuantity +"/" + objectiveInt.CurrentQuantity}</color>");

            ObjectiveDiscrpsion.SetText(builder);

            objectiveInt.OnChange += ObjectiveInt_OnChange; ;
        }
        else
        {
            ObjectiveDiscrpsion.SetText(obj.ObjectiveDiscrpsion);
        }
        completedObject.SetActive(false);

        if (obj.firstImage != null)
        {
            firstImage.gameObject.SetActive(true);
            firstImage.sprite = obj.firstImage;
        }
        else
        {
            firstImage.gameObject.SetActive(false);
        }

        if (obj.SecondImage != null)
        {
            SecondImage.gameObject.SetActive(true);
            SecondImage.sprite = obj.SecondImage;
        }
        else
        {
            SecondImage.gameObject.SetActive(false);
        }

        if (obj.MissionAccomplished)
        {
            completedObject.SetActive(true);
        }
        else
        {
            completedObject.SetActive(false);
        }
    }

    private void ObjectiveInt_OnChange(ObjectiveInt obj)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(obj.ObjectiveDiscrpsion);
        string rgb = obj.MissionAccomplished ? "green" : "red";
        builder.AppendLine($"<color={rgb}>{obj.RequiredQuantity + "/" + obj.CurrentQuantity}</color>");

        ObjectiveDiscrpsion.SetText(builder);
    }
}
