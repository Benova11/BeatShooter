using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

[Button]
[GUIColor(0, 1, 1)]
public class FloorGenerator : MonoBehaviour
{
    public GameObject floorTile;
    public Vector3 offset = new Vector3(5, 0, 0);

    public int x =5;
    public int y =5;

    public int height;
    public int width;
    private  Transform[,] layoutStore;
    [Button]
    [GUIColor(0, 1, 1)]
    public void MakeFloer()
    {
       var offsetY = new Vector3(0, 0, 0);
        var index = 0;
        for (int i = 0; i < x; i++)
        {
             var floer =Instantiate(floorTile, transform.position + offset, quaternion.identity);
             floer.name = i.ToString();
            offset += new Vector3(5, 0, 0);
            for (int j = 0; j < y; j++)
            {
                var Floer = Instantiate(floorTile, transform.position + offsetY, quaternion.identity);
                Floer.name = j.ToString();
                offsetY += new Vector3(0, 0, 5);
            }  
            offsetY = new Vector3(index , 0, 0);
            index += 5;
        }
       //Setup();

    }
    private void Setup()
    {
        
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {

                Vector3 pos = new Vector2(x , y) ;
               
                GameObject bgTile = Instantiate(floorTile, pos, Quaternion.identity);
                bgTile.transform.parent = transform;
                bgTile.name = "BG Tile - " + x + ", " + y;
                SpawnGem(new Vector2Int(x, y));
                
              
            }
        }

        
    }
    
    private void SpawnGem(Vector2Int pos)
    {
        var gem = Instantiate(floorTile, new Vector3(pos.x +width , pos.y + height, 0f), Quaternion.identity);
        gem.name = "Gem - " + pos.x + ", " + pos.y;
      
        
    }

}