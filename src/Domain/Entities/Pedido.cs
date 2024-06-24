﻿using System;

namespace workerOnBording.Domain.Entities;

public class TransaccionPedido
{
    public Guid Id { get; set; }
    public int? NumeroDePedido { get; set; }
    public string CicloDelPedido { get; set; }
    public int CodigoDeContratoInterno { get; set; }
    public string EstadoDelPedido { get; set; }
    public int CuentaCorriente { get; set; }
    public DateTime Cuando { get; set; }
}