using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiLearning.Core.Interfaces;
using ApiLearning.Core.Mapper;
using ApiLearning.Core.Models;
using ApiLearning.Core.ProjectAggregate;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ApiLearning.Core.Services;
public class ProjectService : IProjectService
{
  private readonly IMapper _mapper;
  private readonly IRepository<Projects> _projectRepository;

  public ProjectService(IMapper mapper, IRepository<Projects> projectRepository)
  {
    _mapper = mapper;
    _projectRepository = projectRepository;
  }
  [Authorize(Roles = "Admin,SuperAdmin")]
  public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto createProjectDto)
  {
    try
    {
      var project = _mapper.Map<Projects>(createProjectDto);
      var result = await _projectRepository.AddAsync(project);
      if(result == null)
      {
        throw new InvalidOperationException("Failed to create the project.");
      }
      return _mapper.Map<ProjectDto>(result);
    }
    catch (Exception ex)
    {
      // Log the exception (not implemented here)
      throw new InvalidOperationException("An error occurred while creating the project.", ex);
    }
  }

  public Task<int> DeleteProjectAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<List<ProjectDto>> GetAllProjectsAsync()
  {
    throw new NotImplementedException();
  }

  public Task<ProjectDto> GetProjectByIdAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<ProjectDto> UpdateProjectAsync(UpdateProjectDto updateProjectDto)
  {
    throw new NotImplementedException();
  }
}
