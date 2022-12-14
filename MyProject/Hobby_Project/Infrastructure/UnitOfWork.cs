using Application.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HobbyDbContext _hobbyDbContext;

        public UnitOfWork(HobbyDbContext hobbyDbContext, IUserRepository userRepository, 
            IHobbyArticleRepository hobbyArticleRepository, ICommentRepository commentRepository, 
            ITagRepository tagRepository, ISubCategoryRepository subCategoryRepository, 
            ICategoryRepository categoryRepository, IPhotoRepository photoRepository)
        {
            _hobbyDbContext = hobbyDbContext;
            UserRepository = userRepository;
            HobbyArticleRepository = hobbyArticleRepository;
            CommentRepository = commentRepository;
            TagRepository = tagRepository;
            SubCategoryRepository = subCategoryRepository;
            CategoryRepository = categoryRepository;
            PhotoRepository = photoRepository;
        }

        public IUserRepository UserRepository { get; private set; }
        public IHobbyArticleRepository HobbyArticleRepository { get; private set; }
        public ICommentRepository CommentRepository { get; private set; }
        public ITagRepository TagRepository { get; private set; }
        public ISubCategoryRepository SubCategoryRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IPhotoRepository PhotoRepository { get; private set; }
        public void Dispose()
        {
            _hobbyDbContext.Dispose();
        }

        public async Task Save()
        {
            await _hobbyDbContext.SaveChangesAsync();
        }
    }
}
