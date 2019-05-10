using System;

namespace SolsticeData
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Company { get; set; }
        [StringLength(255)]
        public string Profile { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Image { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public string Birthdate { get; set; }
        [StringLength(255)]
        public string PersonalPhoneNumber { get; set; }
        [StringLength(255)]
        public string WorkPhoneNumber { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Line1 { get; set; }
        [StringLength(255)]
        public string Line2 { get; set; }
        [StringLength(255)]
        public string City { get; set; }
        [StringLength(255)]
        public string PostalCode { get; set; }
        [StringLength(255)]
        public string State { get; set; }
        [StringLength(255)]
        public string Country { get; set; }
    }
}