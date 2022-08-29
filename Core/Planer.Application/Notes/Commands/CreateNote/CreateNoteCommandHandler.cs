using MediatR;
using Planer.Application.Interfaces;
using Planer.Domain;

namespace Planer.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler
        : IRequestHandler<CreateNoteCommand, Guid>
    {

        private readonly INotesDbContext _dbContext;

        public CreateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext; 

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
                Title = request.Title,
                Details = request.Details,
                Created = DateTime.Now,
                Updated = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
