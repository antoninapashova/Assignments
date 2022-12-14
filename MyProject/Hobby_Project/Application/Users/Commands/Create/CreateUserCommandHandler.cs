using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Domain.Entity;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = SingletonLogger.Instance;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) 
                    throw new NullReferenceException("Create user command is null!");

                User user = _mapper.Map<User>(command);
                await _unitOfWork.UserRepository.Add(user);
                await _unitOfWork.Save();
                return await Task.FromResult(user);

            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
       }
    }
}
