using System.Collections;
using System.Collections.Generic;

namespace Kit_Manager_Fall_2022.Models
{
    public class SharedData 
    {
        public IEnumerable<Student> studentdetails { get; set; }
        public IEnumerable<Equipment> equipmentdetails { get; set; }
    }
}
