using System.ComponentModel.DataAnnotations;

public class UpdateContactDto
{
    [Required(ErrorMessage = "First name is required.")]
    [MinLength(3, ErrorMessage = "First name must be at least 3 characters long.")]
    [MaxLength(50, ErrorMessage = "First name must not exceed 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long.")]
    [MaxLength(50, ErrorMessage = "Last name must not exceed 50 characters.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string EmailAddress { get; set; } = string.Empty;
    public bool Favorite { get; set; } = false;

    [Required(ErrorMessage = "At least one contact number is required.")]
    [MinLength(3, ErrorMessage = "Contact number must be at least 3 digits long.")]
    [MaxLength(15, ErrorMessage = "Contact number must not exceed 15 digits.")]
    public string ContactNumber1 { get; set; } = string.Empty;

    [Required(ErrorMessage = "At least one contact label is required.")]
    [MinLength(2, ErrorMessage = "Contact label must be at least 2 characters long.")]
    [MaxLength(20, ErrorMessage = "Contact label must not exceed 20 characters.")]
    public string NumberLabel1 { get; set; } = string.Empty;


    [MinLength(3, ErrorMessage = "Contact number must be at least 3 digits long.")]
    [MaxLength(15, ErrorMessage = "Contact number must not exceed 15 digits.")]
    public string? ContactNumber2 { get; set; } = string.Empty;

    [MinLength(2, ErrorMessage = "Contact label must be at least 2 characters long.")]
    [MaxLength(20, ErrorMessage = "Contact label must not exceed 20 characters.")]
    public string? NumberLabel2 { get; set; } = string.Empty;


    [MinLength(3, ErrorMessage = "Contact number must be at least 3 digits long.")]
    [MaxLength(15, ErrorMessage = "Contact number must not exceed 15 digits.")]
    public string? ContactNumber3 { get; set; } = string.Empty;

    [MinLength(2, ErrorMessage = "Contact label must be at least 2 characters long.")]
    [MaxLength(20, ErrorMessage = "Contact label must not exceed 20 characters.")]
    public string? NumberLabel3 { get; set; } = string.Empty;



    [Required(ErrorMessage = "At least one address is required.")]
    [MinLength(2, ErrorMessage = "Address details must be at least 2 characters long.")]
    [MaxLength(100, ErrorMessage = "Last name must not exceed 100 characters.")]
    public string AddressDetails1 { get; set; } = string.Empty;

    [Required(ErrorMessage = "At least one address label is required.")]
    [MinLength(2, ErrorMessage = "Address label must be at least 2 characters long.")]
    [MaxLength(20, ErrorMessage = "Address label must not exceed 20 characters.")]
    public string AddressLabel1 { get; set; } = string.Empty;


    [MinLength(2, ErrorMessage = "Address details must be at least 2 characters long.")]
    [MaxLength(100, ErrorMessage = "Last name must not exceed 100 characters.")]
    public string? AddressDetails2 { get; set; } = string.Empty;

    [MinLength(2, ErrorMessage = "Address label must be at least 2 characters long.")]
    [MaxLength(20, ErrorMessage = "Address label must not exceed 20 characters.")]
    public string? AddressLabel2 { get; set; } = string.Empty;


    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
