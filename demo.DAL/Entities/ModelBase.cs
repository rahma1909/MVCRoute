using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.DAL.Entities
{
    public class ModelBase
    {
        public int Id { get; set; }
        //properities for administartion {security}

        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } //when it made in the database
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        
    }
}
