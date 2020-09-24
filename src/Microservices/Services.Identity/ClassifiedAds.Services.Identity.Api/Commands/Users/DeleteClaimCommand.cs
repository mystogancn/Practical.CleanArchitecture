﻿using ClassifiedAds.Application;
using ClassifiedAds.Services.Identity.Entities;
using ClassifiedAds.Services.Identity.Repositories;

namespace ClassifiedAds.Services.Identity.Commands.Users
{
    public class DeleteClaimCommand : ICommand
    {
        public User User { get; set; }
        public UserClaim Claim { get; set; }
    }

    public class DeleteClaimCommandHandler : ICommandHandler<DeleteClaimCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteClaimCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Handle(DeleteClaimCommand command)
        {
            command.User.Claims.Remove(command.Claim);
            _userRepository.AddOrUpdate(command.User);
            _userRepository.UnitOfWork.SaveChanges();
        }
    }
}
