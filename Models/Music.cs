using System.ComponentModel.DataAnnotations;

public class Music {
    public int id { get; set; }

    [Required]
    public string name { get; set; }

    [Required]
    public IFormFile musicPicture { get; set; }

    [Required]
    public IFormFile soundFile { get; set; }
}