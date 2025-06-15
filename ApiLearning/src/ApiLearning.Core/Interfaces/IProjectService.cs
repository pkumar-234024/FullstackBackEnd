using ApiLearning.Core.ProjectAggregate;

namespace ApiLearning.Core.Interfaces;
public interface IProjectService
{
  Task<ProjectDto> CreateProjectAsync(CreateProjectDto createProjectDto);

  Task<ProjectDto> UpdateProjectAsync(UpdateProjectDto updateProjectDto);

  Task<ProjectDto> GetProjectByIdAsync(int id);

  Task<List<ProjectDto>> GetAllProjectsAsync();

  Task<int> DeleteProjectAsync(int id);
}
