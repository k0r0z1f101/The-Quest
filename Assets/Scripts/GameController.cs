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
    // Start is called before the first frame update
    void Awake()
    {
      createScene();
    }

    public void createScene()
    {
      //create parents
      _plants = new GameObject("Plants");
      _animals = new GameObject("Animals");
      _hero = new GameObject("Hero");

      //instanciate objects in Plants
      foreach(GameObject i in _plantsToInstanciate)
      {
        GameObject newObj = Instantiate(i, new Vector2(0, 0), Quaternion.identity) as GameObject;
        newObj.transform.SetParent(_plants.transform);
        newObj.GetComponent<SpriteRenderer>().sortingLayerName = "PasMinou";
        newObj.GetComponent<SpriteRenderer>().sortingOrder = _plantsToInstanciate.IndexOf(i);
      }

      //instanciate objects in Animals
      foreach(GameObject i in _animalsToInstanciate)
      {
        GameObject newObj = Instantiate(i, new Vector2(0, 0), Quaternion.identity) as GameObject;
        newObj.transform.SetParent(_animals.transform);
        newObj.GetComponent<SpriteRenderer>().sortingLayerName = "Minou";
        newObj.GetComponent<SpriteRenderer>().sortingOrder = _animalsToInstanciate.IndexOf(i);
      }

      //instanciate objects in Hero
      foreach(GameObject i in _heroToInstanciate)
      {
        GameObject newObj = Instantiate(i, new Vector2(0, 0), Quaternion.identity) as GameObject;
        newObj.transform.SetParent(_hero.transform);
        newObj.GetComponent<SpriteRenderer>().sortingLayerName = "Hero";
        newObj.GetComponent<SpriteRenderer>().sortingOrder = _heroToInstanciate.IndexOf(i);
      }
    }
}
