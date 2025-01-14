using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase {
    [HttpPost]
    public IActionResult CreateAccount([FromBody] Account account) {
        if (account == null) {
            return BadRequest("Account data is required.");
        }

        // Process the image file
        if (account.ProfilePicture != null) {
            var imageFileName = Path.GetFileName(account.ProfilePicture.FileName);
            var imageFilePath = Path.Combine("wwwroot/uploads/images", imageFileName);

            if (!Directory.Exists("wwwroot/uploads/images")) {
                Directory.CreateDirectory("wwwroot/uploads/images");
            }

            using (var stream = new FileStream(imageFilePath, FileMode.Create)) {
                account.ProfilePicture.CopyTo(stream);
            }
        }

        return Ok(new { Message = "Account created successfully!", account });
    }
}