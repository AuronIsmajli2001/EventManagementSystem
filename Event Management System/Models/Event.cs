using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Event_Management_System.Models
{
    
    public class Event
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        public bool IsActive { get; set; } = true;

        public string CreatedByUserId { get; set; } = string.Empty;
    }

}
