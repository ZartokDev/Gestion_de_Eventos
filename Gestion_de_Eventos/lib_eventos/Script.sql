CREATE DATABASE DBeventos;
GO


USE DBeventos
GO
-- Tablas sin dependencias (sin FK)
CREATE TABLE TipoTrabajadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Salario INT,
    Descripcion NVARCHAR(500),
    Estado BIT NOT NULL
);

CREATE TABLE PersonalApoyos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Cantidad INT,
    Horario DATE,
    Estado BIT NOT NULL
);

CREATE TABLE TipoPagos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Descripcion NVARCHAR(500),
    Comision INT,
    Estado BIT NOT NULL
);

CREATE TABLE Ofertas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaLimite DATE,
    Descuento INT,
    Nombre NVARCHAR(255),
    Estado BIT NOT NULL
);

CREATE TABLE Proveedores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Telefono NVARCHAR(50),
    Correo NVARCHAR(255),
    TipoProducto NVARCHAR(255),
    Estado BIT NOT NULL
);

CREATE TABLE Horarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    HoraInicio NVARCHAR(50),
    HoraFin NVARCHAR(50),
    Turno NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Estado BIT NOT NULL
);

CREATE TABLE TipoPatrocinadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Descripcion NVARCHAR(500),
    NivelAporte NVARCHAR(255),
    Beneficios NVARCHAR(500),
    Estado BIT NOT NULL
);

CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Documento NVARCHAR(50),
    Telefono NVARCHAR(50),
    Correo NVARCHAR(255),
    Estado BIT NOT NULL
);

CREATE TABLE Reservas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaReserva DATE,
    Ubicacion NVARCHAR(255),
    Observaciones NVARCHAR(500),
    Estado BIT NOT NULL
);

CREATE TABLE TipoEventos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    DuracionEstimada NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Estado BIT NOT NULL
);
CREATE TABLE TipoAdministradores(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Descripcion NVARCHAR(500),
    NivelAcceso NVARCHAR(100),
    Estado BIT NOT NULL
);

CREATE TABLE TipoInventarios(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Descripcion NVARCHAR(500),
    Categoria NVARCHAR(255),
    Estado BIT NOT NULL
);

CREATE TABLE TipoTransportes(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Capacidad INT,
    Descripcion NVARCHAR(500),
    Estado BIT NOT NULL
);

CREATE TABLE TipoLugares(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Capacidad INT,
    Descripcion NVARCHAR(500),
    Estado BIT NOT NULL
);
-- Tablas con una FK

CREATE TABLE Lugares (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Direccion NVARCHAR(500),
    Capacidad INT,
    Estado BIT NOT NULL,
    TipoLugar INT,
    FOREIGN KEY (TipoLugar) REFERENCES TipoLugares(Id)
);

CREATE TABLE Transportes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Vehiculo NVARCHAR(255),
    Placa NVARCHAR(50),
    Capacidad INT,
    Estado BIT NOT NULL,
    TipoTransporte INT,
    FOREIGN KEY (TipoTransporte) REFERENCES TipoTransportes(Id)
);

CREATE TABLE Administradores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Telefono NVARCHAR(50),
    Correo NVARCHAR(255),
    Contraseña NVARCHAR(255),
    Estado BIT NOT NULL,
    TipoAdministrador INT,
    FOREIGN KEY (TipoAdministrador) REFERENCES TipoAdministradores(Id)
);

CREATE TABLE Auditorias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    TipoAccion NVARCHAR(255),
    Descripcion NVARCHAR(500),
    Fecha DATETIME,
    Administrador INT,
    FOREIGN KEY (Administrador) REFERENCES Administradores(Id)
);

CREATE TABLE Trabajadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Telefono NVARCHAR(50),
    Correo NVARCHAR(255),
    FechaIngreso DATE,
    Estado BIT NOT NULL,
    TipoTrabajador INT,
    FOREIGN KEY (TipoTrabajador) REFERENCES TipoTrabajadores(Id)
);

CREATE TABLE Grupos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Cantidad INT,
    CantEventos INT,
    Estado BIT NOT NULL,
    PersonalApoyo INT,
    Transporte INT,
    FOREIGN KEY (PersonalApoyo) REFERENCES PersonalApoyos(Id),
    FOREIGN KEY (Transporte) REFERENCES Transportes(Id)
);

CREATE TABLE Inventarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    EstadoProducto BIT NOT NULL,
    Cantidad INT,
    Proveedor INT,
    TipoInventario INT,
    FOREIGN KEY (Proveedor) REFERENCES Proveedores(Id),
    FOREIGN KEY (TipoInventario) REFERENCES TipoInventarios(Id)
);

CREATE TABLE Patrocinadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Correo NVARCHAR(255),
    Telefono NVARCHAR(50),
    Direccion NVARCHAR(500),
    Estado BIT NOT NULL,
    TipoPatrocinador INT,
    FOREIGN KEY (TipoPatrocinador) REFERENCES TipoPatrocinadores(Id)
);

CREATE TABLE GruposTrabajadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Descripcion NVARCHAR(500),
    Estado BIT NOT NULL,
    Trabajador INT,
    Grupo INT,
    FOREIGN KEY (Trabajador) REFERENCES Trabajadores(Id),
    FOREIGN KEY (Grupo) REFERENCES Grupos(Id)
);

-- Tabla central: Eventos
CREATE TABLE Eventos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Fecha DATE,
    Descripcion NVARCHAR(500),
    CantPersonas INT,
    Estado BIT NOT NULL,
    Grupo INT,
    Inventario INT,
    Horario INT,
    Administrador INT,
    TipoEvento INT,
    Patrocinador INT,
    Lugar INT,
    Reserva INT,
    Cliente INT,
    FOREIGN KEY (Grupo) REFERENCES Grupos(Id),
    FOREIGN KEY (Inventario)      REFERENCES Inventarios(Id),
    FOREIGN KEY (Horario)         REFERENCES Horarios(Id),
    FOREIGN KEY (Administrador)   REFERENCES Administradores(Id),
    FOREIGN KEY (TipoEvento)      REFERENCES TipoEventos(Id),
    FOREIGN KEY (Patrocinador)    REFERENCES Patrocinadores(Id),
    FOREIGN KEY (Lugar)           REFERENCES Lugares(Id),
    FOREIGN KEY (Reserva)         REFERENCES Reservas(Id),
    FOREIGN KEY (Cliente)         REFERENCES Clientes(Id)
);

-- Tabla Facturas (depende de Eventos, TipoPagos, Ofertas)
CREATE TABLE Facturas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    NumFactura NVARCHAR(100),
    FechaEmision DATE,
    Total INT,
    EstadoPago BIT NOT NULL,
    TipoPago INT,
    Oferta INT,
    Evento INT,
    FOREIGN KEY (TipoPago) REFERENCES TipoPagos(Id),
    FOREIGN KEY (Oferta)   REFERENCES Ofertas(Id),
    FOREIGN KEY (Evento)   REFERENCES Eventos(Id)
);

USE DBeventos;
GO
 
-- ============================================================
--  INSERTS "No Asignado"  
--  Orden respetando dependencias de FK
-- ============================================================
 
-- ─────────────────────────────────────────────────────────────
-- 1. TABLAS TIPO (sin FK)
-- ─────────────────────────────────────────────────────────────
 
-- TipoAdministradores  →  necesario antes de Administradores
INSERT INTO TipoAdministradores (Nombre, Descripcion, NivelAcceso, Estado)
VALUES ('No Asignado', 'Registro por defecto sin asignación', 'N/A', 0);
 
-- TipoInventarios  →  necesario antes de Inventarios
INSERT INTO TipoInventarios (Nombre, Descripcion, Categoria, Estado)
VALUES ('No Asignado', 'Registro por defecto sin asignación', 'N/A', 0);
 
-- TipoTransportes  →  necesario antes de Transportes
INSERT INTO TipoTransportes (Nombre, Capacidad, Descripcion, Estado)
VALUES ('No Asignado', 0, 'Registro por defecto sin asignación', 0);
 
-- TipoLugares  →  necesario antes de Lugares
INSERT INTO TipoLugares (Nombre, Capacidad, Descripcion, Estado)
VALUES ('No Asignado', 0, 'Registro por defecto sin asignación', 0);
 
-- TipoPatrocinadores  →  necesario antes de Patrocinadores
INSERT INTO TipoPatrocinadores (Nombre, Descripcion, NivelAporte, Beneficios, Estado)
VALUES ('No Asignado', 'Registro por defecto sin asignación', 'N/A', 'N/A', 0);
 
-- TipoTrabajadores  →  necesario antes de Trabajadores
INSERT INTO TipoTrabajadores (Nombre, Salario, Descripcion, Estado)
VALUES ('No Asignado', 0, 'Registro por defecto sin asignación', 0);
 
-- ─────────────────────────────────────────────────────────────
-- 2. TABLAS INDEPENDIENTES (sin FK)
-- ─────────────────────────────────────────────────────────────
 
-- PersonalApoyos  →  necesario antes de Grupos
INSERT INTO PersonalApoyos (Nombre, Cantidad, Horario, Estado)
VALUES ('No Asignado', 0, '2000-01-01', 0);
 
-- Proveedores  →  necesario antes de Inventarios
INSERT INTO Proveedores (Nombre, Telefono, Correo, TipoProducto, Estado)
VALUES ('No Asignado', 'N/A', 'noasignado@na.com', 'N/A', 0);
 
-- Clientes  →  necesario antes de Reservas / Eventos
INSERT INTO Clientes (Nombre, Telefono, Correo, Estado)
VALUES ('No Asignado', 'N/A', 'noasignado@na.com', 0);
 
-- Horarios  →  necesario antes de Eventos
INSERT INTO Horarios (HoraInicio, HoraFin, Turno, Descripcion, Estado)
VALUES ('00:00', '00:00', 'No Asignado', 'Registro por defecto sin asignación', 0);
 
-- TipoEventos  →  necesario antes de Eventos
INSERT INTO TipoEventos (Nombre, DuracionEstimada, Descripcion, Estado)
VALUES ('No Asignado', 'N/A', 'Registro por defecto sin asignación', 0);
 
-- TipoPagos  →  necesario antes de Facturas
INSERT INTO TipoPagos (Nombre, Descripcion, Comision, Estado)
VALUES ('No Asignado', 'Registro por defecto sin asignación', 0, 0);
 
-- Ofertas  →  necesario antes de Facturas
INSERT INTO Ofertas (FechaLimite, Descuento, Nombre, Estado)
VALUES ('2000-01-01', 0, 'No Asignado', 0);
 
-- ─────────────────────────────────────────────────────────────
-- 3. ADMINISTRADOR  (depende de TipoAdministradores)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Administradores (Nombre, Telefono, Correo, Contraseña, Estado, TipoAdministrador)
VALUES ('No Asignado', 'N/A', 'noasignado@na.com', 'N/A', 0,
        (SELECT TOP 1 Id FROM TipoAdministradores WHERE Nombre = 'No Asignado'));
 
-- ─────────────────────────────────────────────────────────────
-- 4. PATROCINADOR  (depende de TipoPatrocinadores)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Patrocinadores (Nombre, Correo, Telefono, Direccion, Estado, TipoPatrocinador)
VALUES ('No Asignado', 'noasignado@na.com', 'N/A', 'N/A', 0,
        (SELECT TOP 1 Id FROM TipoPatrocinadores WHERE Nombre = 'No Asignado'));
 
-- ─────────────────────────────────────────────────────────────
-- 5. TRANSPORTES  (depende de TipoTransportes)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Transportes (Vehiculo, Placa, Capacidad, Estado, TipoTransporte)
VALUES ('No Asignado', 'N/A', 0, 0,
        (SELECT TOP 1 Id FROM TipoTransportes WHERE Nombre = 'No Asignado'));
 
-- ─────────────────────────────────────────────────────────────
-- 6. GRUPO  (depende de PersonalApoyos y Transportes)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Grupos (Nombre, Cantidad, CantEventos, Estado, PersonalApoyo, Transporte)
VALUES ('No Asignado', 0, 0, 0,
        (SELECT TOP 1 Id FROM PersonalApoyos WHERE Nombre = 'No Asignado'),
        (SELECT TOP 1 Id FROM Transportes    WHERE Vehiculo = 'No Asignado'));
 
-- ─────────────────────────────────────────────────────────────
-- 7. INVENTARIO  (depende de Proveedores y TipoInventarios)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Inventarios (Nombre, EstadoProducto, Cantidad, Proveedor, TipoInventario)
VALUES ('No Asignado', 0, 0,
        (SELECT TOP 1 Id FROM Proveedores    WHERE Nombre = 'No Asignado'),
        (SELECT TOP 1 Id FROM TipoInventarios WHERE Nombre = 'No Asignado'));
 
-- ─────────────────────────────────────────────────────────────
-- 8. LUGARES  (depende de TipoLugares)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Lugares (Nombre, Direccion, Capacidad, Estado, TipoLugar)
VALUES ('No Asignado', 'N/A', 0, 0,
        (SELECT TOP 1 Id FROM TipoLugares WHERE Nombre = 'No Asignado'));
 
-- ─────────────────────────────────────────────────────────────
-- 9. RESERVA  (sin FK directa — tabla independiente)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Reservas (FechaReserva, Ubicacion, Observaciones, Estado)
VALUES ('2000-01-01', 'No Asignado', 'Registro por defecto sin asignación', 0);
 
-- ─────────────────────────────────────────────────────────────
-- 10. TRABAJADOR  (depende de TipoTrabajadores)
--     necesario para GruposTrabajadores
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Trabajadores (Nombre, Telefono, Correo, FechaIngreso, Estado, TipoTrabajador)
VALUES ('No Asignado', 'N/A', 'noasignado@na.com', '2000-01-01', 0,
        (SELECT TOP 1 Id FROM TipoTrabajadores WHERE Nombre = 'No Asignado'));
 
-- ─────────────────────────────────────────────────────────────
-- 11. GRUPOS TRABAJADORES  (depende de Trabajadores y Grupos)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO GruposTrabajadores (Descripcion, Estado, Trabajador, Grupo)
VALUES ('No Asignado', 0,
        (SELECT TOP 1 Id FROM Trabajadores WHERE Nombre = 'No Asignado'),
        (SELECT TOP 1 Id FROM Grupos       WHERE Nombre = 'No Asignado'));
 
-- ─────────────────────────────────────────────────────────────
-- 12. EVENTO  (depende de GruposTrabajadores, Inventarios,
--              Horarios, Administradores, TipoEventos,
--              Patrocinadores, Lugares, Reservas, Clientes)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Eventos (
    Nombre, Fecha, Descripcion, CantPersonas, Estado,
    Grupo, Inventario, Horario, Administrador, TipoEvento,
    Patrocinador, Lugar, Reserva, Cliente
)
VALUES (
    'No Asignado', '2000-01-01', 'Registro por defecto sin asignación', 0, 0,
    (SELECT TOP 1 Id FROM Grupos            WHERE Nombre    = 'No Asignado'),
    (SELECT TOP 1 Id FROM Inventarios       WHERE Nombre    = 'No Asignado'),
    (SELECT TOP 1 Id FROM Horarios          WHERE Turno     = 'No Asignado'),
    (SELECT TOP 1 Id FROM Administradores   WHERE Nombre    = 'No Asignado'),
    (SELECT TOP 1 Id FROM TipoEventos       WHERE Nombre    = 'No Asignado'),
    (SELECT TOP 1 Id FROM Patrocinadores    WHERE Nombre    = 'No Asignado'),
    (SELECT TOP 1 Id FROM Lugares           WHERE Nombre    = 'No Asignado'),
    (SELECT TOP 1 Id FROM Reservas          WHERE Ubicacion = 'No Asignado'),
    (SELECT TOP 1 Id FROM Clientes          WHERE Nombre    = 'No Asignado')
);
 
-- ─────────────────────────────────────────────────────────────
-- 13. FACTURA  (depende de TipoPagos, Ofertas, Eventos)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Facturas (NumFactura, FechaEmision, Total, EstadoPago, TipoPago, Oferta, Evento)
VALUES ('NA-000', '2000-01-01', 0, 0,
        (SELECT TOP 1 Id FROM TipoPagos WHERE Nombre = 'No Asignado'),
        (SELECT TOP 1 Id FROM Ofertas   WHERE Nombre = 'No Asignado'),
        (SELECT TOP 1 Id FROM Eventos   WHERE Nombre = 'No Asignado'));
 
-- ─────────────────────────────────────────────────────────────
-- 14. AUDITORIA  (depende de Administradores)
-- ─────────────────────────────────────────────────────────────
 
INSERT INTO Auditorias (TipoAccion, Descripcion, Fecha, Administrador)
VALUES ('No Asignado', 'Registro por defecto sin asignación', '2000-01-01 00:00:00',
        (SELECT TOP 1 Id FROM Administradores WHERE Nombre = 'No Asignado'));

use DBeventos
go

-- =========================
-- TipoAdministradores
-- =========================
INSERT INTO TipoAdministradores (Nombre, Descripcion, NivelAcceso, Estado)
VALUES ('Administrador', 'Control total sistema', 'Alto', 1);

INSERT INTO TipoAdministradores (Nombre, Descripcion, NivelAcceso, Estado)
VALUES ('Moderador', 'solo puede agregar y modificar', 'medio', 1);

INSERT INTO TipoAdministradores (Nombre, Descripcion, NivelAcceso, Estado)
VALUES ('Trabajador', 'solo puede modificar', 'bajo', 1);

-- =========================
-- Administradores
-- =========================
INSERT INTO Administradores (Nombre, Telefono, Correo, Contraseña, Estado, TipoAdministrador)
VALUES ('Admin Principal', '3005556677', 'admin@eventos.com', '123456', 1, 2);

INSERT INTO Administradores (Nombre, Telefono, Correo, Contraseña, Estado, TipoAdministrador)
VALUES ('Moderador', '3005556677', 'Moderador@eventos.com', '123456', 1, 3);

INSERT INTO Administradores (Nombre, Telefono, Correo, Contraseña, Estado, TipoAdministrador)
VALUES ('Trabajador', '3005556677', 'Moderador@eventos.com', '123456', 1, 4);




USE DBeventosGO;
GO

-- ====================================================================
-- 1. TABLAS SIN DEPENDENCIAS (MAESTRAS)
-- ====================================================================

INSERT INTO PersonalApoyos (Nombre, Cantidad, Horario, Estado)
VALUES ('Logística y Protocolo Premium', 15, '2026-06-15', 1);

INSERT INTO TipoPagos (Nombre, Descripcion, Comision, Estado)
VALUES ('Tarjeta de Crédito', 'Pagos mediante pasarela de pago online', 3, 1);

INSERT INTO Ofertas (FechaLimite, Descuento, Nombre, Estado)
VALUES ('2026-12-31', 15, 'Descuento Fin de Año', 1);

INSERT INTO Proveedores (Nombre, Telefono, Correo, TipoProducto, Estado)
VALUES ('Sonido & Luces Pro', '555-0192', 'contacto@sonidopro.com', 'Equipos Tecnológicos', 1);

INSERT INTO Horarios (HoraInicio, HoraFin, Turno, Descripcion, Estado)
VALUES ('18:00', '02:00', 'Nocturno', 'Horario estándar para eventos nocturnos', 1);

INSERT INTO TipoPatrocinadores (Nombre, Descripcion, NivelAporte, Beneficios, Estado)
VALUES ('Patrocinador Oro', 'Aporte financiero mayoritario', 'Alto', 'Logo gigante en banners y 5 entradas VIP', 1);

INSERT INTO Clientes (Nombre, Documento, Telefono, Correo, Estado)
VALUES ('Carlos Mendoza', '10203040', '555-4321', 'carlos.mendoza@email.com', 1);

INSERT INTO Reservas (FechaReserva, Ubicacion, Observaciones, Estado)
VALUES ('2026-05-20', 'Zona VIP Norte', 'Requiere acceso para discapacitados', 1);

INSERT INTO TipoEventos (Nombre, DuracionEstimada, Descripcion, Estado)
VALUES ('Concierto', '4 Horas', 'Eventos musicales masivos en vivo', 1);

INSERT INTO TipoInventarios (Nombre, Descripcion, Categoria, Estado)
VALUES ('Mobiliario', 'Sillas, mesas y elementos de soporte', 'Logística', 1);

INSERT INTO TipoTransportes (Nombre, Capacidad, Descripcion, Estado)
VALUES ('Van de Pasajeros', 15, 'Vehículo para transporte de staff o artistas', 1);

INSERT INTO TipoLugares (Nombre, Capacidad, Descripcion, Estado)
VALUES ('Centro de Convenciones', 500, 'Espacios cerrados de gran capacidad', 1);


-- ====================================================================
-- 2. TABLAS CON UNA FK (DEPENDIENTES DE LAS ANTERIORES)
-- ====================================================================

INSERT INTO Lugares (Nombre, Direccion, Capacidad, Estado, TipoLugar)
VALUES ('Gran Salón Real', 'Av. Principal #123', 450, 1, 1); -- TipoLugar = 1 (Centro de Convenciones)

INSERT INTO Transportes (Vehiculo, Placa, Capacidad, Estado, TipoTransporte)
VALUES ('Toyota Hiace', 'ABC-123', 12, 1, 1); -- TipoTransporte = 1 (Van)

INSERT INTO Grupos (Nombre, Cantidad, CantEventos, Estado, PersonalApoyo, Transporte)
VALUES ('Staff Técnico A', 10, 5, 1, 1, 1); 

INSERT INTO Inventarios (Nombre, EstadoProducto, Cantidad, Proveedor, TipoInventario)
VALUES ('Sillas Cocteleras', 1, 200, 1, 1);

INSERT INTO Patrocinadores (Nombre, Correo, Telefono, Direccion, Estado, TipoPatrocinador)
VALUES ('Bebidas del Sur', 'marketing@bebidas.com', '555-9876', 'Zona Industrial Lote 4', 1, 1);


-- ====================================================================
-- 3. TABLA CENTRAL: EVENTOS 
-- (Nota: Se asume que ya existe un Administrador con Id = 1)
-- ====================================================================

INSERT INTO Eventos (Nombre, Fecha, Descripcion, CantPersonas, Estado, Grupo, Inventario, Horario, Administrador, TipoEvento, Patrocinador, Lugar, Reserva, Cliente)
VALUES (
    'Gala Anual de Empresarios', 
    '2026-07-20', 
    'Cena y premiación corporativa', 
    300, 
    1, 
    1, -- Grupo
    1, -- Inventario
    1, -- Horario
    1, -- *** ADVERTENCIA: ID del Administrador (Debe existir en tu tabla)
    1, -- TipoEvento
    1, -- Patrocinador
    1, -- Lugar
    1, -- Reserva
    1  -- Cliente
);


-- ====================================================================
-- 4. TABLA FACTURAS (DEPENDE DE EVENTOS)
-- ====================================================================

INSERT INTO Facturas (NumFactura, FechaEmision, Total, EstadoPago, TipoPago, Oferta, Evento)
VALUES ('FAC-2026-0001', '2026-05-25', 1500000, 1, 1, 1, 1);


-- ====================================================================
-- 5. TABLA AUDITORIAS 
-- (Nota: Se asume que ya existe un Administrador con Id = 1)
-- ====================================================================

INSERT INTO Auditorias (TipoAccion, Descripcion, Fecha, Administrador)
VALUES ('CREACIÓN', 'Se registró el evento Gala Anual de Empresarios', GETDATE(), 1); -- *** ID del Administrador
