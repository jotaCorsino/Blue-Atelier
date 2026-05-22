using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueAtelier.Infrastructure.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaminhosConfigurados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 160, nullable: false),
                    Caminho = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    EstaAtivo = table.Column<bool>(type: "INTEGER", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaminhosConfigurados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colecoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "TEXT", maxLength: 220, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    ImagemCapa = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    CriadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    EstaArquivada = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracoesApp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Chave = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Valor = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracoesApp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelosPastas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 160, nullable: false),
                    Estrutura = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelosPastas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PastasFavoritos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 160, nullable: false),
                    TomVisual = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    Ordem = table.Column<int>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastasFavoritos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosBackup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Caminho = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    TamanhoBytes = table.Column<long>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosBackup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ColecaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "TEXT", maxLength: 220, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    EtapaAtual = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    ProgressoPercentual = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoArquivo = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    Escala = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    TempoEstimado = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    MaterialSugerido = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Observacoes = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    CriadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Colecoes_ColecaoId",
                        column: x => x.ColecaoId,
                        principalTable: "Colecoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinksFavoritos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PastaFavoritosId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Iniciais = table.Column<string>(type: "TEXT", maxLength: 8, nullable: true),
                    TomVisual = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    Ordem = table.Column<int>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinksFavoritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinksFavoritos_PastasFavoritos_PastaFavoritosId",
                        column: x => x.PastaFavoritosId,
                        principalTable: "PastasFavoritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ArquivosVinculados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModeloId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 260, nullable: false),
                    CaminhoLocal = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Extensao = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    TamanhoBytes = table.Column<long>(type: "INTEGER", nullable: true),
                    CriadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivosVinculados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArquivosVinculados_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagensDoModelo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModeloId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CaminhoLocal = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Ordem = table.Column<int>(type: "INTEGER", nullable: false),
                    EhPrincipal = table.Column<bool>(type: "INTEGER", nullable: false),
                    Observacao = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    CriadoEm = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensDoModelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagensDoModelo_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArquivosVinculados_ModeloId_Nome",
                table: "ArquivosVinculados",
                columns: new[] { "ModeloId", "Nome" });

            migrationBuilder.CreateIndex(
                name: "IX_CaminhosConfigurados_Nome",
                table: "CaminhosConfigurados",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_CaminhosConfigurados_Tipo",
                table: "CaminhosConfigurados",
                column: "Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_Colecoes_Nome",
                table: "Colecoes",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Colecoes_Slug",
                table: "Colecoes",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracoesApp_Chave",
                table: "ConfiguracoesApp",
                column: "Chave",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImagensDoModelo_ModeloId_Ordem",
                table: "ImagensDoModelo",
                columns: new[] { "ModeloId", "Ordem" });

            migrationBuilder.CreateIndex(
                name: "IX_LinksFavoritos_Nome",
                table: "LinksFavoritos",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_LinksFavoritos_PastaFavoritosId_Ordem",
                table: "LinksFavoritos",
                columns: new[] { "PastaFavoritosId", "Ordem" });

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_ColecaoId_Slug",
                table: "Modelos",
                columns: new[] { "ColecaoId", "Slug" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_Nome",
                table: "Modelos",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_ModelosPastas_Nome",
                table: "ModelosPastas",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_PastasFavoritos_Nome",
                table: "PastasFavoritos",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_PastasFavoritos_Ordem",
                table: "PastasFavoritos",
                column: "Ordem");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosBackup_CriadoEm",
                table: "RegistrosBackup",
                column: "CriadoEm");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosBackup_Status",
                table: "RegistrosBackup",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArquivosVinculados");

            migrationBuilder.DropTable(
                name: "CaminhosConfigurados");

            migrationBuilder.DropTable(
                name: "ConfiguracoesApp");

            migrationBuilder.DropTable(
                name: "ImagensDoModelo");

            migrationBuilder.DropTable(
                name: "LinksFavoritos");

            migrationBuilder.DropTable(
                name: "ModelosPastas");

            migrationBuilder.DropTable(
                name: "RegistrosBackup");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "PastasFavoritos");

            migrationBuilder.DropTable(
                name: "Colecoes");
        }
    }
}
