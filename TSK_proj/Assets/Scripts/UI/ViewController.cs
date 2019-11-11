using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ViewController : MonoBehaviour
{
    float t = -350;

    GameObject simulator;
    GameObject ampImg;

    public Text Uwo;
    public Text Uwe;
    public Text Uwy;

    public List<Sprite> sprites;

    Queue<GameObject> inputPoints;
    Queue<GameObject> outputPoints;

    GameObject graph;
    public Sprite inputSprite;
    public Sprite outputSprite;

    // Start is called before the first frame update
    void Start()
    {
        inputPoints = new Queue<GameObject>();
        outputPoints = new Queue<GameObject>();
        simulator = GameObject.Find("Simulator");
        ampImg = GameObject.Find("AmpImage");
        graph = GameObject.Find("Graph");
        SetAmp(0);
    }

    public void SetAmp(int val)
    {
        ampImg.GetComponent<Image>().sprite = sprites[val];
        if (val == 0)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = true;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = false;
            simulator.GetComponent<SummingAmplifier>().enabled = false;
            simulator.GetComponent<IntegralAmplifier>().enabled = false;
            simulator.GetComponent<DifferentialAmplifier>().enabled = false;
        }
        else if (val == 1)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = false;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = true;
            simulator.GetComponent<SummingAmplifier>().enabled = false;
            simulator.GetComponent<IntegralAmplifier>().enabled = false;
            simulator.GetComponent<DifferentialAmplifier>().enabled = false;
        }
        else if (val == 2)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = false;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = false;
            simulator.GetComponent<SummingAmplifier>().enabled = true;
            simulator.GetComponent<IntegralAmplifier>().enabled = false;
            simulator.GetComponent<DifferentialAmplifier>().enabled = false;
        }
        else if (val == 3)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = false;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = false;
            simulator.GetComponent<SummingAmplifier>().enabled = false;
            simulator.GetComponent<IntegralAmplifier>().enabled = true;
            simulator.GetComponent<DifferentialAmplifier>().enabled = false;
        }
        else if (val == 4)
        {
            simulator.GetComponent<InvertingAmplifier>().enabled = false;
            simulator.GetComponent<NonInvertingAmplifier>().enabled = false;
            simulator.GetComponent<SummingAmplifier>().enabled = false;
            simulator.GetComponent<IntegralAmplifier>().enabled = false;
            simulator.GetComponent<DifferentialAmplifier>().enabled = true;
        }
    }

    public void SetUwo(float val)
    {
        if (simulator.GetComponent<InvertingAmplifier>().enabled)
        {
            simulator.GetComponent<InvertingAmplifier>().SetUwo(val);
        }
        if (simulator.GetComponent<NonInvertingAmplifier>().enabled)
        {
            simulator.GetComponent<NonInvertingAmplifier>().SetUwo(val);
        }
        if (simulator.GetComponent<SummingAmplifier>().enabled)
        {
            simulator.GetComponent<SummingAmplifier>().SetUwo(val);
        }
        if (simulator.GetComponent<IntegralAmplifier>().enabled)
        {
            simulator.GetComponent<IntegralAmplifier>().SetUwo(val);
        }
        if (simulator.GetComponent<DifferentialAmplifier>().enabled)
        {
            simulator.GetComponent<DifferentialAmplifier>().SetUwo(val);
        }
    }

    public void SetSimulationSpeed(float val)
    {
        if (simulator.GetComponent<InvertingAmplifier>().enabled)
        {
            simulator.GetComponent<InvertingAmplifier>().SetSimulationSpeed(val);
        }
        if (simulator.GetComponent<NonInvertingAmplifier>().enabled)
        {
            simulator.GetComponent<NonInvertingAmplifier>().SetSimulationSpeed(val);
        }
        if (simulator.GetComponent<SummingAmplifier>().enabled)
        {
            simulator.GetComponent<SummingAmplifier>().SetSimulationSpeed(val);
        }
        if (simulator.GetComponent<IntegralAmplifier>().enabled)
        {
            simulator.GetComponent<IntegralAmplifier>().SetSimulationSpeed(val);
        }
        if (simulator.GetComponent<DifferentialAmplifier>().enabled)
        {
            simulator.GetComponent<DifferentialAmplifier>().SetSimulationSpeed(val);
        }
    }

    public void SetText()
    {
        if (simulator.GetComponent<InvertingAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<InvertingAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<InvertingAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<InvertingAmplifier>().GetUwy().ToString();
        }
        else if (simulator.GetComponent<NonInvertingAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<NonInvertingAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<NonInvertingAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<NonInvertingAmplifier>().GetUwy().ToString();
        }
        else if (simulator.GetComponent<SummingAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<SummingAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<SummingAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<SummingAmplifier>().GetUwy().ToString();
        }
        else if (simulator.GetComponent<IntegralAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<IntegralAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<IntegralAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<IntegralAmplifier>().GetUwy().ToString();
        }
        else if (simulator.GetComponent<DifferentialAmplifier>().enabled)
        {
            this.Uwo.text = simulator.GetComponent<DifferentialAmplifier>().GetUwo().ToString();
            this.Uwe.text = simulator.GetComponent<DifferentialAmplifier>().GetUwe().ToString();
            this.Uwy.text = simulator.GetComponent<DifferentialAmplifier>().GetUwy().ToString();
        }
    }

    private void showGrapth()
    {
        
    }
    
    private void PrepareGraph()
    {
        if(inputPoints.Count > 1000)
        {
            inputPoints.Dequeue();
            outputPoints.Dequeue();
            foreach(GameObject g in inputPoints)
            {
                g.GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(
                        g.GetComponent<RectTransform>().anchoredPosition.x- (float)0.7,
                        g.GetComponent<RectTransform>().anchoredPosition.y );
            }
            foreach (GameObject g in outputPoints)
            {
                g.GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(
                        g.GetComponent<RectTransform>().anchoredPosition.x- (float)0.7,
                        g.GetComponent<RectTransform>().anchoredPosition.y);
            }
        }
        inputPoints.Enqueue(preparePoint(true, Time.time, float.Parse(this.Uwe.text)));
        outputPoints.Enqueue(preparePoint(false, Time.time, float.Parse(this.Uwy.text)));
    }

    private GameObject preparePoint(bool isInput, float time, float val)
    {
        GameObject gm
;        if (isInput)
        {
            gm = new GameObject("inp", typeof(Image));
            gm.GetComponent<Image>().sprite = inputSprite;
        }
        else
        {
            gm = new GameObject("out", typeof(Image));
            gm.GetComponent<Image>().sprite = outputSprite;
        }
        gm.AddComponent<OscPoint>();
        gm.GetComponent<OscPoint>().value = val;
        gm.GetComponent<OscPoint>().time = t + (float)0.7;
        gm.transform.SetParent(graph.GetComponent<RectTransform>(), false);
        RectTransform r = gm.GetComponent<RectTransform>();
        r.anchoredPosition = new Vector2(t + (float)0.7, val * 2);
        r.sizeDelta = new Vector2(3, 3);
        return gm;
    }

    void Update()
    {
        t += (float)0.7;
        if(t >= 350)
        {
            t -= (float)0.7;
        }
        SetText();
        PrepareGraph();
    }
}
