using _0_Framework.Application;
using AccountManagement.Domain.AccountAgg;
using AcountManagement.Application.Contracts.Account;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation= new OperationResult();
            var account = _accountRepository.GetT(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if(command.Password!=command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Create(CreateAccount command)
        {
            var operation = new OperationResult();
            if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password=_passwordHasher.Hash(command.Password);
            var account = new Account(command.Fullname, command.Username, password, command.Mobile, command.RoleId);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetT(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile 
                    && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            account.Edit(command.Fullname, command.Username,  command.Mobile, command.RoleId);
            _accountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
