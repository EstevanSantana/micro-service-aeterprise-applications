﻿using NSE.Core.DomainObjects;
using System;

namespace NSE.Cliente.API.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Guid ClientesId { get; private set; }

        // EF Relation
        public Clientes Clientes { get; protected set; }

        // EF Constructor
        protected Endereco() { }

        public Endereco(string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, Guid clienteId)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            ClientesId = clienteId;
        }
    }
}
