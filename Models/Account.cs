using System.ComponentModel.DataAnnotations;

public class Account {
    public int id { get; set; }
    
    [Required]
    public string username { get; set; }
    
    [Required]
    public string firstName { get; set; }
    
    [Required]
    public string lastName  { get; set; }

    [Required]
    [EmailAddress]
    public string emailAdrss  { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 8)]
    public string psswd { get; set; }

    public bool newsUpd  { get; set; }
    public bool productUpd  { get; set; }

    public IFormFile ProfilePicture { get; set; }
}