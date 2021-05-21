using Compugraf.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Compugraf.Dados.Mapeamentos
{
    public class PessoaMap: IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable(nameof(Pessoa));

            builder.HasKey(x => x.Id);


            builder.OwnsOne(x => x.NomeCompleto, x =>
            {
                x.Property(x => x.Nome)
                    .HasColumnName("Nome")
                    .HasColumnType("varchar")
                    .HasMaxLength(100)
                    .IsRequired();
                x.Property(x => x.Sobrenome)
                    .HasColumnName("Sobrenome")
                    .HasColumnType("varchar")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            
            builder.OwnsOne(x => x.Cpf, x =>
            {
                x.HasIndex(x => x.Numero).IsUnique();

                x.Property(x => x.Numero)
                    .HasColumnName("Cpf")
                    .HasColumnType("char")
                    .HasMaxLength(11)
                    .IsRequired();
            });
            
            builder.OwnsOne(x => x.Email)
                .Property(x => x.Endereco)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.OwnsOne(x => x.Telefone)
                .Property(x => x.Numero)
                .HasColumnName("Telefone")
                .HasColumnType("char")
                .HasMaxLength(11)
                .IsRequired();

            builder.OwnsOne(x => x.Endereco, x =>
            {
                x.Property(x => x.Cep)
                    .HasColumnName("Cep")
                    .HasColumnType("char")
                    .HasMaxLength(8)
                    .IsRequired();
                x.Property(x => x.Cidade)
                    .HasColumnName("Cidade")
                    .HasColumnType("varchar")
                    .HasMaxLength(100)
                    .IsRequired();
                x.Property(x => x.Estado)
                    .HasColumnName("Estado")
                    .HasColumnType("varchar")
                    .HasMaxLength(100)
                    .IsRequired();
                x.Property(x => x.Logradouro)
                    .HasColumnName("Logradouro")
                    .HasColumnType("varchar")
                    .HasMaxLength(200)
                    .IsRequired();
            });
        }
    }
}
