﻿using _0_Framework.Application;
using AccountManagement.Domain.AccountAgg;
using AcountManagement.Application.Contracts.Account;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthHelper _authHelper;

        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IAuthHelper authHelper)
        {
            _authHelper = authHelper;
            _passwordHasher = passwordHasher;
            _accountRepository = accountRepository;
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

            if (_accountRepository.Exists(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            account.Edit(command.Fullname, command.Username, command.Mobile, command.RoleId);
            _accountRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation=new OperationResult();
            var account = _accountRepository.GetBy(command.Username);
            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUsername);

            (bool Verified, bool NeedsUpgrade) result = _passwordHasher.Check(account.Password, command.Password);
            if(!result.Verified)
                return operation.Failed(ApplicationMessages.WrongPassword);

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.Fullname, account.Username);
            _authHelper.Signin(authViewModel);

            return operation.Succeeded();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
