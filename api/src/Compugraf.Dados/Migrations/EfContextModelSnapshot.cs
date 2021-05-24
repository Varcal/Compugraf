﻿// <auto-generated />
using Compugraf.Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Compugraf.Dados.Migrations
{
    [DbContext(typeof(EfContext))]
    partial class EfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Compugraf.Dominio.Entidade.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nacionalidade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("Compugraf.Dominio.Entidade.Pessoa", b =>
                {
                    b.OwnsOne("Compugraf.Dominio.ObjetoDeValor.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<int>("PessoaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("char(11)")
                                .HasColumnName("Cpf");

                            b1.HasKey("PessoaId");

                            b1.HasIndex("Numero")
                                .IsUnique()
                                .HasFilter("[Cpf] IS NOT NULL");

                            b1.ToTable("Pessoa");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.OwnsOne("Compugraf.Dominio.ObjetoDeValor.Email", "Email", b1 =>
                        {
                            b1.Property<int>("PessoaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar(255)")
                                .HasColumnName("Email");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoa");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.OwnsOne("Compugraf.Dominio.ObjetoDeValor.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("PessoaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("char(8)")
                                .HasColumnName("Cep");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Estado")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Estado");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Logradouro");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoa");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.OwnsOne("Compugraf.Dominio.ObjetoDeValor.NomeCompleto", "NomeCompleto", b1 =>
                        {
                            b1.Property<int>("PessoaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Nome")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Nome");

                            b1.Property<string>("Sobrenome")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Sobrenome");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoa");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.OwnsOne("Compugraf.Dominio.ObjetoDeValor.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<int>("PessoaId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("char(11)")
                                .HasColumnName("Telefone");

                            b1.HasKey("PessoaId");

                            b1.ToTable("Pessoa");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.Navigation("Cpf");

                    b.Navigation("Email");

                    b.Navigation("Endereco");

                    b.Navigation("NomeCompleto");

                    b.Navigation("Telefone");
                });
#pragma warning restore 612, 618
        }
    }
}
