using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNewProject.Models
{
    public class Shop
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public Profesion Description { get; set; }
        public string OwnerName { get; set; }
    }

    public enum Profesion
    {
        Food,
        HouseholdUtensils,
        Clothes,
        Technical,
        Natural,
        Medicine,
        All
    }
}
