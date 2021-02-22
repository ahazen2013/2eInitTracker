using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Add : MonoBehaviour
{
    public Button button;
    public GameObject character;
    GameObject parent;
    int x = 0;
    //public List<NewBehaviourScript> characters = new List<NewBehaviourScript>();
    public List<GameObject> characters = new List<GameObject>();
    Vector3 pos;
    NewBehaviourScript nbs;
    bool done = false;
    GameObject charac;

    // Start is called before the first frame update
    void Start()
    {
        Button b = button.GetComponent<Button>();
        b.onClick.AddListener(AddNew);
        // pos = Camera.main.ViewportToWorldPoint(new Vector3(30f, 40f, 0));
        // button.transform.position.Set(Screen.width / 3, 9 * Screen.height / 10 + 20, pos.z);
        pos = new Vector3(Screen.width / 2, 9*Screen.height / 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("return"))
        {
            done = false;
            while (!done)
            {
                done = true;
                for (int i = 0; i < characters.Count; ++i)
                {
                    if (i < characters.Count - 1)
                    {
                        if (characters[i].GetComponent<NewBehaviourScript>().initRoll > characters[i + 1].GetComponent<NewBehaviourScript>().initRoll)
                        {
                            charac = characters[i];
                            characters[i] = characters[i + 1];
                            characters[i + 1] = charac;
                            done = false;
                        }
                    }
                    //Debug.Log(characters[i].GetComponent<NewBehaviourScript>().initRoll);
                }
            }
            pos = new Vector3(Screen.width / 2, 9 * Screen.height / 10, 0);
            for (int i = characters.Count-1; i >= 0; --i)
            {
                characters[i].transform.position = pos;
                pos.y -= 30;
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    void AddNew()
    {
        GameObject g = Instantiate(character, pos, Quaternion.identity);
        pos.y -= 30;
        g.transform.SetParent(gameObject.transform);
        characters.Add(g);
        ++x;
        //Debug.Log(x);
        parent = g;
    }
}
