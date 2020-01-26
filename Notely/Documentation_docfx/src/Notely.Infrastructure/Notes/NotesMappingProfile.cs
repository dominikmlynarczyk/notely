using AutoMapper;
using Notely.Domain.Notes;
using Notely.SharedKernel;

namespace Notely.Infrastructure.Notes
{
    public class NotesMappingProfile : Profile
    {
        public NotesMappingProfile()
        {
            CreateMap<NoteEntity, Note>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => new AggregateId(x.Id)))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => new AggregateId(x.UserId)));

            CreateMap<Note, NoteEntity>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id.Id))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId.Id));
        }
    }
}
