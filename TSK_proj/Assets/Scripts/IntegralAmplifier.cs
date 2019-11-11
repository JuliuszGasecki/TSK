using UnityEngine;

namespace Assets.Scripts
{
    public class IntegralAmplifier : MonoBehaviour
    {
        [SerializeField]
        private bool directCurrent;
        [SerializeField]
        private double frequency;
        [SerializeField]
        private double Uo;
        [SerializeField]
        private double Uwe;
        [SerializeField]
        private double Uwy;
        [SerializeField]
        private double R1;
        [SerializeField]
        private double R2;
        [SerializeField]
        private double K;
        [SerializeField]
        private double capacitor;
        [SerializeField]
        private double simulationSpeed;

        public void SetSimulationSpeed(float val)
        {
            simulationSpeed = val;
        }

        public void SetUwo(float val)
        {
            Uo = val;
        }

        public float GetUwo()
        {
            return (float)Uo;
        }

        public float GetUwe()
        {
            return (float)Uwe;
        }

        public float GetUwy()
        {
            return (float)Uwy;
        }

        SoundGenerator soundGen;
        // Start is called before the first frame update
        void Start()
        {
            soundGen = GameObject.Find("Audio").GetComponent<SoundGenerator>();
            calculateAlternatingCurrent();
            calculateUwy();
            soundGen.setValues(440 + Uwy);
        }


        private void calculateUwy()
        {
            //Uwy = -Uwe / (2 * Mathf.PI * frequency * R1 * capacitor);
            Uwy = -Uwe / (2 * Mathf.PI * frequency * R1 * capacitor) * Mathf.Sin(2 * Mathf.PI * Time.time * (float)simulationSpeed + Mathf.PI/2);
        }

        private void calculateAlternatingCurrent()
        {
            Uwe = Uo * Mathf.Sin((2 * Mathf.PI * (float)frequency) * Time.time * (float)simulationSpeed);
        }

        // Update is called once per frame
        void Update()
        {
            calculateAlternatingCurrent();
            calculateUwy();
            //Debug.Log(Uwe + " on enter | on exit " + Uwy);
            soundGen.setValues(440 + Uwy);
        }
    }
}
