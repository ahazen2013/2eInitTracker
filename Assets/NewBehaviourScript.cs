using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public InputField init;
    public InputField pName;
    public Text text;
    public int initRoll;
    //Vector3 temp;

    
    // Start is called before the first frame update
    void Start()
    {
        init.text = "";
        pName.text = "";
        initRoll = 0;
        //temp = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            //gameObject.transform.position -= temp;
            initRoll = int.Parse(init.text);
            initRoll = UnityEngine.Random.Range(1, 21) - initRoll;
            text.text = pName.text + " " + initRoll.ToString();
            //temp = new Vector3(20 * (initRoll + 2), 0.0f, 0.0f);
            //gameObject.transform.position += temp;
        }
    }
}
