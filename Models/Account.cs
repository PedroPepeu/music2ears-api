using System.ComponentModel.DataAnnotations;

public class Account {
    public int id { get; set; }
    
    [Required]
    public string username { get; set; }
    
    [Required]
    public string firstName { get; set; }
    
    public string lastName  { get; set; }

    [Required]
    [EmailAddress]
    public string emailAdrss  { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 8)]
    public string password { get; set; }

    public bool newsUpd  { get; set; }
    public bool productUpd  { get; set; }

    public IFormFile profilePicture { get; set; }
}