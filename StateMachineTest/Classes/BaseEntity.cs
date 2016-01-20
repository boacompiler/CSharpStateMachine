namespace StateMachineTest.Classes
{
    public class BaseEntity
    {
        private int id;
        static int nextID;

        private StateMachine stateMachine;

        public int ID
        {
            get
            {
                return id;
            }
        }

        public StateMachine StateMachine
        {
            get
            {
                return stateMachine;
            }

            set
            {
                stateMachine = value;
            }
        }

        public BaseEntity()
        {
            SetID();
            
        }

        private void SetID()
        {
                id = nextID;
                nextID += 1;
        }

        public virtual void Update()
        {

        }

        public void HandleMessage(Telegraph.Telegram telegram)
        {
            stateMachine.HandleMessage(telegram);
        }
    }
}
