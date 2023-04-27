namespace AcountManagement.Application.Contracts.Account
{
    public class ChangePassword : CreateAccount
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
