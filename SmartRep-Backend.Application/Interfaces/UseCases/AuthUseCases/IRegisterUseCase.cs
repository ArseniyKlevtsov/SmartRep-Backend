using SmartRep_Backend.Application.Dtos.AuthDtos.Requests;
using SmartRep_Backend.Application.Dtos.AuthDtos.Responses;

namespace SmartRep_Backend.Application.Interfaces.UseCases.AuthUseCases;
public interface IRegisterUseCase
{
    Task<RegisterResonseDto> ExecuteAsync(RegisterRequestDto registerRequestDto);
}
