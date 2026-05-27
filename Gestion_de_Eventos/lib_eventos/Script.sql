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
    GrupoTrabajador INT,
    Inventario INT,
    Horario INT,
    Administrador INT,
    TipoEvento INT,
    Patrocinador INT,
    Lugar INT,
    Reserva INT,
    Cliente INT,
    FOREIGN KEY (GrupoTrabajador) REFERENCES GruposTrabajadores(Id),
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


USE DBeventos
GO

-- Tablas base (sin dependencias)

-- =========================
-- TipoTrabajadores
-- =========================
INSERT INTO TipoTrabajadores (Nombre, Salario, Descripcion, Estado)
VALUES ('Mesero', 1200000, 'Atención de mesas y clientes', 1);

-- =========================
-- PersonalApoyos
-- =========================
INSERT INTO PersonalApoyos (Nombre, Cantidad, Horario, Estado)
VALUES ('Equipo A', 10, '2026-06-01', 1);

-- =========================
-- TipoPagos
-- =========================
INSERT INTO TipoPagos (Nombre, Descripcion, Comision, Estado)
VALUES ('Tarjeta Crédito', 'Pago con tarjeta', 5, 1);

-- =========================
-- Ofertas
-- =========================
INSERT INTO Ofertas (FechaLimite, Descuento, Nombre, Estado)
VALUES ('2026-12-31', 15, 'Oferta Premium', 1);

-- =========================
-- Proveedores
-- =========================
INSERT INTO Proveedores (Nombre, Telefono, Correo, TipoProducto, Estado)
VALUES ('AudioTech', '3002223344', 'ventas@audiotech.com', 'Sonido', 1);

-- =========================
-- Horarios
-- =========================
INSERT INTO Horarios (HoraInicio, HoraFin, Turno, Descripcion, Estado)
VALUES ('08:00', '12:00', 'Mañana', 'Jornada mañana', 1);

-- =========================
-- TipoPatrocinadores
-- =========================
INSERT INTO TipoPatrocinadores (Nombre, Descripcion, NivelAporte, Beneficios, Estado)
VALUES ('Oro', 'Patrocinador premium', 'Alto', 'Publicidad destacada', 1);

-- =========================
-- Clientes
-- =========================
INSERT INTO Clientes (Nombre, Telefono, Correo, Estado)
VALUES ('Carlos Gómez', '3111111111', 'carlos@gmail.com', 1);

-- =========================
-- Reservas
-- =========================
INSERT INTO Reservas (FechaReserva, Ubicacion, Observaciones, Estado)
VALUES ('2026-07-01', 'Salón Norte', 'Reserva empresarial', 1);

-- =========================
-- TipoEventos
-- =========================
INSERT INTO TipoEventos (Nombre, DuracionEstimada, Descripcion, Estado)
VALUES ('Concierto', '5 horas', 'Evento musical', 1);

-- =========================
-- TipoAdministradores
-- =========================
INSERT INTO TipoAdministradores (Nombre, Descripcion, NivelAcceso, Estado)
VALUES ('Super Admin', 'Control total sistema', 'Alto', 1);

-- =========================
-- TipoInventarios
-- =========================
INSERT INTO TipoInventarios (Nombre, Descripcion, Categoria, Estado)
VALUES ('Sonido', 'Equipos de sonido', 'Audio', 1);

-- =========================
-- TipoTransportes
-- =========================
INSERT INTO TipoTransportes (Nombre, Capacidad, Descripcion, Estado)
VALUES ('Bus', 40, 'Bus de pasajeros', 1);

-- =========================
-- TipoLugares
-- =========================
INSERT INTO TipoLugares (Nombre, Capacidad, Descripcion, Estado)
VALUES ('Salón', 200, 'Salón cerrado', 1);

-- =========================
-- Lugares
-- =========================
INSERT INTO Lugares (Nombre, Direccion, Capacidad, Estado, TipoLugar)
VALUES ('Centro Eventos Medellín', 'Calle 10 #20-30', 500, 1, 1);

-- =========================
-- Transportes
-- =========================
INSERT INTO Transportes (Vehiculo, Placa, Capacidad, Estado, TipoTransporte)
VALUES ('Bus Mercedes', 'ABC123', 40, 1, 1);

-- =========================
-- Administradores
-- =========================
INSERT INTO Administradores (Nombre, Telefono, Correo, Contraseña, Estado, TipoAdministrador)
VALUES ('Admin Principal', '3005556677', 'admin@eventos.com', '123456', 1, 1);

-- =========================
-- Auditorias
-- =========================
INSERT INTO Auditorias (TipoAccion, Descripcion, Fecha, Administrador)
VALUES ('INSERT', 'Creación de evento', GETDATE(), 1);

-- =========================
-- Trabajadores
-- =========================
INSERT INTO Trabajadores (Nombre, Telefono, Correo, FechaIngreso, Estado, TipoTrabajador)
VALUES ('Juan Pérez', '3201112233', 'juan@correo.com', '2025-01-10', 1, 1);

-- =========================
-- Grupos
-- =========================
INSERT INTO Grupos (Nombre, Cantidad, CantEventos, Estado, PersonalApoyo, Transporte)
VALUES ('Grupo Logístico A', 15, 3, 1, 1, 1);

-- =========================
-- Inventarios
-- =========================
INSERT INTO Inventarios (Nombre, EstadoProducto, Cantidad, Proveedor, TipoInventario)
VALUES ('Luces LED', 1, 20, 1, 1);

-- =========================
-- Patrocinadores
-- =========================
INSERT INTO Patrocinadores (Nombre, Correo, Telefono, Direccion, Estado, TipoPatrocinador)
VALUES ('Coca Cola', 'contacto@cocacola.com', '3004445566', 'Bogotá', 1, 1);

-- =========================
-- GruposTrabajadores
-- =========================
INSERT INTO GruposTrabajadores (Descripcion, Estado, Trabajador, Grupo)
VALUES ('Equipo principal del evento', 1, 1, 1);

-- =========================
-- Eventos
-- =========================
INSERT INTO Eventos (
    Nombre,
    Fecha,
    Descripcion,
    CantPersonas,
    Estado,
    GrupoTrabajador,
    Inventario,
    Horario,
    Administrador,
    TipoEvento,
    Patrocinador,
    Lugar,
    Reserva,
    Cliente
)
VALUES (
    'Festival Música',
    '2026-07-20',
    'Evento masivo musical',
    300,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1,
    1
);

-- =========================
-- Facturas
-- =========================
INSERT INTO Facturas (
    NumFactura,
    FechaEmision,
    Total,
    EstadoPago,
    TipoPago,
    Oferta,
    Evento
)
VALUES (
    'FAC-001',
    '2026-05-26',
    5000000,
    1,
    1,
    1,
    1
);