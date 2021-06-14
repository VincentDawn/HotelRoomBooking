using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomCodeFirstDb.Entities
{
    public class Hotel
    {
        // No annotation for KEY here because it is implicit if the property is named CLASSNAMEID or ID
        public int HotelId { get; set; }

        // No annotation here for ForeignKey here because it is implicit if the navigation property is named Property - ID 
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        public virtual ICollection<Room> Rooms { get; set; }

        // Alternatively you can use ForeignKey("PropertyName") like this but it's also implicit. Added it in for fun
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
