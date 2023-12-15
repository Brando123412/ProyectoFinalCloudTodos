using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GUI_Controller : MonoBehaviour
{
    //[SerializeField] PlayerController _playerC;
    [SerializeField] TMP_Text _score;
    [SerializeField] TMP_Text _name;
    [SerializeField] TMP_Text _time;
    public int min, seg;
    private float restante;
    // Start is called before the first frame update
    void Start()
    {
        restante = (min * 60) + seg;
    }

    // Update is called once per frame
    void Update()
    {
        restante += Time.deltaTime;
        int tempMin = Mathf.FloorToInt(restante / 60);
        int tempSeg = Mathf.FloorToInt(restante % 60);
        _time.text = string.Format("{00:00}:{01:00}",tempMin,tempSeg);

    }
}
