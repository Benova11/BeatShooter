using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSkinsPneal : MonoBehaviour
{
    [SerializeField] GameObject _buttonPreab;
    [SerializeField] Material _gunMaterial;
   
    [SerializeField]GunSkin[] _gunSkins;

    List<Button> buttonsList = new List<Button>();
    void Start()
    {
        for (int i = 0; i < _gunSkins.Length; i++)
        {

            var b = Instantiate(_buttonPreab);
            b.transform.parent = transform;
            buttonsList.Add(b.GetComponent<Button>());
            b.GetComponent<Image>().sprite = _gunSkins[i]._GunSkin;
            SetOutline(b);

        }

        setButton();
    }

    private static void SetOutline(GameObject b)
    {
        Outline outline = b.AddComponent<Outline>();
        outline.effectColor = Color.red;
        outline.effectDistance = new Vector2(10, -10);
        outline.enabled = false;
    }

    void setButton()
    {

        for (int i = 0; i < buttonsList.Count; i++)
        {
            int d = i;
            Button item = buttonsList[i];
            item.onClick.AddListener(() => setGunTexture(d,item));    
           
        }
    }

    // called from event 

    public void setGunTexture(int gunTexture , Button button)
    {
        foreach (var item in buttonsList)
        {
            item.GetComponent<Outline>().enabled = false;
        }
        button.GetComponent<Outline>().enabled = true;
        _gunMaterial.mainTexture = _gunSkins[gunTexture]._GunSkin.texture;
        Debug.Log(gunTexture);
    }
}


[System.Serializable]
public class GunSkin
{
    public int AmmountToOpne;
    public Sprite _GunSkin;
}
