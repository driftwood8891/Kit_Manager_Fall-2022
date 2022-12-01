using System.Collections;
using System.Collections.Generic;

namespace Kit_Manager_Fall_2022.Models
{
    public class SharedData : IEnumerable
    {
        // Class that combines data from multiple tables (Read-Only data)
        public IEnumerable<Student> studentdetails { get; set; }
        public IEnumerable<Equipment> equipmentdetails { get; set; }
        public IEnumerator GetEnumerator()
        {
	        throw new System.NotImplementedException();
        }
    }
}
