using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
   public List<Room> Rooms = new List<Room>();
   public List<GameObject> Furniture = new List<GameObject>();

   private Queue<Transform> spownLeft= new Queue<Transform>();
   public int itemToSpown =5;
  
   [Button]
   [GUIColor(1,1 , 0)]
   public void setAllRoom()
   {
       foreach (var variaRoom in Rooms)
       {
           variaRoom.setAllObject();
       }
   }

   [Button]
   [GUIColor(0, 1, 0)]
   public void GeneratRoom()
   {
       spownLeft.Clear();
       var room = Instantiate(Rooms[Random.Range(0, Rooms.Count)].room);
       var spownPoint = room.GetComponent<Room>().SpownPoint;
       foreach (var item in spownPoint)
       {
           spownLeft.Enqueue(item);
       }

       Snap(spownPoint);
      
       for (var index = 0; index < itemToSpown; index++)
       {
           Debug.Log(spownLeft.Count);
           var rndomIndex = Random.Range(0, Furniture.Count);
           var furniture = Instantiate(Furniture[rndomIndex]); 
          // Furniture.Remove(Furniture[rndomIndex]) ;
           var first = spownLeft.First();
           furniture.transform.position = first.position;
           furniture.transform.SetParent(room.transform);
           spownLeft.Dequeue();
       }
   }
   
   void Snap(List<Transform> POINTS )
   {
       foreach (var item in POINTS)
       {
           item.rotation = Quaternion.identity;
           RaycastHit hit;
            
           if (Physics.Raycast(item.position, Vector3.down, out hit, 1000))
           {
               Debug.Log(hit.point.y);
               item.position =
                   new Vector3(item.position.x, hit.point.y, item.position.z);
           }
       }
   }
}