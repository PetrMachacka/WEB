using Microsoft.AspNetCore.Identity;

namespace Joomla20.Models
{
    public class JUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public ICollection<Article> Articles { get; set; }

    }
}
