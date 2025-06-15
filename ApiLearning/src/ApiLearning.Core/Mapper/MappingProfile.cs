using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.Models;
using ApiLearning.Core.ProjectAggregate;
using AutoMapper;

namespace ApiLearning.Core.Mapper;
public class MappingProfile : Profile
{
  public MappingProfile()
  {

    // Create mappings between Projects and ProjectDto refin-> refout
    CreateMap<Projects, ProjectDto>();
    CreateMap<ProjectDto, Projects>();
    CreateMap<Projects, CreateProjectDto>();
    CreateMap<CreateProjectDto, Projects>();
  }
}
