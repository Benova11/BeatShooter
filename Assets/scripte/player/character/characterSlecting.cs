using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSlecting : MonoBehaviour
{
    public List<character> _characters = new List<character>();
    public static characterSlecting insance;
    private void Awake()
    {
        insance = this;
        foreach (var item in GameObject.FindGameObjectsWithTag("Character"))
        {
            _characters.Add(item.GetComponent<character>());
        }
        for (int i = 0; i < _characters.Count; i++)
        {
            if (i != 0)
            {
                _characters[i].gameObject.SetActive(false);
            }
        }
        
        
    }

   public void characterSlect(int index)
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            if (i != index)
            {
                _characters[i].gameObject.SetActive(false);
            }
            else
            {
                _characters[i].gameObject.SetActive(true);
            }
        }

        
    }
}
