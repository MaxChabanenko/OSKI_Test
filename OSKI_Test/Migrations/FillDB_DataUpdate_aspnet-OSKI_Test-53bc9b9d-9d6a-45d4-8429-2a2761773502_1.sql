/*
Этот скрипт создан Visual Studio на 13.09.2023 в 18:54.
Выполните этот скрипт на (localdb)\mssqllocaldb.aspnet-OSKI_Test-53bc9b9d-9d6a-45d4-8429-2a2761773502 (DESKTOP-UM0ILRF\Maksi), чтобы сделать этот объект таким же, как (localdb)\mssqllocaldb.aspnet-OSKI_Test-53bc9b9d-9d6a-45d4-8429-2a2761773502_copy (DESKTOP-UM0ILRF\Maksi).
Этот скрипт выполняет свои действия в следующем порядке.
1. Отключение ограничений внешнего ключа.
2. Выполнение команд DELETE. 
3. Выполнение команд UPDATE.
4. Выполнение команд INSERT.
5. Повторное включение ограничений внешнего ключа.
Создайте резервную копию своей базы данных-получателя перед выполнением этого скрипта.
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
/*Для обновления текста/изображения использовался указатель. Это может не потребоваться, но на всякий случай это указано здесь.*/
DECLARE @pv binary(16)
BEGIN TRANSACTION
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
ALTER TABLE [dbo].[AspNetUserTokens] DROP CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
ALTER TABLE [dbo].[Option] DROP CONSTRAINT [FK_Option_Question_QuestionId]
ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_Question_QuizResponses_AssignedQuizQuizId_AssignedQuizUserId]
ALTER TABLE [dbo].[Question] DROP CONSTRAINT [FK_Question_Quizzes_QuizId]
ALTER TABLE [dbo].[QuizResponses] DROP CONSTRAINT [FK_QuizResponses_AspNetUsers_ApplicationUserId]
ALTER TABLE [dbo].[QuizResponses] DROP CONSTRAINT [FK_QuizResponses_Quizzes_QuizId]
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
ALTER TABLE [dbo].[AspNetRoleClaims] DROP CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
ALTER TABLE [dbo].[AnswerToQuestion] DROP CONSTRAINT [FK_AnswerToQuestion_Option_OptionId]
ALTER TABLE [dbo].[AnswerToQuestion] DROP CONSTRAINT [FK_AnswerToQuestion_Question_QuestionId]
ALTER TABLE [dbo].[AnswerToQuestion] DROP CONSTRAINT [FK_AnswerToQuestion_Quizzes_QuizId]
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'063b0177-8f8b-47da-ab1c-5722eed7c32f', N'chabanenko@knu.ua', N'CHABANENKO@KNU.UA', N'chabanenko@knu.ua', N'CHABANENKO@KNU.UA', 1, N'AQAAAAEAACcQAAAAEL7J5yA2r3axqfjYtOL06nrZbq3EyUknMC9SkC3WphMKN/OM1qI16UpRoPx0FDRRvA==', N'MJS5FZH5L46DACBLBKNQDVFD67TL6C6G', N'be57106b-7003-4521-a851-f6f562108ee4', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Quizzes] ON
INSERT INTO [dbo].[Quizzes] ([Id], [QuizName]) VALUES (1, N'History (Completed)')
INSERT INTO [dbo].[Quizzes] ([Id], [QuizName]) VALUES (2, N'Math(UNCompleted)')
SET IDENTITY_INSERT [dbo].[Quizzes] OFF
GO
INSERT INTO [dbo].[AnswerToQuestion] ([QuizId], [QuestionId], [OptionId]) VALUES (1, 1, 4)
INSERT INTO [dbo].[AnswerToQuestion] ([QuizId], [QuestionId], [OptionId]) VALUES (1, 2, 7)
GO
INSERT INTO [dbo].[QuizResponses] ([QuizId], [UserId], [Score], [ApplicationUserId]) VALUES (1, N'063b0177-8f8b-47da-ab1c-5722eed7c32f', 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Question] ON
INSERT INTO [dbo].[Question] ([Id], [Text], [SelectedOptionId], [AssignedQuizQuizId], [AssignedQuizUserId], [QuizId]) VALUES (1, N'In which year did World War I begin?', 4, 1, N'063b0177-8f8b-47da-ab1c-5722eed7c32f', 1)
INSERT INTO [dbo].[Question] ([Id], [Text], [SelectedOptionId], [AssignedQuizQuizId], [AssignedQuizUserId], [QuizId]) VALUES (2, N'Where was John F. Kennedy assassinated?', 6, NULL, NULL, 1)
INSERT INTO [dbo].[Question] ([Id], [Text], [SelectedOptionId], [AssignedQuizQuizId], [AssignedQuizUserId], [QuizId]) VALUES (3, N'9*8', NULL, NULL, NULL, 2)
INSERT INTO [dbo].[Question] ([Id], [Text], [SelectedOptionId], [AssignedQuizQuizId], [AssignedQuizUserId], [QuizId]) VALUES (4, N'77+33', NULL, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Option] ON
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (1, N'1923', 1)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (2, N'1938', 1)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (3, N'1917', 1)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (4, N'1914', 1)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (5, N'New York', 2)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (6, N'Austin', 2)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (7, N'Dallas', 2)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (8, N'Miami', 2)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (9, N'68', 3)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (10, N'70', 3)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (11, N'72', 3)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (12, N'74', 3)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (13, N'100', 4)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (14, N'0', 4)
INSERT INTO [dbo].[Option] ([Id], [Text], [QuestionId]) VALUES (15, N'110', 4)
SET IDENTITY_INSERT [dbo].[Option] OFF
GO
INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230913135529_quiz model creation', N'6.0.21')
ALTER TABLE [dbo].[AspNetUserLogins]
    ADD CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserTokens]
    ADD CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[Option]
    ADD CONSTRAINT [FK_Option_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
ALTER TABLE [dbo].[Question]
    ADD CONSTRAINT [FK_Question_QuizResponses_AssignedQuizQuizId_AssignedQuizUserId] FOREIGN KEY ([AssignedQuizQuizId], [AssignedQuizUserId]) REFERENCES [dbo].[QuizResponses] ([QuizId], [UserId])
ALTER TABLE [dbo].[Question]
    ADD CONSTRAINT [FK_Question_Quizzes_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [dbo].[Quizzes] ([Id])
ALTER TABLE [dbo].[QuizResponses]
    ADD CONSTRAINT [FK_QuizResponses_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
ALTER TABLE [dbo].[QuizResponses]
    ADD CONSTRAINT [FK_QuizResponses_Quizzes_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [dbo].[Quizzes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserRoles]
    ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetRoleClaims]
    ADD CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AnswerToQuestion]
    ADD CONSTRAINT [FK_AnswerToQuestion_Option_OptionId] FOREIGN KEY ([OptionId]) REFERENCES [dbo].[Option] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AnswerToQuestion]
    ADD CONSTRAINT [FK_AnswerToQuestion_Question_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AnswerToQuestion]
    ADD CONSTRAINT [FK_AnswerToQuestion_Quizzes_QuizId] FOREIGN KEY ([QuizId]) REFERENCES [dbo].[Quizzes] ([Id]) ON DELETE CASCADE
ALTER TABLE [dbo].[AspNetUserClaims]
    ADD CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
COMMIT TRANSACTION
