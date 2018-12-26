using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalyaCMS.Infrastructure.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AuthorName = table.Column<string>(maxLength: 50, nullable: false),
                    Designation = table.Column<string>(maxLength: 15, nullable: true),
                    IsStaff = table.Column<bool>(nullable: true),
                    Photo = table.Column<string>(maxLength: 300, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commentators",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    FullName = table.Column<string>(maxLength: 60, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    GalleryName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    CreatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Body = table.Column<string>(maxLength: 1500, nullable: false),
                    PublishDate = table.Column<DateTimeOffset>(nullable: true),
                    SiteUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ArticleId = table.Column<string>(nullable: true),
                    CommentDate = table.Column<DateTimeOffset>(nullable: false),
                    IsReply = table.Column<bool>(nullable: true),
                    CommentBody = table.Column<string>(nullable: true),
                    ParentCommentId = table.Column<string>(nullable: true),
                    CommentatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Commentators_CommentatorId",
                        column: x => x.CommentatorId,
                        principalTable: "Commentators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    AssetName = table.Column<string>(maxLength: 50, nullable: false),
                    Body = table.Column<string>(nullable: true),
                    ArticleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    PicturePath = table.Column<string>(maxLength: 300, nullable: false),
                    GalleryId = table.Column<string>(nullable: true),
                    ArticleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Like = table.Column<int>(nullable: false),
                    SiteUserId = table.Column<string>(nullable: true),
                    ArticleId = table.Column<string>(nullable: true),
                    CommentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinions_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opinions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opinions_Authors_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PictureId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(nullable: false),
                    ArticleId = table.Column<string>(nullable: true),
                    TagId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SiteUserId",
                table: "Articles",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Title",
                table: "Articles",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_ArticleId",
                table: "ArticleTags",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ArticleId",
                table: "Assets",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetName",
                table: "Assets",
                column: "AssetName");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorName",
                table: "Authors",
                column: "AuthorName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentatorId",
                table: "Comments",
                column: "CommentatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_GalleryName",
                table: "Galleries",
                column: "GalleryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_ArticleId",
                table: "Opinions",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_CommentId",
                table: "Opinions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_SiteUserId",
                table: "Opinions",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ArticleId",
                table: "Pictures",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_GalleryId",
                table: "Pictures",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_Title",
                table: "Pictures",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PictureId",
                table: "Tags",
                column: "PictureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTags");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "SiteRoles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Commentators");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
