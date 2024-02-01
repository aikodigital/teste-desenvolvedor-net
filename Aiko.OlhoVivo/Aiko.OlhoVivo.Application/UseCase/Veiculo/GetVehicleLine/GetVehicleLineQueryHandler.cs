using Aiko.OlhoVivo.Application.Models;
using Aiko.OlhoVivo.Application.UseCase.Veiculo.GetVehicle;
using Aiko.OlhoVivo.Domain.Interfaces.Repository;
using Aiko.OlhoVivo.Infrastructure.Useful;
using AutoMapper;
using MediatR;

namespace Aiko.OlhoVivo.Application.UseCase.Veiculo.GetVehicleLine;

/// <summary>
/// Handler responsável por listar uma ou mais veículos castrados e ativos por linha.
/// </summary>
public class GetVehicleLineQueryHandler : IRequestHandler<GetVehicleLineQuery, Result<IEnumerable<VehicleModel>>>
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehicleLineQueryHandler(IMapper mapper, IVehicleRepository vehicleRepository)
    {
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Result<IEnumerable<VehicleModel>>> Handle(GetVehicleLineQuery query, CancellationToken cancellationToken)
    {
        var vehicle = _mapper.Map<IEnumerable<VehicleModel>>
            (await _vehicleRepository.ListAsyncVehicleLine(query.Id));

        return new()
        {
            Retorno = vehicle,
            Sucesso = vehicle.Any()
        };
    }
}