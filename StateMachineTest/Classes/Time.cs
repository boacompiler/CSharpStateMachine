namespace StateMachineTest.Classes
{
    class Time : BaseEntity
    {
        private int hour;

        public Time() : base()
        {
            StateMachine = new StateMachine(this);
            StateMachine.GlobalState = States.GlobalTime.Instance;
            StateMachine.ChangeState(States.Day.Instance);
        }

        public int Hour
        {
            get
            {
                return hour;
            }

            set
            {
                hour = value;
            }
        }

        public override void Update()
        {

            StateMachine.Update();
            base.Update();
        }
    }
}
