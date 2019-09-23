using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    GameObject judgeText;

    // Start is called before the first frame update
    void Start()
    {

        judgeText = GameObject.Find("JudgeText");

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void judging(string result)
    {

        ChangeText(result);

    }



    private void ChangeText(string str)
    {
        judgeText.GetComponent<Text>().text = str;


        Text ext = judgeText.GetComponent<Text>();

        //取得したTextをピッタリ収まるようにサイズ変更
        ext.rectTransform.sizeDelta = new Vector2(ext.preferredWidth, ext.preferredHeight);
    }
}
