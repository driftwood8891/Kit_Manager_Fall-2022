namespace Kit_Manager_Fall_2022.Models
{
    public class DropDownLists
    {
        public enum statusOptions
        {
            // Enum dropdown list for status code field - This maintains data integrity when creating database entries.
            
            Checked_In = 1,
            Checked_Out = 2,
            Dead = 3,
            Lost = 4,
            In_Transit = 5,
            Needs_Repair = 6,
            Pending = 7,
            Ready = 8,
            Unknown = 9
        }
    }
}
