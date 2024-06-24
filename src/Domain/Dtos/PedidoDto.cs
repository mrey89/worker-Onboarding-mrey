using System;

namespace workerOnBording.Domain.Dtos;

public record struct PedidoDto(Guid Id, int NumeroDePedido, string CicloDelPedido, int CodigoDeContratoInterno, string EstadoDelPedido, int CuentaCorriente, DateTime Cuando) { }

