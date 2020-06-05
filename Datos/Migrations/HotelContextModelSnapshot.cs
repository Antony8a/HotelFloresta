﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Cliente", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identificacion");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Entity.Compra", b =>
                {
                    b.Property<string>("IdCompra")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CantidadProductos")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalCompra")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCompra");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Entity.Factura", b =>
                {
                    b.Property<string>("IdFactura")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdReserva")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdFactura");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Entity.Habitacion", b =>
                {
                    b.Property<string>("IdHabitacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Aire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Disponibilidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ventilador")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHabitacion");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("Entity.Inventario", b =>
                {
                    b.Property<string>("IdInventario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("IdInventario");

                    b.ToTable("Inventarios");
                });

            modelBuilder.Entity("Entity.Producto", b =>
                {
                    b.Property<string>("IdProducto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Entity.Recepcionista", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Identificacion");

                    b.ToTable("Recepcionistas");
                });

            modelBuilder.Entity("Entity.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CantidadPersonas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdHabitacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdReserva");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Entity.Users", b =>
                {
                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Usuario");

                    b.ToTable("Userss");
                });
#pragma warning restore 612, 618
        }
    }
}
