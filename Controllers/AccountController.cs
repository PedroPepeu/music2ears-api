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
        if (account.profilePicture != null) {
            var imageFileName = Path.GetFileName(account.profilePicture.FileName);
            var imageFilePath = Path.Combine("wwwroot/uploads/images", imageFileName);

            if (!Directory.Exists("wwwroot/uploads/images")) {
                Directory.CreateDirectory("wwwroot/uploads/images");
            }

            using (var stream = new FileStream(imageFilePath, FileMode.Create)) {
                account.profilePicture.CopyTo(stream);
            }
        }

        return Ok(new { Message = "Account created successfully!", account });
    }
}