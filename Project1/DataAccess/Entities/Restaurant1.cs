using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Restaurant1
    {
        public Restaurant1()
        {
            Review1 = new HashSet<Review1>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Review1> Review1 { get; set; }
    }
}
