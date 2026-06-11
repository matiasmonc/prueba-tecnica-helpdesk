-- =========================================================================
-- SCRIPT DE INSERCIÓN DE DATOS DE PRUEBA (SEEDS)
-- =========================================================================

-- 1. Insertar Roles Básicos
INSERT INTO Rol (Name, CreatedAt, Active) VALUES 
('Admin', GETDATE(), 1),
('Supervisor', GETDATE(), 1),
('Client', GETDATE(), 1); -- El nombre estándar para el usuario normal

-- 2. Insertar Prioridades
INSERT INTO Priority (Name, CreatedAt) VALUES 
('Low', GETDATE()),
('Medium', GETDATE()),
('High', GETDATE()),
('Critical', GETDATE());

-- 3. Insertar Estados
INSERT INTO Status (Name, CreatedAt) VALUES 
('Open', GETDATE()),
('InProgress', GETDATE()),
('Resolved', GETDATE()),
('Closed', GETDATE());

-- 4. Insertar Usuarios de Prueba (Asociando los Roles creados)
DECLARE @IdAdmin UNIQUEIDENTIFIER = NEWID();
DECLARE @IdSupervisor UNIQUEIDENTIFIER = NEWID();
DECLARE @IdClient1 UNIQUEIDENTIFIER = NEWID();
DECLARE @IdClient2 UNIQUEIDENTIFIER = NEWID();

-- Obtener IDs de los roles
DECLARE @RolAdmin TINYINT = (SELECT Id FROM Rol WHERE Name = 'Admin');
DECLARE @RolSupervisor TINYINT = (SELECT Id FROM Rol WHERE Name = 'Supervisor');
DECLARE @RolClient TINYINT = (SELECT Id FROM Rol WHERE Name = 'Client');

INSERT INTO [User] (Id, Email, [Password], DisplayName, CreatedAt, Active, IdRol) VALUES
(@IdAdmin, 'admin@helpdesk.com', 'hash_password_placeholder', 'Administrador Sistema', GETDATE(), 1, @RolAdmin),
(@IdSupervisor, 'supervisor@helpdesk.com', 'hash_password_placeholder', 'Supervisor Soporte', GETDATE(), 1, @RolSupervisor),
(@IdClient1, 'juan.perez@cliente.com', 'hash_password_placeholder', 'Juan Pérez', GETDATE(), 1, @RolClient),
(@IdClient2, 'maria.gomez@cliente.com', 'hash_password_placeholder', 'María Gómez', GETDATE(), 1, @RolClient);


-- 5. Generación masiva de 40 Tickets y Comentarios Variables
DECLARE @TicketCounter INT = 1;
DECLARE @TotalTickets INT = 40;

-- Variables para IDs de catálogos
DECLARE @MinPriority TINYINT = (SELECT MIN(Id) FROM Priority);
DECLARE @MaxPriority TINYINT = (SELECT MAX(Id) FROM Priority);
DECLARE @MinStatus TINYINT = (SELECT MIN(Id) FROM Status);
DECLARE @MaxStatus TINYINT = (SELECT MAX(Id) FROM Status);

-- Textos simulados para Lorem Ipsum (Fragmentos)
DECLARE @Lorem1 VARCHAR(200) = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. ';
DECLARE @Lorem2 VARCHAR(200) = 'Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ';
DECLARE @Lorem3 VARCHAR(200) = 'Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris. ';
DECLARE @Lorem4 VARCHAR(200) = 'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum. ';

WHILE @TicketCounter <= @TotalTickets
BEGIN
    -- Generar valores aleatorios para el Ticket
    DECLARE @RandomPriority TINYINT = ABS(CHECKSUM(NEWID())) % (@MaxPriority - @MinPriority + 1) + @MinPriority;
    DECLARE @RandomStatus TINYINT = ABS(CHECKSUM(NEWID())) % (@MaxStatus - @MinStatus + 1) + @MinStatus;
    
    -- El creador del ticket rota entre los dos clientes disponibles
    DECLARE @TicketCreator UNIQUEIDENTIFIER = CASE WHEN @TicketCounter % 2 = 0 THEN @IdClient1 ELSE @IdClient2 END;
    
    -- Insertar el Ticket actual
    INSERT INTO Ticket (Title, Description, CreatedAt, UpdatedAt, CreatedBy, IdPriority, IdStatus)
    VALUES (
        'Incidente de prueba #' + CAST(@TicketCounter AS VARCHAR(10)),
        @Lorem1 + @Lorem2 + 'Detalles del ticket automatizado para validación del modelo.',
        DATEADD(DAY, -@TicketCounter, GETDATE()), -- Fechas escalonadas hacia el pasado
        NULL,
        @TicketCreator,
        @RandomPriority,
        @RandomStatus
    );

    -- Obtener el Id del ticket recién creado
    DECLARE @CurrentTicketId INT = SCOPE_IDENTITY();

    -- Generar Comentarios (Dejar unos pocos sin comentarios basados en el ID)
    -- Si el contador es divisible por 7, el ticket no tendrá comentarios (Aproximadamente 5 tickets vacíos)
    IF @TicketCounter % 7 != 0
    BEGIN
        -- Cantidad variable de comentarios entre 1 y 5 por ticket
        DECLARE @MaxComments INT = ABS(CHECKSUM(NEWID())) % 5 + 1;
        DECLARE @CommentCounter INT = 1;

        WHILE @CommentCounter <= @MaxComments
        BEGIN
            -- El creador del comentario puede ser el cliente o soporte de forma aleatoria
            DECLARE @CommentCreator UNIQUEIDENTIFIER = CASE WHEN ABS(CHECKSUM(NEWID())) % 2 = 0 THEN @IdAdmin ELSE @TicketCreator END;
            
            -- Armar un texto de Lorem Ipsum dinámico y variable
            DECLARE @CommentText NVARCHAR(1000) = 
                CASE WHEN @CommentCounter = 1 THEN @Lorem3
                     WHEN @CommentCounter = 2 THEN @Lorem2 + @Lorem4
                     WHEN @CommentCounter = 3 THEN @Lorem1 + @Lorem3 + @Lorem4
                     ELSE @Lorem4 + @Lorem1 
                END;

            INSERT INTO Comment (IdTicket, [Text], CreatedAt, CreatedBy)
            VALUES (
                @CurrentTicketId,
                @CommentText,
                DATEADD(MINUTE, @CommentCounter * 30, DATEADD(DAY, -@TicketCounter, GETDATE())), -- Comentarios posteriores al ticket
                @CommentCreator
            );

            SET @CommentCounter = @CommentCounter + 1;
        END
    END

    SET @TicketCounter = @TicketCounter + 1;
END;
