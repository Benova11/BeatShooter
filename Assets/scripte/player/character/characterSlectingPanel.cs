using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSlectingPanel : MonoBehaviour
{
    [SerializeField] Transform button;
    List<Button> _b = new List<Button>();
    int index;
    characterSlecting _characterSlecting;
    private void Start()
    {
        _characterSlecting = characterSlecting.insance;


        for (int i = 0; i < _characterSlecting._characters.Count; i++)
        {       
            character item = characterSlecting.insance._characters[i];
            var b = Instantiate(button);
            
            b.transform.SetParent(transform);
            b.name = "B" + i;
            b.GetComponent<Image>().sprite = item.Icon;
           _b.Add( b.GetComponent<Button>());
           
        }

        setButton();



    }
    

    void characterSlect(int i)
    {
        _characterSlecting.characterSlect(i);
    }
    void setButton()
    {

        for (int i = 0; i < _b.Count; i++)
        {
            int d = i;
            Button item = _b[i];
            item.onClick.AddListener(() => characterSlect(d));
            Debug.Log(index);
        }
    }


}
