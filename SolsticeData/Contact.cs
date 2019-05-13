using System;

namespace SolsticeData
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Contact
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [StringLength(255)]
        public string Name { get; set; }
        /// <summary>Gets or sets the company.</summary>
        /// <value>The company.</value>
        [StringLength(255)]
        public string Company { get; set; }
        /// <summary>Gets or sets the profile image in BASE64 format.</summary>
        /// <value>A BASE64 string containing the profile image.</value>
        [Column(TypeName = "nvarchar(MAX)")]
        [CustomValidation(typeof(Base64ImageValidator), "Validate")]
        public string ProfileImage { get; set; }
        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [StringLength(255)]
        public string Email { get; set; }
        /// <summary>Gets or sets the birthdate.</summary>
        /// <value>The birthdate.</value>
        public string Birthdate { get; set; }
        /// <summary>Gets or sets the personal phone number.</summary>
        /// <value>The personal phone number.</value>
        [StringLength(255)]
        public string PersonalPhoneNumber { get; set; }
        /// <summary>Gets or sets the work phone number.</summary>
        /// <value>The work phone number.</value>
        [StringLength(255)]
        public string WorkPhoneNumber { get; set; }
        /// <summary>Gets or sets the address.</summary>
        /// <value>The address.</value>
        public Address Address { get; set; }
    }

    public class Base64ImageValidator
    {
        public static ValidationResult Validate(string input, ValidationContext context)
        {
            if(string.IsNullOrEmpty(input))
            {
                return ValidationResult.Success;
            }

            if (input.Length % 4 == 0 && !input.Contains(" ") &&
                !input.Contains("\t") && !input.Contains("\r") && !input.Contains("\n"))
            {
                try
                {
                    Convert.FromBase64String(input);
                    return ValidationResult.Success;
                }
                catch (Exception)
                {
                }
            }

            return new ValidationResult("The provided value is not a valid Base64 encoded image.");
        }
    }

    /// <summary>Represents a postal address.</summary>
    public class Address
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>
        /// The address line1.
        /// </value>
        [StringLength(255)]
        public string Line1 { get; set; }
        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>
        /// The address line2.
        /// </value>
        [StringLength(255)]
        public string Line2 { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [StringLength(255)]
        public string City { get; set; }
        [StringLength(255)]
        public string PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [StringLength(255)]
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [StringLength(255)]
        public string Country { get; set; }
    }
}