namespace StateMachineTest.Classes
{
    public class Student : BaseEntity
    {
        private float fatigue;
        private float boredom;
        private string name;

        public Student(string name):base()
        {
            StateMachine = new StateMachine(this);

            Name = name;
            StateMachine.GlobalState = States.GlobalStudent.Instance;
            StateMachine.ChangeState(States.GoingToUni.Instance);
            
        }

        public float Fatigue
        {
            get
            {
                return fatigue;
            }

            set
            {
                fatigue = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public float Boredom
        {
            get
            {
                return boredom;
            }

            set
            {
                boredom = value;
            }
        }

        public override void Update()
        {
            
            StateMachine.Update();
            base.Update();
        }
    }
}
