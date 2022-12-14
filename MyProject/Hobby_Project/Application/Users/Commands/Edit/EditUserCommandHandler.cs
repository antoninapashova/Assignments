using Application.Logger;
using Application.Repositories;
using AutoMapper;
using Hobby_Project;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.Edit
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public EditUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _log = SingletonLogger.Instance;
        }
        
        public async Task<int> Handle(EditUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) 
                    throw new NullReferenceException("Edit user command is null!");

                 User user = _mapper.Map<User>(command);
                 await _unitOfWork.UserRepository.Update(user);
                 await _unitOfWork.Save();
                 return await Task.FromResult(command.Id);

            }catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
