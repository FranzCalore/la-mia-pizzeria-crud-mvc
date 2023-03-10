// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using la_mia_pizzeria.Database;

#nullable disable

namespace lamiapizzeria.Migrations
{
    [DbContext(typeof(PizzeriaContext))]
    [Migration("20230119101832_ManyToManyAndCry4")]
    partial class ManyToManyAndCry4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CondimentoExtraPizza", b =>
                {
                    b.Property<int>("CondimentiExtraCondimentoId")
                        .HasColumnType("int");

                    b.Property<int>("PizzeConditeId")
                        .HasColumnType("int");

                    b.HasKey("CondimentiExtraCondimentoId", "PizzeConditeId");

                    b.HasIndex("PizzeConditeId");

                    b.ToTable("CondimentoExtraPizza");
                });

            modelBuilder.Entity("la_mia_pizzeria.Models.Categoria", b =>
                {
                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Nome");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("la_mia_pizzeria.Models.CondimentoExtra", b =>
                {
                    b.Property<int>("CondimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CondimentoId"));

                    b.Property<string>("Condimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrezzoCondimento")
                        .HasColumnType("float");

                    b.HasKey("CondimentoId");

                    b.ToTable("CondimentiExtra");
                });

            modelBuilder.Entity("la_mia_pizzeria.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Immagine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaNome");

                    b.ToTable("Pizze");
                });

            modelBuilder.Entity("CondimentoExtraPizza", b =>
                {
                    b.HasOne("la_mia_pizzeria.Models.CondimentoExtra", null)
                        .WithMany()
                        .HasForeignKey("CondimentiExtraCondimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("la_mia_pizzeria.Models.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzeConditeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("la_mia_pizzeria.Models.Pizza", b =>
                {
                    b.HasOne("la_mia_pizzeria.Models.Categoria", "Categoria")
                        .WithMany("ListaProdotti")
                        .HasForeignKey("CategoriaNome")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("la_mia_pizzeria.Models.Categoria", b =>
                {
                    b.Navigation("ListaProdotti");
                });
#pragma warning restore 612, 618
        }
    }
}
