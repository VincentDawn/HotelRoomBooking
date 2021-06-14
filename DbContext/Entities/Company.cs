using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomCodeFirstDb.Entities
{
    // Brand, parent, or whoever the parent entity that owns the hotel is
    public class Company
    {
        [Key] // Adding it in to show I know it exists
        public int CompanyId { get; set; }

        // Non-nullabe and not varchar(max)
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        // Putting virtual here to enable lazyloading
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
