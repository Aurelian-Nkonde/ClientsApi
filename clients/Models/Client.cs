using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace clients.Models
{
    public class Client 
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required!")]
        [MinLength(2)]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required(ErrorMessage = "gender is required!")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "age is required!")]
        public int Age { get; set; }
        [Required(ErrorMessage = "email is required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "city is required!")]
        [MinLength(2)]
        [MaxLength(200)]
        public string City { get; set; }
        [Required(ErrorMessage = "amount is required!")]
        [DataType(DataType.Currency)]
        public string Amount { get; set; }

    }
}