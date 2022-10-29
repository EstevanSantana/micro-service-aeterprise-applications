﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Cliente.API.Models;
using NSE.Core.DomainObjects;

namespace NSE.Cliente.API.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(c => c.Cpf, tf =>
            {
                tf.Property(c => c.Numero)
                    .IsRequired()
                    .HasMaxLength(Cpf.CPFMAXLENGTH)
                    .HasColumnName("Cpf")
                    .HasColumnType($"varchar({Cpf.CPFMAXLENGTH})");
            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.ENDERECOMAXLENGTH})");
            });

            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Clientes);

            builder.ToTable("Clientes");
        }
    }
}
