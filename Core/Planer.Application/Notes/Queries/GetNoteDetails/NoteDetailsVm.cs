using AutoMapper;
using Planer.Application.Common.Mappings;
using Planer.Domain;

namespace Planer.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Title,
                opt => opt.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Details,
                opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.Id,
                opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Created,
                opt => opt.MapFrom(note => note.Created))
                .ForMember(noteVm => noteVm.Updated,
                opt => opt.MapFrom(note => note.Updated));
        }
    }
}
