using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  private GameObject _plants;
  private GameObject _animals;
  private GameObject _hero;
  [SerializeField]
  private List<GameObject> _plantsToInstanciate;
  [SerializeField]
  private List<GameObject> _animalsToInstanciate;
  [SerializeField]
  private List<GameObject> _heroToInstanciate;
  private List<List<GameObject>> toInstantiate = new List<List<GameObject>>();
    // Start is called before the first frame update
    void Awake()
    {
      createScene();
    }

    public void createScene()
    {
      toInstantiate.Add(_plantsToInstanciate);
      toInstantiate.Add(_animalsToInstanciate);
      toInstantiate.Add(_heroToInstanciate);
      //create parents
      _plants = new GameObject("Plants");
      _animals = new GameObject("Animals");
      _hero = new GameObject("Hero");

      for(int i = 0; i < toInstantiate.Count; ++i)
      {
        foreach(GameObject j in toInstantiate[i])
        {
          GameObject newObj = Instantiate(j, new Vector2(0, 0), Quaternion.identity) as GameObject;

          switch(i)
          {
            case 0:
              newObj.transform.SetParent(_plants.transform);
              newObj.GetComponent<SpriteRenderer>().sortingLayerName = "PasMinou";
            break;
            case 1:
              newObj.transform.SetParent(_animals.transform);
              newObj.GetComponent<SpriteRenderer>().sortingLayerName = "Minou";
            break;
            case 2:
              newObj.transform.SetParent(_hero.transform);
              newObj.GetComponent<SpriteRenderer>().sortingLayerName = "Hero";
            break;
          }
          
          newObj.GetComponent<SpriteRenderer>().sortingOrder = toInstantiate[i].IndexOf(j);
        }
      }
    }
}
