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

CREATE TABLE Transportes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Vehiculo NVARCHAR(255),
    Placa NVARCHAR(50),
    Capacidad INT,
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
    TipoProducto NVARCHAR(255)
);

CREATE TABLE Horarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    HoraInicio NVARCHAR(50),
    HoraFin NVARCHAR(50),
    Turno NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Estado BIT NOT NULL
);

CREATE TABLE Lugares (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Direccion NVARCHAR(500),
    Capacidad INT,
    Estado BIT NOT NULL
);

CREATE TABLE TipoPatrocinadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Descripcion NVARCHAR(500),
    NivelAporte NVARCHAR(255),
    Beneficios NVARCHAR(500)
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

CREATE TABLE Administradores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Telefono NVARCHAR(50),
    Correo NVARCHAR(255),
    Contraseña NVARCHAR(255)
);

-- Tablas con una FK
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
    Tipo NVARCHAR(255),
    Cantidad INT,
    Proveedor INT,
    FOREIGN KEY (Proveedor) REFERENCES Proveedores(Id)
);

CREATE TABLE Patrocinadores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(255),
    Correo NVARCHAR(255),
    Telefono NVARCHAR(50),
    Direccion NVARCHAR(500),
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

INSERT INTO TipoTrabajadores (Nombre, Salario, Descripcion, Estado)
VALUES ('Coordinador de Eventos', 3500000, 'Encargado de coordinar todas las actividades del evento', 1);

INSERT INTO Transportes (Vehiculo, Placa, Capacidad, Estado)
VALUES ('Bus Intermunicipal', 'ABC-123', 45, 1);

INSERT INTO PersonalApoyos (Nombre, Cantidad, Horario, Estado)
VALUES ('Equipo de Seguridad', 10, '2024-01-01', 1);

INSERT INTO TipoPagos (Nombre, Descripcion, Comision, Estado)
VALUES ('Transferencia Bancaria', 'Pago directo a cuenta bancaria de la empresa', 2, 1);

INSERT INTO Ofertas (FechaLimite, Descuento, Nombre, Estado)
VALUES ('2024-12-31', 15, 'Descuento Temporada Alta', 1);

INSERT INTO Proveedores (Nombre, Telefono, Correo, TipoProducto)
VALUES ('Decoraciones El Éxito', '3001234567', 'contacto@decoraciones.com', 'Decoración y Mobiliario');

INSERT INTO Horarios (HoraInicio, HoraFin, Turno, Descripcion, Estado)
VALUES ('08:00', '17:00', 'Diurno', 'Turno completo para eventos de día', 1);

INSERT INTO Lugares (Nombre, Direccion, Capacidad, Estado)
VALUES ('Centro de Convenciones Medellín', 'Calle 100 #50-20, El Poblado', 500, 1);

INSERT INTO TipoPatrocinadores (Nombre, Descripcion, NivelAporte, Beneficios)
VALUES ('Patrocinador Principal', 'Empresa con mayor aporte económico al evento', 'Platinum', 'Logo en banner principal, mención en todos los medios, stand VIP');

INSERT INTO Clientes (Nombre, Telefono, Correo, Estado)
VALUES ('Empresa Tecnológica S.A.S', '6044567890', 'eventos@empresatec.com', 1);

INSERT INTO Reservas (FechaReserva, Ubicacion, Observaciones, Estado)
VALUES ('2024-06-15', 'Salón Principal - Piso 2', 'Requiere montaje previo de 3 horas antes del evento', 1);

INSERT INTO TipoEventos (Nombre, DuracionEstimada, Descripcion, Estado)
VALUES ('Conferencia Corporativa', '8 horas', 'Evento formal para presentaciones empresariales y networking', 1);

INSERT INTO Administradores (Nombre, Telefono, Correo, Contraseña)
VALUES ('Carlos Martínez', '3157894561', 'carlos.martinez@eventosco.com', '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy');

-- Tablas con dependencias

INSERT INTO Trabajadores (Nombre, Telefono, Correo, FechaIngreso, Estado, TipoTrabajador)
VALUES ('Ana Gómez', '3209876543', 'ana.gomez@eventosco.com', '2023-03-15', 1, 1);

INSERT INTO Grupos (Nombre, Cantidad, CantEventos, Estado, PersonalApoyo, Transporte)
VALUES ('Grupo Logística Norte', 12, 5, 1, 1, 1);

INSERT INTO Inventarios (Nombre, EstadoProducto, Tipo, Cantidad, Proveedor)
VALUES ('Sillas Plásticas Blancas', 1, 'Mobiliario', 200, 1);

INSERT INTO Patrocinadores (Nombre, Correo, Telefono, Direccion, TipoPatrocinador)
VALUES ('Bancolombia', 'patrocinios@bancolombia.com', '6044444444', 'Carrera 48 #26-85, Medellín', 1);

INSERT INTO GruposTrabajadores (Descripcion, Estado, Trabajador, Grupo)
VALUES ('Ana es la líder del grupo de logística para eventos corporativos', 1, 1, 1);

-- Tabla central

INSERT INTO Eventos (Nombre, Fecha, Descripcion, CantPersonas, Estado,
    GrupoTrabajador, Inventario, Horario, Administrador,
    TipoEvento, Patrocinador, Lugar, Reserva, Cliente)
VALUES (
    'Cumbre de Innovación Tecnológica 2024',
    '2024-09-20',
    'Conferencia empresarial con speakers internacionales y zona de networking',
    300, 1,
    1, 1, 1, 1,
    1, 1, 1, 1, 1
);

-- Factura del evento

INSERT INTO Facturas (NumFactura, FechaEmision, Total, EstadoPago, TipoPago, Oferta, Evento)
VALUES ('FAC-2024-0001', '2024-09-01', 12500000, 1, 1, 1, 1);