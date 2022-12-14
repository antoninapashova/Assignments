using Application.Logger;
using Application.Notifications;
using Application.Repositories;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Domain.Entity;
using Hobby_Project;
using HobbyProject.Application.Photos.Commands.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using HobbyProject.Application.Hobby;

namespace Application.Hobby.Commands.Create
{
    public class CreateHobbyCommandHandler : IRequestHandler<CreateHobbyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILog _log;
        private readonly IMapper _mapper;

        public CreateHobbyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _log = SingletonLogger.Instance;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateHobbyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command == null) 
                    throw new NullReferenceException("Create hobby command is null!");

                 var hobby = _mapper.Map<HobbyArticle>(command);
                 foreach(var t in command.Tags)
                 {
                    var result =  await _unitOfWork.TagRepository.GetByIdAsync(t.Id);
                    if(!hobby.Tags.Any(x=>x.Id.Equals(x.Id)))
                        hobby.Tags.Add(_mapper.Map<Tag>(t));
                 } 
                
                await _unitOfWork.HobbyArticleRepository.Add(hobby);
                await _unitOfWork.Save();
                return await Task.FromResult(hobby.Id);

            }catch(Exception e)
            {
                _log.LogError(e.Message);
                throw;
            }
        }
    }
}
