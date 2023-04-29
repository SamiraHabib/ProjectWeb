using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoWeb.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id_address = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    city = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    neighborhood = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    complement = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id_address);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    id_exercise = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.id_exercise);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    id_genre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    normalized_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.id_genre);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    id_payment_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.id_payment_type);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    id_profile = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    normalized_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.id_profile);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    normalized_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id_status);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    id_teacher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.id_teacher);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_profile = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    social_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_User_Profile",
                        column: x => x.id_profile,
                        principalTable: "Profile",
                        principalColumn: "id_profile",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    id_class = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    end_hour = table.Column<TimeSpan>(type: "time", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.id_class);
                    table.ForeignKey(
                        name: "fk_class_status",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "id_status",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_class_teacher",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "id_teacher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    id_admin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.id_admin);
                    table.ForeignKey(
                        name: "FK_Admin_User_id_user",
                        column: x => x.id_user,
                        principalTable: "User",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id_student = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    id_genre = table.Column<int>(type: "int", nullable: true),
                    id_address = table.Column<int>(type: "int", nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_blocked = table.Column<bool>(type: "bit", nullable: true),
                    block_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_profile = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id_student);
                    table.ForeignKey(
                        name: "FK_Student_Address_id_address",
                        column: x => x.id_address,
                        principalTable: "Address",
                        principalColumn: "id_address");
                    table.ForeignKey(
                        name: "FK_Student_Genre_id_genre",
                        column: x => x.id_genre,
                        principalTable: "Genre",
                        principalColumn: "id_genre");
                    table.ForeignKey(
                        name: "FK_Student_User_id_user",
                        column: x => x.id_user,
                        principalTable: "User",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "ContentManagement",
                columns: table => new
                {
                    id_content_management = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_address = table.Column<int>(type: "int", nullable: false),
                    id_admin = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    subTitulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    about_description = table.Column<string>(type: "text", nullable: false),
                    main_img_url = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    logo_img_url = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    page_title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    is_main = table.Column<bool>(type: "bit", nullable: false),
                    whatsapp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email_contact = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    AddressIdAddress = table.Column<int>(type: "int", nullable: false),
                    AdminIdAdmin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentManagement", x => x.id_content_management);
                    table.ForeignKey(
                        name: "FK_ContentManagement_Address_AddressIdAddress",
                        column: x => x.AddressIdAddress,
                        principalTable: "Address",
                        principalColumn: "id_address",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentManagement_Admin_AdminIdAdmin",
                        column: x => x.AdminIdAdmin,
                        principalTable: "Admin",
                        principalColumn: "id_admin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    id_payment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_admin = table.Column<int>(type: "int", nullable: false),
                    id_student = table.Column<int>(type: "int", nullable: false),
                    id_status = table.Column<int>(type: "int", nullable: false),
                    id_payment_type = table.Column<int>(type: "int", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    invoice = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    date_payment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.id_payment);
                    table.ForeignKey(
                        name: "FK_Payment_Admin_id_admin",
                        column: x => x.id_admin,
                        principalTable: "Admin",
                        principalColumn: "id_admin",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentType_id_payment_type",
                        column: x => x.id_payment_type,
                        principalTable: "PaymentType",
                        principalColumn: "id_payment_type",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Status_id_status",
                        column: x => x.id_status,
                        principalTable: "Status",
                        principalColumn: "id_status",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Student_id_student",
                        column: x => x.id_student,
                        principalTable: "Student",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCheckin",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdClass = table.Column<int>(type: "int", nullable: false),
                    date_time = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCheckin", x => new { x.IdStudent, x.IdClass });
                    table.ForeignKey(
                        name: "FK_StudentCheckin_Class_IdClass",
                        column: x => x.IdClass,
                        principalTable: "Class",
                        principalColumn: "id_class",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCheckin_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentPointsClass",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false),
                    IdExercise = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPointsClass", x => new { x.IdStudent, x.IdExercise });
                    table.ForeignKey(
                        name: "FK_StudentPointsClass_Exercise_IdExercise",
                        column: x => x.IdExercise,
                        principalTable: "Exercise",
                        principalColumn: "id_exercise",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentPointsClass_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalTable: "Student",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telephone",
                columns: table => new
                {
                    id_telephone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_student = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephone", x => x.id_telephone);
                    table.ForeignKey(
                        name: "FK_Telephone_Student",
                        column: x => x.id_student,
                        principalTable: "Student",
                        principalColumn: "id_student",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_id_user",
                table: "Admin",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Class_StatusId",
                table: "Class",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_TeacherId",
                table: "Class",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagement_AddressIdAddress",
                table: "ContentManagement",
                column: "AddressIdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_ContentManagement_AdminIdAdmin",
                table: "ContentManagement",
                column: "AdminIdAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_id_admin",
                table: "Payment",
                column: "id_admin");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_id_payment_type",
                table: "Payment",
                column: "id_payment_type");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_id_status",
                table: "Payment",
                column: "id_status");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_id_student",
                table: "Payment",
                column: "id_student");

            migrationBuilder.CreateIndex(
                name: "IX_Student_id_address",
                table: "Student",
                column: "id_address");

            migrationBuilder.CreateIndex(
                name: "IX_Student_id_genre",
                table: "Student",
                column: "id_genre");

            migrationBuilder.CreateIndex(
                name: "IX_Student_id_user",
                table: "Student",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCheckin_IdClass",
                table: "StudentCheckin",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPointsClass_IdExercise",
                table: "StudentPointsClass",
                column: "IdExercise");

            migrationBuilder.CreateIndex(
                name: "IX_Telephone_id_student",
                table: "Telephone",
                column: "id_student");

            migrationBuilder.CreateIndex(
                name: "IX_User_id_profile",
                table: "User",
                column: "id_profile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentManagement");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "StudentCheckin");

            migrationBuilder.DropTable(
                name: "StudentPointsClass");

            migrationBuilder.DropTable(
                name: "Telephone");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
