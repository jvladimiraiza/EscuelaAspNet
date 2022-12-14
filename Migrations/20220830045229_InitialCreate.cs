using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspNet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Escuelas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnioCreacion = table.Column<int>(type: "int", nullable: false),
                    Pais = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dirección = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoEscuela = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuelas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Jornada = table.Column<int>(type: "int", nullable: false),
                    Dirección = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EscuelaId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Escuelas_EscuelaId",
                        column: x => x.EscuelaId,
                        principalTable: "Escuelas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CursoId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumnos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CursoId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlumnoId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AsignaturaId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nota = table.Column<float>(type: "float", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Asignaturas_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalTable: "Asignaturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "Id", "CursoId", "Nombre" },
                values: new object[,]
                {
                    { "002cc428-2822-4014-b474-b1819c3fecc8", null, "Alvaro Nicomedes Ruiz" },
                    { "00c129ec-e105-49cf-a1c1-a7005ed9d836", null, "Alvaro Anabel Maduro" },
                    { "0114c2e4-6f03-4cb7-9983-9b67a7fb98a2", null, "Eusebio Nicomedes Herrera" },
                    { "0144d26b-927d-4ca2-80b2-54758e69c324", null, "Farid Silvana Herrera" },
                    { "0153c8f8-76f8-4b38-92de-14006d3473a8", null, "Farid Silvana Uribe" },
                    { "0247fa99-7472-43f8-b243-93627e4db6aa", null, "Nicolás Rick Ruiz" },
                    { "03dab6de-3131-4428-a672-573019351d27", null, "Donald Rick Herrera" },
                    { "05338187-f292-48d3-ac58-d25a124b19d8", null, "Felipa Anabel Toledo" },
                    { "07333f4d-fec9-48a2-b422-ecbf4a452d93", null, "Donald Silvana Herrera" },
                    { "0749d615-d5b3-4600-bffb-4beb0665c36d", null, "Farid Murty Herrera" },
                    { "0756dd41-e5ac-4458-af34-4254461630d0", null, "Nicolás Rick Toledo" },
                    { "07c4f5f5-e2d0-4de3-9c27-02dc3dcb0b45", null, "Donald Teodoro Maduro" },
                    { "099c25c5-c110-458a-a3c3-c7511fabce3f", null, "Donald Teodoro Trump" },
                    { "0a2e7781-2f54-464c-b43c-ace8f9301ac6", null, "Eusebio Silvana Herrera" },
                    { "0ad66ea0-374e-409e-8fe2-8f43dcebecde", null, "Donald Teodoro Toledo" },
                    { "0b1addf7-860e-44b3-a4d6-498a697c570f", null, "Eusebio Rick Sarmiento" },
                    { "0b745d78-ae50-43d0-b46e-6aaba921c5b0", null, "Nicolás Teodoro Toledo" },
                    { "0be9c451-c197-48db-ab25-9f81a1851999", null, "Eusebio Diomedes Herrera" },
                    { "0c9d5e5d-3edb-47d1-ae41-54701fbe2097", null, "Nicolás Diomedes Maduro" },
                    { "0cb813f3-deb9-4e6c-a95f-56f3368688e5", null, "Alvaro Silvana Trump" },
                    { "0f2633ae-be23-4e76-b12c-0192f98c655c", null, "Nicolás Teodoro Trump" },
                    { "0f427977-abab-43cd-9f46-27a5ca1c4980", null, "Eusebio Teodoro Ruiz" },
                    { "0f5a2d9c-83de-4cdb-b5c4-f3bf55624746", null, "Nicolás Teodoro Maduro" },
                    { "103c30c4-3d01-46ac-9678-a8a4faf9245c", null, "Donald Rick Maduro" },
                    { "10eda9b1-c13e-4dda-9b4d-c5e6d4d88339", null, "Felipa Anabel Ruiz" },
                    { "119f6dd0-5814-4bdb-bb2c-4cb0b249d7e7", null, "Farid Anabel Sarmiento" },
                    { "11f824f1-032d-4ca7-ad18-097f7e71f536", null, "Felipa Silvana Ruiz" },
                    { "12b1704d-1ad1-4249-a0d5-9956fee5fa6b", null, "Alvaro Anabel Ruiz" },
                    { "13854e78-6648-4178-abab-d06b141455ec", null, "Felipa Diomedes Herrera" },
                    { "13c4a71f-0604-4fd6-99a9-42f416a6cf7e", null, "Farid Diomedes Ruiz" },
                    { "14c427b1-97ac-4275-a6d4-4d58d3ea57a2", null, "Nicolás Anabel Ruiz" },
                    { "15428c19-8a4f-4fca-8e46-5966b93f5b33", null, "Felipa Anabel Uribe" },
                    { "166baaab-8a36-4016-9fdf-188f2d7ea563", null, "Nicolás Diomedes Sarmiento" },
                    { "1727e0fe-8d7d-4659-ad41-772036c804f0", null, "Eusebio Diomedes Toledo" },
                    { "180af402-aadf-47dc-b282-cac164270ea7", null, "Nicolás Silvana Sarmiento" },
                    { "1a1bec97-f68e-48a2-bb7f-6a4dcb148969", null, "Donald Diomedes Maduro" },
                    { "1a720fbb-018a-413a-afa4-4a747af35acd", null, "Alvaro Teodoro Ruiz" },
                    { "1af239fe-0210-492a-b1f1-1cbe9826d902", null, "Donald Nicomedes Ruiz" },
                    { "1bd7e2b6-91cd-4845-825a-c430a6aea561", null, "Eusebio Anabel Sarmiento" },
                    { "1c5952b7-79d4-482d-a7b9-1101bc3467bd", null, "Farid Diomedes Trump" },
                    { "1d093437-e808-495e-b5f6-8cf6eb4d48b4", null, "Donald Rick Toledo" },
                    { "1d1b4743-1297-4888-8612-aa90e972c1a2", null, "Alvaro Anabel Sarmiento" },
                    { "1d320692-13d5-4ace-9bdc-23e85082d61e", null, "Eusebio Diomedes Ruiz" },
                    { "1f1135a6-d788-4508-b8af-5d66031e9683", null, "Farid Nicomedes Toledo" },
                    { "1f6fd42d-7a23-4933-b148-19b4ca302b57", null, "Nicolás Anabel Herrera" },
                    { "2161ad7f-8d15-4c95-8c91-2d4646d3f910", null, "Donald Nicomedes Uribe" },
                    { "216e478e-952e-47c7-b8ab-712a47ec0554", null, "Felipa Diomedes Sarmiento" },
                    { "21ac1ff8-3b76-4928-b6f1-8f44a40bfac0", null, "Alba Teodoro Ruiz" },
                    { "21f2cfbe-6a79-46e6-9d96-652b02c61c7d", null, "Felipa Rick Trump" },
                    { "225bef9d-65e9-4d88-bd9b-2db54e3dffd6", null, "Eusebio Freddy Herrera" },
                    { "230d60cc-4679-4c07-8ecb-5b7ac291502d", null, "Farid Freddy Uribe" },
                    { "248944b9-8af8-4690-a43e-e0138ad1ec26", null, "Alvaro Rick Sarmiento" },
                    { "24a12e92-c567-4aed-aa57-60468f2d3fa8", null, "Nicolás Murty Uribe" },
                    { "2639a9f3-1ac4-4d37-aea8-85ab3dcb0540", null, "Felipa Teodoro Maduro" },
                    { "2675566b-da42-4c89-a1ec-d341ce3c3933", null, "Felipa Nicomedes Ruiz" },
                    { "2804b41a-56c9-4dde-b11b-6b726ea48972", null, "Donald Anabel Toledo" },
                    { "296629e7-6de5-4f59-9636-fab4569062e0", null, "Alvaro Freddy Uribe" },
                    { "2a2820d7-d248-4f41-b836-e9106726798a", null, "Alba Nicomedes Herrera" },
                    { "2ad33b3d-2f5f-428b-b37d-7ed9e1054fdb", null, "Alvaro Diomedes Ruiz" },
                    { "2ae5f36f-daad-4c3d-8ae0-dd8321382d2a", null, "Farid Rick Uribe" },
                    { "2c03ab9e-91bc-4a86-b831-60b8dd1a94f7", null, "Felipa Nicomedes Trump" },
                    { "2c2f6fc9-4037-439d-be42-84bc65071b60", null, "Alba Nicomedes Toledo" },
                    { "2c4abe1e-d5f8-4c35-be9a-8ed16247dab4", null, "Eusebio Murty Sarmiento" },
                    { "2c6245fd-b9e9-4558-86e1-e50f3a539664", null, "Alba Murty Ruiz" },
                    { "2d7b08f1-cb90-4be1-be40-c6b27b0a5d3a", null, "Alba Rick Maduro" },
                    { "2dde50da-d8ad-4e74-b8ff-5631c12e5b5f", null, "Farid Diomedes Sarmiento" },
                    { "2e4c7b48-1856-4c32-997f-13b5eca34439", null, "Alvaro Anabel Uribe" },
                    { "2ec9d348-33e7-4a37-8b31-88118e104fb4", null, "Nicolás Anabel Uribe" },
                    { "2f776943-5cdf-4d37-b229-1cb860471ccb", null, "Eusebio Nicomedes Toledo" },
                    { "2fcc2c09-9ac9-43ff-8518-6f8e6359daae", null, "Alba Nicomedes Trump" },
                    { "3017555d-39c3-47c7-828a-12f25ac2feee", null, "Felipa Silvana Herrera" },
                    { "3054b8ee-257b-4e29-8e5d-7f9128006c78", null, "Felipa Freddy Toledo" },
                    { "309dcf97-8ef0-47ac-8d30-652c1004c9c0", null, "Donald Diomedes Ruiz" },
                    { "31495ae1-7696-4024-83e4-c356d60401b2", null, "Donald Silvana Ruiz" },
                    { "31cba438-ac4e-4627-b05c-76a5501e35d5", null, "Donald Anabel Uribe" },
                    { "3200a5bc-0271-4ec2-aa99-26447dde43bc", null, "Alba Silvana Toledo" },
                    { "32189f42-3541-4136-8195-49264c666f77", null, "Eusebio Rick Maduro" },
                    { "33512144-16ea-4dbb-9397-57f1bd11921a", null, "Alba Rick Sarmiento" },
                    { "336ecda1-115c-4eb5-a9a2-3d35209bc691", null, "Felipa Nicomedes Toledo" },
                    { "34cf8cf1-a96a-43b2-a7d3-df09f8974b2e", null, "Nicolás Silvana Trump" },
                    { "3597c0bb-acb9-4768-8fcc-8ca28e890fb4", null, "Eusebio Rick Toledo" },
                    { "35fd03af-6433-4827-bc9c-56f0533fc85f", null, "Nicolás Anabel Toledo" },
                    { "37404462-2bc9-44d1-917f-2a47c22e4090", null, "Nicolás Murty Toledo" },
                    { "38e96a3b-3b6e-4999-b524-de82d807b9e2", null, "Alvaro Teodoro Toledo" },
                    { "39db0fbd-feda-4ea4-bdda-fe8c3243e223", null, "Alvaro Teodoro Maduro" },
                    { "3a50cc4b-e486-4d3b-9477-9727a4bf7875", null, "Alba Nicomedes Uribe" },
                    { "3c1a9b04-44fd-44c2-a0a8-b3ba1f449983", null, "Nicolás Silvana Ruiz" },
                    { "3d496379-1e05-4239-92a5-4411ca92fb3d", null, "Felipa Teodoro Toledo" },
                    { "3dbc8f50-ccb0-4d13-88cd-56f446d130f8", null, "Eusebio Anabel Toledo" },
                    { "3eab0d45-a195-4b62-8460-6d4a97c88609", null, "Alvaro Anabel Toledo" },
                    { "42cbb9a7-8b98-47a2-ac51-fbcd713b060b", null, "Nicolás Nicomedes Trump" },
                    { "43bd18ac-68c5-49d5-9da6-087ee4f53543", null, "Alba Teodoro Maduro" },
                    { "443f5648-a30b-4107-a1a6-fec3066802a8", null, "Alvaro Anabel Herrera" },
                    { "444cb612-1219-486a-a7a0-32cd5ec7b8ae", null, "Nicolás Murty Ruiz" },
                    { "4468b48a-9c8e-42fa-9583-722ca33f5928", null, "Alba Anabel Sarmiento" },
                    { "449d5902-f70d-4227-9ca5-f494e4f5fa9f", null, "Donald Silvana Trump" },
                    { "44c7e47b-11e5-4242-9216-e34cfb9df2cd", null, "Nicolás Nicomedes Maduro" },
                    { "460dedf3-cae0-432c-b226-c2536ea4bb80", null, "Eusebio Murty Herrera" },
                    { "4646f247-ade5-4e9d-ac90-6032b7b5fcbd", null, "Farid Rick Toledo" },
                    { "466187fb-2b1d-4dfa-aeed-6c89f41cac1e", null, "Alba Anabel Uribe" },
                    { "4863e991-db8c-4a3c-8a54-9a9431e87def", null, "Farid Murty Ruiz" },
                    { "4869f347-5d83-404b-9ee6-58e3d7e1603c", null, "Nicolás Teodoro Herrera" },
                    { "491e5285-bd98-4e47-b0f2-02b77b6f7d6e", null, "Eusebio Nicomedes Maduro" },
                    { "49d39de4-41fd-4f68-9951-36a6a6d7d5ed", null, "Alba Nicomedes Ruiz" },
                    { "4bb50756-dd8f-4f47-b292-2fa3a5d4a872", null, "Alvaro Diomedes Uribe" },
                    { "4bd81bab-ce09-492d-80bd-945f92807b00", null, "Alba Diomedes Maduro" },
                    { "4e22c191-57e8-4c97-9cce-40b83c4c4eea", null, "Nicolás Diomedes Herrera" },
                    { "4ec9477b-1459-4c43-9cd6-b8dc651789a4", null, "Alvaro Teodoro Trump" },
                    { "4ef8b3ac-44e9-4020-83c7-5e9a110717fb", null, "Farid Teodoro Sarmiento" },
                    { "4f4a05a9-49d2-42c2-8a78-9f92a85b1a70", null, "Nicolás Nicomedes Sarmiento" },
                    { "5091b4da-32a1-48aa-a9f1-cfe903847b20", null, "Donald Rick Sarmiento" },
                    { "50bfa99f-abc7-4488-9d0c-00dce54fd165", null, "Alvaro Murty Uribe" },
                    { "50fd05cf-1c3f-48b0-bd32-9a9cfc4f17a0", null, "Eusebio Anabel Trump" },
                    { "5101e0c3-2fea-4770-9564-d96ae3651a41", null, "Donald Diomedes Uribe" },
                    { "5143fa42-89da-48d1-a9bb-2da8ab69f107", null, "Farid Freddy Herrera" },
                    { "516f98da-e172-4ea8-84e0-d1b666c94892", null, "Alba Freddy Trump" },
                    { "518f8e29-05dc-4de9-85ef-2b6bd8a1a920", null, "Farid Silvana Trump" },
                    { "526839a3-3e1c-42b9-ad28-dd642eea2cd3", null, "Donald Silvana Sarmiento" },
                    { "52aa6d54-0e80-422b-9b87-9ea5cd2a3c3e", null, "Alba Freddy Ruiz" },
                    { "54240d58-e936-4738-9c2f-34d0429add9f", null, "Farid Freddy Sarmiento" },
                    { "54d0927f-18ba-45b9-9c4e-08c861fe70d5", null, "Farid Rick Maduro" },
                    { "55035a71-d71f-4459-831d-07e5c5682738", null, "Alba Silvana Uribe" },
                    { "5575c566-47f4-4d19-b2f3-395f34f40e27", null, "Alvaro Diomedes Trump" },
                    { "5650fd35-d9e7-40e7-aff2-fda05013fa3f", null, "Farid Murty Maduro" },
                    { "5663a935-a660-4f62-9944-cbc60e05c46a", null, "Eusebio Freddy Toledo" },
                    { "58b8f494-4a68-40b2-9f88-60d35aa455f0", null, "Farid Teodoro Herrera" },
                    { "5b7b7b4c-9d8f-47d6-8b86-952e05360517", null, "Nicolás Nicomedes Ruiz" },
                    { "5be4ee14-525a-49c5-8e1f-166db399f2a7", null, "Alvaro Freddy Ruiz" },
                    { "5c1d7c04-e798-4617-91d9-01b2fdc4ab9d", null, "Farid Murty Trump" },
                    { "5c859352-76c7-478d-bad1-13d8002fe08f", null, "Nicolás Freddy Ruiz" },
                    { "5c8cffe4-7aa3-4c29-a872-a13266b4e405", null, "Farid Teodoro Ruiz" },
                    { "5ce23c00-59b9-474a-9836-12195a98157e", null, "Felipa Silvana Trump" },
                    { "5d18f0f7-cf1f-44ac-aae5-96629d6d29d7", null, "Farid Silvana Toledo" },
                    { "5d28dd78-8126-4bc7-9f25-fe1cffe78992", null, "Alvaro Freddy Sarmiento" },
                    { "5f1fbfd4-5090-4a3b-a115-0c7f87cb5610", null, "Nicolás Rick Trump" },
                    { "5f32cd73-bead-4b7a-8e94-590b900d92a1", null, "Donald Freddy Herrera" },
                    { "60ad5f36-ba90-4012-a261-703313c51b0b", null, "Eusebio Freddy Uribe" },
                    { "6172eb96-4f59-46c7-b347-80540eda3be3", null, "Donald Anabel Maduro" },
                    { "617be189-54cb-41f9-91a5-78b8cc628607", null, "Nicolás Nicomedes Toledo" },
                    { "628c530d-2f9e-44e0-a012-b494e02cda12", null, "Alvaro Teodoro Uribe" },
                    { "641f326f-f1df-4b53-ab28-b81d04571ff9", null, "Eusebio Diomedes Maduro" },
                    { "64302701-1e60-439c-a0ff-93af9f78877e", null, "Felipa Freddy Uribe" },
                    { "64b57161-6db0-45cd-ab0b-fc0aee1002ff", null, "Eusebio Nicomedes Uribe" },
                    { "65084cf0-ee2f-49a3-b83b-2b3332a6c4f2", null, "Farid Diomedes Toledo" },
                    { "65d5707b-030b-458a-8c62-d5afac855e6d", null, "Felipa Silvana Toledo" },
                    { "67141c65-9ed9-48ac-bbb1-b161910303b6", null, "Donald Nicomedes Sarmiento" },
                    { "67719480-53b5-4707-a720-45c0c3a9698e", null, "Alba Murty Uribe" },
                    { "68787136-3066-4693-9feb-5b11e676e8a6", null, "Eusebio Nicomedes Ruiz" },
                    { "69a7b835-82dd-47f8-9564-a1c387e63148", null, "Farid Rick Trump" },
                    { "69c656bb-7c52-47db-9832-b013be0b6662", null, "Farid Silvana Sarmiento" },
                    { "69c6e85d-0191-4045-9686-b47b9e20ca07", null, "Alba Rick Uribe" },
                    { "6a101a50-b468-4f48-a935-863b1ca231a9", null, "Donald Rick Uribe" },
                    { "6a8a3186-9ee1-46e4-8805-66f2957dddf4", null, "Felipa Rick Herrera" },
                    { "6accbff0-549c-4b34-991e-521c0cd66d96", null, "Nicolás Teodoro Sarmiento" },
                    { "6afd584c-2970-43da-b565-5c2ee1b72308", null, "Felipa Silvana Sarmiento" },
                    { "6b0b676a-24f2-49d0-be97-dc4639fe706a", null, "Alba Anabel Herrera" },
                    { "6c13dca5-e802-4dd1-a78c-28cc1e15f53f", null, "Donald Murty Ruiz" },
                    { "6c50458b-2ee4-4df9-be16-ea454845a54f", null, "Donald Freddy Uribe" },
                    { "6f516dd6-02b1-4909-81f1-6f1e0a010ab7", null, "Nicolás Silvana Herrera" },
                    { "6fcf342c-840f-457d-8b29-c8d7b09b9b69", null, "Alba Murty Trump" },
                    { "7004a5ec-979f-4c2e-a5b5-c62bb3de7675", null, "Alvaro Rick Toledo" },
                    { "70f13387-1d5c-4aea-8940-8f0f84ae2cb5", null, "Alvaro Freddy Toledo" },
                    { "71ae5c25-1215-4617-879b-2d68df67d1b6", null, "Farid Diomedes Uribe" },
                    { "71f01903-fd28-43cd-8121-07a175876e9d", null, "Alba Freddy Herrera" },
                    { "721aa471-21fc-4a18-b6ac-219dfb4faa17", null, "Eusebio Silvana Maduro" },
                    { "721eb9b6-d3f9-4728-be7c-44083dbcb856", null, "Alvaro Rick Uribe" },
                    { "723e3c91-2b46-4bad-9114-911eb64afc97", null, "Alba Freddy Maduro" },
                    { "72d271be-7e2a-49d1-83ec-926f0d99aef2", null, "Alba Anabel Trump" },
                    { "72e0d0a3-0304-4b58-9745-f268cd1ac15a", null, "Alvaro Murty Sarmiento" },
                    { "7341af54-46aa-4029-a16e-5e2d5a693a0f", null, "Nicolás Teodoro Uribe" },
                    { "7346ca12-e8c4-41f3-a359-80ac729e6e56", null, "Alvaro Nicomedes Uribe" },
                    { "73500f57-2f06-48ef-bfbb-614bdf9e4005", null, "Alba Teodoro Toledo" },
                    { "73dfb76a-b9cc-4ab1-b0ff-df69d0158d7e", null, "Eusebio Diomedes Uribe" },
                    { "74d49ac6-1525-4933-8d67-58eec86c919e", null, "Alba Diomedes Ruiz" },
                    { "754a48e2-0912-4076-8eb1-5dfc3bc6d34d", null, "Alvaro Teodoro Herrera" },
                    { "754d3a1c-c8ca-4c2f-80ad-ef39b54a00ad", null, "Eusebio Rick Ruiz" },
                    { "76946e33-76ca-4bd4-b08c-7da6c56fe503", null, "Donald Nicomedes Trump" },
                    { "776b4e01-cfbb-4ca8-95e2-8d68ca791497", null, "Donald Silvana Toledo" },
                    { "78533a26-4ec6-4582-88dd-650cf9c84539", null, "Felipa Rick Sarmiento" },
                    { "79350069-fa9b-4f43-9800-e4158d12d679", null, "Farid Murty Uribe" },
                    { "79c7bbda-894d-4ffa-97a7-f5890ede674e", null, "Farid Freddy Maduro" },
                    { "7b71ab68-0796-4d15-9efa-75c972b28c4d", null, "Eusebio Freddy Maduro" },
                    { "7baf7e91-9ccb-4eb6-8bb2-2cf0c3412b54", null, "Felipa Diomedes Trump" },
                    { "7c3768a4-512d-4949-a7f4-8ccc8db44bfc", null, "Alvaro Murty Ruiz" },
                    { "7c6fe38f-9df4-422f-a3fd-f879f188ba65", null, "Eusebio Teodoro Sarmiento" },
                    { "7c9833b9-6271-42d1-97ec-752130912d66", null, "Farid Teodoro Maduro" },
                    { "7d406e8a-1454-4f9f-b78f-f416e1e18fc6", null, "Donald Diomedes Trump" },
                    { "7dc5e523-39fd-4ebc-8a74-a34bb677b60f", null, "Alvaro Murty Herrera" },
                    { "7f0188c4-7954-42e9-9773-64f0a8088521", null, "Farid Freddy Ruiz" },
                    { "80bfab9a-fcfc-425f-8d0d-a9880c579c43", null, "Farid Murty Toledo" },
                    { "81b1ace7-65e6-409d-8c65-c1f37651c10b", null, "Nicolás Freddy Trump" },
                    { "81e62fc5-847f-4be1-bda4-325248dddb40", null, "Donald Diomedes Herrera" },
                    { "8336c7a8-9bbc-480f-8f8d-cf80d1a4786e", null, "Felipa Diomedes Ruiz" },
                    { "836d9ce7-c10d-4ad9-8f35-c76d1d498f1b", null, "Alba Silvana Herrera" },
                    { "8372f2c7-e01f-4031-be62-9d751566ad35", null, "Felipa Diomedes Toledo" },
                    { "84b87ba5-ae22-4638-af07-7293d4f71646", null, "Eusebio Murty Toledo" },
                    { "85c939df-80c9-47cf-9e06-0055e8d26f5a", null, "Donald Murty Herrera" },
                    { "85d3277a-0173-4531-a278-7793679219a2", null, "Nicolás Rick Herrera" },
                    { "8654de05-9b99-4a59-82ca-400838ae5ae9", null, "Farid Teodoro Toledo" },
                    { "86becddb-9417-4248-8486-6a15a3bbc8f1", null, "Felipa Freddy Herrera" },
                    { "875bfdf1-bc2f-46ee-907f-e7698b689514", null, "Felipa Diomedes Uribe" },
                    { "884bfd52-5662-4544-8d6e-22fd75af410f", null, "Nicolás Diomedes Toledo" },
                    { "886fb413-c97d-4579-bbed-935a44e2eac9", null, "Felipa Rick Uribe" },
                    { "88eba082-02e5-4d8a-a428-53632821a8c7", null, "Felipa Murty Uribe" },
                    { "8916d78f-fa5a-40f4-908e-6538bdaa5477", null, "Felipa Teodoro Herrera" },
                    { "8a357858-8f65-4b28-be25-ffc78bf25f58", null, "Donald Nicomedes Herrera" },
                    { "8a40bc89-4d47-4c2c-a088-1ea660d335fc", null, "Donald Teodoro Uribe" },
                    { "8aaa35fd-6cc5-4cc8-b84a-53b4392fa935", null, "Eusebio Nicomedes Trump" },
                    { "8b915698-e956-4076-90ce-abc6b58aab99", null, "Nicolás Murty Maduro" },
                    { "8be5403e-5065-4aa5-a8d2-423559579b3e", null, "Donald Anabel Herrera" },
                    { "8d0cdd5c-0b30-4757-9be2-6e2e53af77c0", null, "Alvaro Silvana Herrera" },
                    { "8e6755f8-311a-4285-89af-4da374b4d923", null, "Felipa Nicomedes Herrera" },
                    { "8eb71e65-a08d-47ab-bc25-0040f308c2a7", null, "Felipa Anabel Trump" },
                    { "8f1ba844-79c7-4953-b200-0730b40cd7b3", null, "Eusebio Diomedes Trump" },
                    { "8f98783a-328a-454e-90fc-d959fcf095ed", null, "Donald Anabel Ruiz" },
                    { "90e81a30-c3e0-4aa9-a37b-e27115ca2e3f", null, "Alvaro Rick Trump" },
                    { "91e21a40-6781-43f4-a8ac-ec014b2ec46a", null, "Alba Freddy Sarmiento" },
                    { "921297f1-0262-45a2-afe4-2671ca967bfe", null, "Donald Teodoro Ruiz" },
                    { "9250d1e1-1c71-432c-9327-c0407e38a8ab", null, "Felipa Murty Sarmiento" },
                    { "9292e2f8-abb8-4b52-aa1c-1322a99cf879", null, "Donald Teodoro Sarmiento" },
                    { "950cdc12-13b8-4939-ad19-964cae2ec4bc", null, "Farid Teodoro Uribe" },
                    { "9570b4b5-f708-4c28-97e1-0ac9e8873e0c", null, "Felipa Rick Maduro" },
                    { "96144965-8ebf-44f4-ba23-1d2d58771a4a", null, "Alvaro Murty Trump" },
                    { "96814ae7-4684-4180-a771-2d996634d7f4", null, "Farid Anabel Ruiz" },
                    { "9933f624-2b0a-4a14-a752-a256123b109d", null, "Nicolás Nicomedes Herrera" },
                    { "9a76d0a2-d334-4466-8d8e-830d6581119d", null, "Alvaro Nicomedes Sarmiento" },
                    { "9a862ad5-e4bd-401e-89b6-031209ef3675", null, "Alba Teodoro Trump" },
                    { "9af258e2-ef9d-44f2-af5c-e818820bcd4e", null, "Felipa Murty Ruiz" },
                    { "9b32bfa4-f235-4d80-beb9-44a07f0aee63", null, "Farid Silvana Ruiz" },
                    { "9b38782e-34b7-4cbe-8a34-7f22d88c8844", null, "Felipa Nicomedes Uribe" },
                    { "9dd7ccbd-6810-424b-a2f5-97ceec160bca", null, "Eusebio Teodoro Uribe" },
                    { "9e31cfd4-cf5f-442e-9bc4-196c60b3c279", null, "Donald Rick Ruiz" },
                    { "9eaaa6a2-720f-4033-88cf-3126a4aa4b8c", null, "Farid Nicomedes Ruiz" },
                    { "9eb72e10-9ee5-4a19-805e-de43f1af6dc8", null, "Farid Silvana Maduro" },
                    { "9fa265cf-41c2-43d4-9ca1-2ff6ad4e2ad6", null, "Farid Freddy Toledo" },
                    { "a11bfc20-548c-46a2-86f7-06cd73849045", null, "Nicolás Silvana Toledo" },
                    { "a137c179-4f13-4450-b211-10aaa7d97007", null, "Alba Teodoro Uribe" },
                    { "a23af219-e81f-4672-8690-02424374739f", null, "Nicolás Freddy Uribe" },
                    { "a2bf1a70-7917-4b8e-913b-8be1156413f8", null, "Alvaro Silvana Sarmiento" },
                    { "a3ef4a77-593e-4a02-b7e7-bc95674871a2", null, "Donald Murty Toledo" },
                    { "a5888307-ec33-4c37-8ad2-a25c90fabea6", null, "Eusebio Silvana Ruiz" },
                    { "a754f1bd-edc1-4584-8b01-fc530c9b42a5", null, "Donald Freddy Toledo" },
                    { "a762d9ef-992c-4f57-b4c6-8675f86af0d6", null, "Nicolás Diomedes Uribe" },
                    { "a7c46159-1c21-4b51-b1fd-9c90165dbab0", null, "Felipa Nicomedes Sarmiento" },
                    { "a98943cb-6499-4fc8-a9de-eb56ff7b9efa", null, "Felipa Teodoro Ruiz" },
                    { "a98ca720-b4f2-44a9-b41a-9d74c06ffa25", null, "Eusebio Anabel Uribe" },
                    { "aa459b7c-72a3-4089-9a57-476f3a49f8e9", null, "Alvaro Silvana Toledo" },
                    { "ab074ea5-bd85-453d-a91d-320c19c59913", null, "Donald Anabel Sarmiento" },
                    { "abfc5c40-8a25-45dd-9fa6-7f65776b33a2", null, "Alvaro Diomedes Maduro" },
                    { "acc16f1e-0bec-4e0f-980d-16552fd978f2", null, "Eusebio Teodoro Trump" },
                    { "ad5748aa-698f-4790-9bdb-57a01b94406f", null, "Alba Murty Sarmiento" },
                    { "adc08e84-c2da-416e-8744-36d4f647b77f", null, "Alvaro Murty Maduro" },
                    { "ade6123f-5aff-4c91-aea3-778725c320d0", null, "Alvaro Diomedes Herrera" },
                    { "ae7c5e51-2ba8-4953-9485-37ff83572ec4", null, "Felipa Rick Ruiz" },
                    { "aeaa6971-93a4-4d14-885f-d50d7bcb08cd", null, "Nicolás Nicomedes Uribe" },
                    { "aee72652-cc66-4a8c-8120-351371b9b2d8", null, "Alvaro Rick Herrera" },
                    { "af27ec7e-57cc-4547-90ba-dffe942de55d", null, "Eusebio Silvana Sarmiento" },
                    { "b09105c4-d138-4629-8981-98e1ddec0112", null, "Alvaro Silvana Ruiz" },
                    { "b1303c16-1bcb-457e-8985-ddb55baa642e", null, "Eusebio Nicomedes Sarmiento" },
                    { "b1d0bde0-1040-48e7-abc6-4a1f600d8fb5", null, "Farid Rick Herrera" },
                    { "b1db69e7-1027-4e79-8c7e-deedc380c78e", null, "Nicolás Rick Uribe" },
                    { "b1e16e51-00d3-46c5-a3aa-5fa8779bb2b4", null, "Alba Diomedes Toledo" },
                    { "b2d9dfa9-a99d-432d-b623-72e7049ac4a0", null, "Donald Freddy Ruiz" },
                    { "b3128697-95f4-4ed3-a400-069825c974c8", null, "Farid Nicomedes Maduro" },
                    { "b4565bf5-2aea-4756-92c8-5dc59b5c4caa", null, "Eusebio Anabel Ruiz" },
                    { "b4fdf3b8-0acc-48fd-98b4-1bb762cacd22", null, "Farid Anabel Toledo" },
                    { "b55eb63f-91d3-459c-b3a8-045e7deb577f", null, "Felipa Anabel Sarmiento" },
                    { "b5afbd19-c382-4778-808d-4ddb46308e1d", null, "Nicolás Silvana Uribe" },
                    { "b5e41a06-0976-4390-8491-080e57b268f8", null, "Donald Murty Trump" },
                    { "b6c51b56-1134-4789-881f-53345fc5f332", null, "Donald Nicomedes Toledo" },
                    { "b730c58d-3462-43c5-881d-d4f6a805fe40", null, "Farid Anabel Uribe" },
                    { "b8201423-db33-46c4-9625-d2d594045bf9", null, "Alba Anabel Ruiz" },
                    { "b8aefbac-18f1-44b6-950e-97481f931371", null, "Alvaro Rick Maduro" },
                    { "b9408eb2-c3d8-4a46-aed2-b2987ca178a5", null, "Donald Anabel Trump" },
                    { "ba069f05-998c-4a76-8c05-e6514dd3e9eb", null, "Donald Freddy Trump" },
                    { "ba6bf49c-9b4b-4eb4-a0d6-5f260b8919aa", null, "Alba Rick Herrera" },
                    { "bb15609d-6795-40ec-9624-1001939f1bd1", null, "Eusebio Freddy Trump" },
                    { "bb33f13c-0bdc-48d6-b8cc-e9ef586f0fe2", null, "Alba Murty Herrera" },
                    { "bb70185b-f1fb-4738-bcaa-b3ad57611d58", null, "Nicolás Murty Trump" },
                    { "bce25233-d483-4b23-a1f6-7a1d985d5b01", null, "Eusebio Diomedes Sarmiento" },
                    { "bd3d49d3-caa4-476c-96fb-56c699829ade", null, "Nicolás Murty Sarmiento" },
                    { "be4122b4-eac8-409b-b089-c9ceba777f66", null, "Felipa Freddy Ruiz" },
                    { "be685948-9ef0-4f3b-a5b2-aabb3aa6ece2", null, "Donald Freddy Maduro" },
                    { "beffeb31-d690-4e5d-9e3d-b9de131f8a53", null, "Eusebio Freddy Sarmiento" },
                    { "bf0f6c1c-4ad7-4b02-b88d-dafe4aeecafa", null, "Farid Rick Sarmiento" },
                    { "c02442ae-949e-4546-a049-713ef25a826a", null, "Alba Nicomedes Sarmiento" },
                    { "c0926e7c-bef2-44bd-ad89-ff01852dbaee", null, "Alba Diomedes Trump" },
                    { "c0a14e58-f077-42de-a582-9e183f1a4613", null, "Alba Diomedes Herrera" },
                    { "c0f6ac63-7b82-42eb-89d6-533c09e06311", null, "Felipa Freddy Sarmiento" },
                    { "c1846bd3-bea3-4bd3-b2c7-f77ce1baae7b", null, "Donald Nicomedes Maduro" },
                    { "c1a49e2c-4396-45a9-8cff-270125b519ae", null, "Felipa Murty Maduro" },
                    { "c2b2ba58-d954-4128-b3f1-c6944b9b32ab", null, "Farid Rick Ruiz" },
                    { "c318c9e9-f5f1-4f4b-baf2-4859e62e412f", null, "Alvaro Diomedes Sarmiento" },
                    { "c37f929f-0ddd-4e47-b6e1-6d8d6fe8f68c", null, "Nicolás Rick Sarmiento" },
                    { "c43ac7be-3f2c-4997-b523-9d6c28535cad", null, "Donald Murty Maduro" },
                    { "c53e81fc-94ef-452f-a625-c76d996b47b2", null, "Alvaro Teodoro Sarmiento" },
                    { "c57eb917-c637-411b-b70f-4ba456edcb64", null, "Donald Teodoro Herrera" },
                    { "c5c200b5-fc6a-46da-ad15-bb40370a1168", null, "Eusebio Murty Uribe" },
                    { "c5f9ce03-85a8-472f-9148-e9675538f1a1", null, "Eusebio Silvana Trump" },
                    { "c74efeac-87b1-43ab-a66b-f67c98829499", null, "Alvaro Nicomedes Toledo" },
                    { "c777e7cb-0960-4c5a-97c6-9e7eadf8bd5c", null, "Felipa Murty Herrera" },
                    { "c77b75e8-7601-4bce-b141-00d2aac169c5", null, "Donald Diomedes Toledo" },
                    { "c7be0c8a-db5c-4783-8a5d-f18bdb74884b", null, "Felipa Freddy Trump" },
                    { "c7df90e5-46c8-404d-997c-ebc22e22c594", null, "Eusebio Teodoro Maduro" },
                    { "c8063128-c285-42dc-a4a5-c844f126f97e", null, "Alba Diomedes Sarmiento" },
                    { "c886877c-8216-4302-b317-5b7561ad9b65", null, "Nicolás Anabel Maduro" },
                    { "c9098589-00cb-4496-b309-de170f44e734", null, "Nicolás Silvana Maduro" },
                    { "cb9cabb3-80fa-4eb2-8e67-6720f8ff3809", null, "Farid Nicomedes Herrera" },
                    { "cbc4684e-7616-473f-8e88-0bca328da003", null, "Eusebio Teodoro Herrera" },
                    { "cbeae485-5d2e-4168-975c-a9e61a74db6b", null, "Felipa Anabel Herrera" },
                    { "cc63d2df-c4b9-4142-b70f-3e3aa458a40b", null, "Alvaro Freddy Maduro" },
                    { "cce45def-9387-4d65-b034-21f6a512293d", null, "Nicolás Anabel Sarmiento" },
                    { "cd79e23e-4de5-45da-9362-8a7dd9f82f15", null, "Farid Anabel Herrera" },
                    { "cd925f39-ca15-47f6-a12c-5a11aafe8635", null, "Alvaro Silvana Uribe" },
                    { "cda53de1-66c9-426c-9957-890ece6b6e4b", null, "Donald Murty Sarmiento" },
                    { "cde22778-09a6-4efd-8266-3b11d1c2fd6a", null, "Felipa Murty Toledo" },
                    { "cde44cef-ab99-414c-ac96-19aa7c1985b1", null, "Eusebio Anabel Maduro" },
                    { "ce5e5937-049a-4301-94eb-e7c930230a10", null, "Alvaro Nicomedes Maduro" },
                    { "cf04c72e-e02a-4a02-b92e-6fe965ae5b7a", null, "Alvaro Freddy Herrera" },
                    { "cf89201d-d793-4429-94c6-208ca2b6eb57", null, "Farid Diomedes Herrera" },
                    { "d07150a7-d3f2-4907-a577-ebd96dc1eca9", null, "Donald Murty Uribe" },
                    { "d0cd1777-0884-4764-a4b9-90a16b78aed9", null, "Donald Rick Trump" },
                    { "d0df0c9b-2c37-4d23-9952-59a2fa793bc2", null, "Alba Silvana Trump" },
                    { "d113a8dc-9b16-4117-9d94-0b2780b163b0", null, "Eusebio Teodoro Toledo" },
                    { "d18b8ee4-bd17-45af-b35d-5b03bd19e072", null, "Nicolás Rick Maduro" },
                    { "d45d7782-f508-4d8b-9426-ae45f37169e5", null, "Nicolás Murty Herrera" },
                    { "d4b7b029-b0ea-46a8-9504-c4091b9d13e9", null, "Felipa Rick Toledo" },
                    { "d5086c2f-ba3d-410a-8044-da1e3dfbe901", null, "Felipa Teodoro Uribe" },
                    { "d57aa44d-2ba6-4858-816c-bea08e3e82bf", null, "Felipa Teodoro Sarmiento" },
                    { "d718503c-4355-4a4f-84b5-d777c7d86308", null, "Eusebio Anabel Herrera" },
                    { "d7834195-401c-4169-b10e-acbe925c2054", null, "Alvaro Silvana Maduro" },
                    { "d96e7c63-ea9e-424f-aefc-b0670fa40ecc", null, "Eusebio Rick Uribe" },
                    { "d982f690-7838-43b0-8f54-a531e47675d6", null, "Felipa Diomedes Maduro" },
                    { "d9f55ab1-64f4-4873-9c40-32a11a89dffb", null, "Farid Teodoro Trump" },
                    { "da7271a0-2a17-4007-8a62-2e46b278e2d4", null, "Alba Teodoro Sarmiento" },
                    { "db627ca2-45ba-4ee7-a93e-6560b1c55e65", null, "Alvaro Nicomedes Herrera" },
                    { "dc16fced-fdef-42a5-b675-0d238f7882f3", null, "Alba Silvana Maduro" },
                    { "deff6dd8-7f0d-419d-8e64-5114b29feec2", null, "Alba Anabel Toledo" },
                    { "e0c97e86-bc52-4a15-9d4d-2e361fe61f41", null, "Nicolás Diomedes Trump" },
                    { "e32b5c79-ade6-4ab2-8b8f-e1c6293bbb20", null, "Nicolás Teodoro Ruiz" },
                    { "e3814bbe-5a14-4555-b8f4-c356c44abee1", null, "Alvaro Rick Ruiz" },
                    { "e443d97a-0437-491a-8820-9cacbebbb1b5", null, "Donald Silvana Maduro" },
                    { "e5024136-d70f-4c8d-90cf-73d4c9fb9e9e", null, "Donald Freddy Sarmiento" },
                    { "e55a426e-31ae-4bc9-b7d5-61db7d0e6b6a", null, "Eusebio Murty Ruiz" },
                    { "e62d0643-a04e-4398-90dc-a78aa66be123", null, "Nicolás Freddy Toledo" },
                    { "e6a84c20-1c7a-4986-830e-6d542f6b35d7", null, "Alba Freddy Uribe" },
                    { "e85aac7c-cd85-40f6-8f5f-55ce8317d6a9", null, "Eusebio Freddy Ruiz" },
                    { "e98fb2ad-d7bd-4b1b-9ad3-e4d25adf903c", null, "Farid Freddy Trump" },
                    { "e9b5896d-18c5-427d-9ba0-604de90ffd1d", null, "Alba Diomedes Uribe" },
                    { "e9c8d6d5-ce6e-4a70-b601-00c871dff186", null, "Farid Nicomedes Trump" },
                    { "ea8186c5-8325-4c83-b18d-5fed766d37d0", null, "Nicolás Freddy Maduro" },
                    { "ed75829e-fd82-4f2c-9a7e-ab197bd61ba8", null, "Eusebio Murty Maduro" },
                    { "ef193da3-9bbe-4620-a4dd-627eb34117cd", null, "Eusebio Murty Trump" },
                    { "efaaaaea-ab4c-4c0e-a341-78fc76f50816", null, "Nicolás Freddy Herrera" },
                    { "efcd488d-06b6-4c62-b059-7044f07529af", null, "Farid Diomedes Maduro" },
                    { "f00aa036-f1c4-4daf-a207-4ad2e965ca62", null, "Nicolás Freddy Sarmiento" },
                    { "f0164782-aa6a-4666-8838-8c9c4854561f", null, "Felipa Teodoro Trump" },
                    { "f063fe2f-8ca7-4aa4-8417-dce43b6b75d0", null, "Alba Silvana Ruiz" },
                    { "f07543c6-b184-4fba-ac27-c1a80ec8ee35", null, "Alvaro Murty Toledo" },
                    { "f1437589-8693-4b80-85ca-6e387fd6f470", null, "Alba Anabel Maduro" },
                    { "f163065b-104a-41e0-86ed-57ee70b7f53d", null, "Farid Nicomedes Sarmiento" },
                    { "f2590c97-8534-4516-93cc-a406eb07493f", null, "Farid Anabel Maduro" },
                    { "f307972c-ae28-4bbd-b9c8-70bbc662305a", null, "Donald Silvana Uribe" },
                    { "f320861f-62ee-468d-bcb2-ce60c136e8d7", null, "Farid Nicomedes Uribe" },
                    { "f3890c4a-09be-483c-b12b-27a30932d20e", null, "Alvaro Anabel Trump" },
                    { "f3ac30b6-a815-461a-8c54-d9af2613b2ca", null, "Eusebio Rick Trump" },
                    { "f4dffa8d-a36d-4d63-a00c-e21806e6564b", null, "Felipa Silvana Maduro" },
                    { "f4f6dd0e-55de-4211-8ac6-3386e5540d6b", null, "Eusebio Silvana Uribe" },
                    { "f50d4e4e-6f9f-432a-b8db-50a0b5127a2c", null, "Farid Murty Sarmiento" },
                    { "f560999c-f094-430a-9303-de4b75fe2314", null, "Alba Teodoro Herrera" },
                    { "f5bde9b6-6509-451e-99ec-5c04d7c06c87", null, "Alba Nicomedes Maduro" },
                    { "f5c62929-957e-455c-b5c5-64841d306b01", null, "Alba Rick Ruiz" },
                    { "f621f222-b48d-441a-b455-04e0d30a97b8", null, "Felipa Silvana Uribe" },
                    { "f702f2d6-93dc-498c-915e-9b4ee490fa50", null, "Eusebio Rick Herrera" },
                    { "f7e28148-cc7e-4d14-a489-236743dc8caf", null, "Alba Rick Toledo" },
                    { "f88a3791-50da-41b7-9cc4-75ffc8c5131b", null, "Nicolás Diomedes Ruiz" },
                    { "f92d4b53-bfcd-4373-8919-9f9dda01e236", null, "Alvaro Freddy Trump" },
                    { "f934362e-f798-4e75-90db-7a884cac8bc2", null, "Alba Freddy Toledo" },
                    { "f9668cde-7ee7-40b1-a955-f772852dc5fa", null, "Alba Murty Maduro" },
                    { "fa23b6bf-2073-46d6-bc59-a84513544e16", null, "Eusebio Silvana Toledo" },
                    { "faa9d784-1646-4711-b2b4-35241e4fd5e3", null, "Alvaro Diomedes Toledo" },
                    { "faebafa6-0e5d-4086-9bf1-9e0cbdffc314", null, "Alba Rick Trump" },
                    { "fbb6809a-8ab1-4b6f-b406-b1fe92e1592a", null, "Donald Diomedes Sarmiento" },
                    { "fbd1913c-39bb-4051-81b0-031a84e6c7ca", null, "Felipa Anabel Maduro" },
                    { "fc04cf62-cb57-4b49-be4b-3e297dd7992d", null, "Alvaro Nicomedes Trump" },
                    { "fc8e91a4-254e-4680-983b-693e5be408f4", null, "Alba Murty Toledo" },
                    { "fd12e6d7-cf34-4dd9-8359-295fde5e66ed", null, "Felipa Murty Trump" },
                    { "fd3b89b3-1af0-4115-938a-d66259e19d11", null, "Felipa Freddy Maduro" },
                    { "febd4204-594e-478e-8b38-f5cae3659ae9", null, "Felipa Nicomedes Maduro" },
                    { "fee0bfd3-42fd-4eca-98f8-16896134bf2f", null, "Nicolás Anabel Trump" },
                    { "fefaf8c5-7abb-424c-8cf2-d3521c9d4ab2", null, "Alba Silvana Sarmiento" },
                    { "ff994e9c-2908-426a-bcae-2c271f539a8c", null, "Farid Anabel Trump" }
                });

            migrationBuilder.InsertData(
                table: "Asignaturas",
                columns: new[] { "Id", "CursoId", "Nombre" },
                values: new object[,]
                {
                    { "14c3ed8d-ec92-425d-995b-aa78687a9620", null, "Programacion" },
                    { "5406d145-2f8f-449c-8535-009837609cc8", null, "Educación Física" },
                    { "6ecdb722-00ce-4378-ab01-2146fda28330", null, "Castellano" },
                    { "9aa230ca-b6a5-4388-94a1-f136c5cbf9b1", null, "Ciencias Naturales" },
                    { "b9f0297d-ffbd-42ff-98f3-dd728b9691ca", null, "Matemáticas" }
                });

            migrationBuilder.InsertData(
                table: "Escuelas",
                columns: new[] { "Id", "AnioCreacion", "Ciudad", "Dirección", "Nombre", "Pais", "TipoEscuela" },
                values: new object[] { "fe7df5cd-4571-4fa4-a646-ac2f299a817e", 2005, "Santa Cruz", "Loc. Mineros", "Platzi School", "Bolivia", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_CursoId",
                table: "Alumnos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_CursoId",
                table: "Asignaturas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_EscuelaId",
                table: "Cursos",
                column: "EscuelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_AlumnoId",
                table: "Evaluaciones",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_AsignaturaId",
                table: "Evaluaciones",
                column: "AsignaturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Escuelas");
        }
    }
}
