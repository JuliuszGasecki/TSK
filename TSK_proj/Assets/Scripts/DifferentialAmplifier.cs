using UnityEngine;

namespace Assets.Scripts
{
    public class DifferentialAmplifier : MonoBehaviour
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
        private double R2;
        [SerializeField]
        private double Capacitor;
        [SerializeField]
        private double simulationSpeed;
        private float time;

        public void SetSimulationSpeed(float val)
        {
            simulationSpeed = val;
        }

        public void SetUwo(float val)
        {
            Uo = val;
        }

        public float GetUwe()
        {
            return (float)Uwe;
        }

        public float GetUwy()
        {
            return (float)Uwy;
        }

        public float GetUwo()
        {
            return (float)Uo;
        }

        public float GetR1()
        {
            return 0;
        }

        public void SetR1(float R1)
        {
            
        }

        public float GetR2()
        {
            return (float)R2;
        }

        public void SetR2(float R2)
        {
            this.R2 = R2;
        }

        public float GetC()
        {
            return (float)Capacitor;
        }

        public void SetC(float C)
        {
            this.Capacitor = C;
        }

        SoundGenerator soundGen;
        // Start is called before the first frame update
        void Start()
        {
            time = Time.time;
            soundGen = GameObject.Find("Audio").GetComponent<SoundGenerator>();
            calculateAlternatingCurrent();
            calculateUwy();
            soundGen.setValues(440 + Uwy);
        }


        private void calculateUwy()
        {
            time = Time.time - time;
            //Uwy = -R2 * Capacitor * getDifferentialUwe();
            Uwy = 2 * Mathf.PI * frequency * R2 * Capacitor * Uwe * Mathf.Sin((float)(2 * Mathf.PI * frequency * Time.time * simulationSpeed - Mathf.PI / 2));
        }

        private double getDifferentialUwe()
        {
            return Uo * 4 * Mathf.PI * frequency * Mathf.Cos((float)(2 * Mathf.PI * frequency * Time.time * simulationSpeed));
        }

        private void calculateAlternatingCurrent()
        {
            Uwe = Uo * Mathf.Sin((float)(2*Mathf.PI * (float)frequency * Time.time * simulationSpeed));
        }

        // Update is called once per frame
        void Update()
        {
            calculateAlternatingCurrent();
            calculateUwy();
           // Debug.Log(Uwe + " on enter | on exit " + Uwy);
            soundGen.setValues(440 + Uwy);
        }
    }
}