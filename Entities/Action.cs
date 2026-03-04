namespace game
{
    public class Action
    {
        public enum ActionType{
            move,
            fight,
            openInventory,
            printMap,
            Invalid
        }

        public ActionType act;
        public string description;
        public string inputChar;
        public Room? destinationRoom;
        public Enemy? targetEnemy;

        public Action(ActionType act = ActionType.Invalid, string description = "oops", string inputChar = "?")
        {
            this.act = act;
            this.description = description;
            this.inputChar = inputChar;
        }

        public Action(Room destinationRoom, ActionType act = ActionType.Invalid, string description = "oops", string inputChar = "?")
        {
            this.act = act;
            this.description = description;
            this.inputChar = inputChar;
            this.destinationRoom = destinationRoom;
        }

    }
}