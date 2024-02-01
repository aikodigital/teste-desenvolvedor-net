using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.PositionVehicle.GetPositionVehicle;

/// <summary>
/// Handler responsável por listar uma ou mais posições veículares castradas e ativas.
/// </summary>
public class GetVehiclePositionQueryHandler : IRequestHandler<GetVehiclePositionQuery, Result<IEnumerable<VehiclePositionModel>>>
{
    private readonly IMapper _mapper;
    private readonly IPositionVehicleRepository _positionVehicleRepository;

    public GetVehiclePositionQueryHandler(IMapper mapper, IPositionVehicleRepository positionVehicleRepository)
    {
        _mapper = mapper;
        _positionVehicleRepository = positionVehicleRepository;
    }

    public async Task<Result<IEnumerable<VehiclePositionModel>>> Handle(GetVehiclePositionQuery query, CancellationToken cancellationToken)
    {
        var vehiclePosition = _mapper.Map<IEnumerable<VehiclePositionModel>>
            (await _positionVehicleRepository.ListAsync(query.Id));

        return new()
        {
            Retorno = vehiclePosition,
            Sucesso = vehiclePosition.Any()
        };
    }
}