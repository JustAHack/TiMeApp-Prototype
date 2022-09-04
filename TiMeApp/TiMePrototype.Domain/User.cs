using SimpleHashing;
using TiMePrototype.Domain.Common;

namespace TiMePrototype.Domain;

public class User : BaseDomainEntity
{
    private string _password;
    
    public string UserName { get; set; }
    public string Password
    {
        get { return _password; }
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(Password));
            _password = PBKDF2.Hash(value);
        }
    }
    public IEnumerable<Shift>? Shifts { get; set; }
}
