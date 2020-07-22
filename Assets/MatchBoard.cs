using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchBoard : MonoBehaviour
{
    public GameObject Point;
    public GameObject MatchGesImage;
    public GameObject Win;
    int[] MatchOrder = new int[5];
    int point = 0;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        MatchOrder = new int[] { 1, 2, 1, 4, 3, 5, 2, 3, 5, 4};
    }

    // Update is called once per frame
    void Update()
    {
        string currentGesName = GameObject.Find("GestureDetector").GetComponent<GestureDetection>().currentGesName;

        string matchGesName = "Gesture" + MatchOrder[i];

        if (i>0) {
            MatchGesImage.transform.GetChild(MatchOrder[i-1] - 1).gameObject.SetActive(false);
        }

        MatchGesImage.transform.GetChild(MatchOrder[i]-1).gameObject.SetActive(true);

        if(currentGesName == matchGesName) {
            point += 10;
            Point.GetComponent<TextMesh>().text = ""+point;
            i++;
        }

        if (point == 100) {
            Win.SetActive(true);
        }
    }
}
