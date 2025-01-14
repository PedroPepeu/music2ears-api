using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MusicController : ControllerBase {
    [HttpPost]
    public IActionResult CreateMusic([FromBody] Music music) {
        if (music == null) {
            return BadRequest("Music data is required.");
        }

        // Process the music picture file
        if (music.musicPicture != null) {
            var imageFileName = Path.GetFileName(music.musicPicture.FileName);
            var imageFilePath = Path.Combine("wwwroot/uploads/images", imageFileName);

            if (!Directory.Exists("wwwroot/uploads/images")) {
                Directory.CreateDirectory("wwwroot/uploads/images");
            }

            using (var stream = new FileStream(imageFilePath, FileMode.Create)) {
                music.musicPicture.CopyTo(stream);
            }
        }

        // Process the music sound file
        if (music.soundFile != null) {
            var soundFileName = Path.GetFileName(music.soundFile.FileName);
            var soundFilePath = Path.Combine("wwwroot/uploads/sounds", soundFileName);

            if (!Directory.Exists("wwwroot/uploads/sounds")) {
                Directory.CreateDirectory("wwwroot/uploads/sounds");
            }

            using (var stream = new FileStream(soundFilePath, FileMode.Create)) {
                music.soundFile.CopyTo(stream);
            }
        }

        return Ok(new { Message = "Account created successfully!", music });
    }
}