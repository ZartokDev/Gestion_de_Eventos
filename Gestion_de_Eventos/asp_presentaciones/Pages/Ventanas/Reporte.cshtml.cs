using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// COMPATIBILIDAD ABSOLUTA CON ITEXT 9.6.0
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.IO.Font.Constants;
using iText.Kernel.Font;

namespace asp_presentaciones.Pages
{
    public class ReporteModel : PageModel
    {
        private ITipoTrabajadoresNegocioP iTipoTrabajadores;
        private IPersonalApoyosNegocioP iPersonalApoyos;
        private ITipoPagosNegocioP iTipoPagos;
        private IOfertasNegocioP iOfertas;
        private IProveedoresNegocioP iProveedores;
        private IHorariosNegocioP iHorarios;
        private ITipoPatrocinadoresNegocioP iTipoPatrocinadores;
        private IClientesNegocioP iClientes;
        private IReservasNegocioP iReservas;
        private ITipoEventosNegocioP iTipoEventos;
        private ITipoAdministradoresNegocioP iTipoAdministradores;
        private ITipoInventariosNegocioP iTipoInventarios;
        private ITipoTransportesNegocioP iTipoTransportes;
        private ITipoLugaresNegocioP iTipoLugares;
        private ILugaresNegocioP iLugares;
        private ITransportesNegocioP iTransportes;
        private IAdministradoresNegocioP iAdministradores;
        private IAuditoriasNegocioP iAuditorias;
        private ITrabajadoresNegocioP iTrabajadores;
        private IGruposNegocioP iGrupos;
        private IInventariosNegocioP iInventarios;
        private IPatrocinadoresNegocioP iPatrocinadores;
        private IGruposTrabajadoresNegocioP iGruposTrabajadores;
        private IEventosNegocioP iEventos;
        private IFacturasNegocioP iFacturas;

        // Instanciación estricta de fuentes globales en iText 9
        private readonly PdfFont fuenteNegrita = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        private readonly PdfFont fuenteCursiva = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

        public ReporteModel()
        {
            iTipoTrabajadores = new TipoTrabajadoresNegocioP();
            iPersonalApoyos = new PersonalApoyosNegocioP();
            iTipoPagos = new TipoPagosNegocioP();
            iOfertas = new OfertasNegocioP();
            iProveedores = new ProveedoresNegocioP();
            iHorarios = new HorariosNegocioP();
            iTipoPatrocinadores = new TipoPatrocinadoresNegocioP();
            iClientes = new ClientesNegocioP();
            iReservas = new ReservasNegocioP();
            iTipoEventos = new TipoEventosNegocioP();
            iTipoAdministradores = new TipoAdministradoresNegocioP();
            iTipoInventarios = new TipoInventariosNegocioP();
            iTipoTransportes = new TipoTransportesNegocioP();
            iTipoLugares = new TipoLugaresNegocioP();
            iLugares = new LugaresNegocioP();
            iTransportes = new TransportesNegocioP();
            iAdministradores = new AdministradoresNegocioP();
            iAuditorias = new AuditoriasNegocioP();
            iTrabajadores = new TrabajadoresNegocioP();
            iGrupos = new GruposNegocioP();
            iInventarios = new InventariosNegocioP();
            iPatrocinadores = new PatrocinadoresNegocioP();
            iGruposTrabajadores = new GruposTrabajadoresNegocioP();
            iEventos = new EventosNegocioP();
            iFacturas = new FacturasNegocioP();
        }

        public void OnGet() { }

        public IActionResult OnPostDescargar()
        {
            // Extraemos el nombre del usuario logueado únicamente para dejar constancia de quién compiló el documento
            var nombreUsuario = User.Identity?.Name ?? "Usuario Sistema";

            using var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var doc = new Document(pdf);

            var rojoElementel = new DeviceRgb(192, 57, 43);
            var grisOscuro = new DeviceRgb(30, 30, 45);
            var blanco = ColorConstants.WHITE;

            // Título Principal Unificado
            var tituloPrincipal = new Paragraph("⚡ KINETIC EVENTOS")
                .SetFontSize(24)
                .SetFont(fuenteNegrita)
                .SetFontColor(rojoElementel)
                .SetTextAlignment(TextAlignment.CENTER);
            doc.Add(tituloPrincipal);

            var subAdmin = new Paragraph("REPORTE MAESTRO - BALANCE TOTAL CORPORATIVO")
                .SetFontSize(12)
                .SetFont(fuenteNegrita)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginBottom(2);
            doc.Add(subAdmin);

            doc.Add(new Paragraph($"Compilado por: {nombreUsuario} | Fecha de Impresión: {DateTime.Now:dd/MM/yyyy HH:mm}")
                .SetFontSize(9).SetTextAlignment(TextAlignment.CENTER).SetMarginBottom(20));

            // =========================================================================
            // --- BLOQUE 1: INFRAESTRUCTURA, SEDES Y LOGÍSTICA ---
            // =========================================================================
            AgregarTituloSeccion(doc, "1. INFRAESTRUCTURA, LOGÍSTICA Y SEDES", rojoElementel);

            // Tabla: Lugares
            var lugares = iLugares.Consultar() ?? new List<Lugares>();
            var tipoLugares = iTipoLugares.Consultar() ?? new List<TipoLugares>();

            var lblLugares = new Paragraph("🏢 Sedes y Locaciones (Lugares)").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(5);
            doc.Add(lblLugares);

            var tLugares = new Table(new float[] { 1, 3, 3, 2, 2, 1 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tLugares, new string[] { "ID", "Nombre", "Dirección", "Capacidad", "Categoría Tipo", "Est." }, grisOscuro, blanco);
            foreach (var item in lugares)
            {
                var tipo = tipoLugares.FirstOrDefault(x => x.Id == item.TipoLugar);
                tLugares.AddCell(item.Id.ToString());
                tLugares.AddCell(item.Nombre ?? "");
                tLugares.AddCell(item.Direccion ?? "");
                tLugares.AddCell(item.Capacidad.ToString());
                tLugares.AddCell(tipo?.Nombre ?? "N/A");
                tLugares.AddCell(item.Estado ? "A" : "I");
            }
            doc.Add(tLugares);

            // Tabla: Transportes
            var transportes = iTransportes.Consultar() ?? new List<Transportes>();
            var lblTransportes = new Paragraph("🚚 Flota de Vehículos (Transportes)").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(10);
            doc.Add(lblTransportes);

            var tTransportes = new Table(new float[] { 1, 3, 2, 2, 2 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tTransportes, new string[] { "ID", "Vehículo", "Placa", "Capacidad", "Est." }, grisOscuro, blanco);
            foreach (var item in transportes)
            {
                tTransportes.AddCell(item.Id.ToString());
                tTransportes.AddCell(item.Vehiculo ?? "");
                tTransportes.AddCell(item.Placa ?? "");
                tTransportes.AddCell(item.Capacidad.ToString());
                tTransportes.AddCell(item.Estado ? "A" : "I");
            }
            doc.Add(tTransportes);

            // =========================================================================
            // --- BLOQUE 2: TALENTO HUMANO Y LOGÍSTICA ---
            // =========================================================================
            AgregarTituloSeccion(doc, "2. PERSONAL, STAFF Y GRUPOS OPERATIVOS", rojoElementel);

            // Tabla: Trabajadores
            var trabajadores = iTrabajadores.Consultar() ?? new List<Trabajadores>();
            var lblTrabajadores = new Paragraph("👷 Personal de Planta (Trabajadores)").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(5);
            doc.Add(lblTrabajadores);

            var tTrabajadores = new Table(new float[] { 1, 3, 2, 3, 2, 1 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tTrabajadores, new string[] { "ID", "Nombre", "Teléfono", "Correo", "Ingreso", "Est." }, grisOscuro, blanco);
            foreach (var item in trabajadores)
            {
                tTrabajadores.AddCell(item.Id.ToString());
                tTrabajadores.AddCell(item.Nombre ?? "");
                tTrabajadores.AddCell(item.Telefono ?? "");
                tTrabajadores.AddCell(item.Correo ?? "");
                tTrabajadores.AddCell(item.FechaIngreso.ToString("dd/MM/yyyy"));
                tTrabajadores.AddCell(item.Estado ? "A" : "I");
            }
            doc.Add(tTrabajadores);

            // Tabla: Grupos
            var grupos = iGrupos.Consultar() ?? new List<Grupos>();
            var lblGrupos = new Paragraph("👥 Grupos Logísticos Asignados").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(10);
            doc.Add(lblGrupos);

            var tGrupos = new Table(new float[] { 1, 3, 2, 2, 2 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tGrupos, new string[] { "ID", "Nombre Grupo", "Cant. Personas", "Cant. Eventos", "Est." }, grisOscuro, blanco);
            foreach (var item in grupos)
            {
                tGrupos.AddCell(item.Id.ToString());
                tGrupos.AddCell(item.Nombre ?? "");
                tGrupos.AddCell(item.Cantidad.ToString());
                tGrupos.AddCell(item.CantEventos.ToString());
                tGrupos.AddCell(item.Estado ? "A" : "I");
            }
            doc.Add(tGrupos);

            // Tabla: PersonalApoyos
            var apoyos = iPersonalApoyos.Consultar() ?? new List<PersonalApoyos>();
            var lblApoyos = new Paragraph("🤝 Personal Extra de Apoyo").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(10);
            doc.Add(lblApoyos);

            var tApoyos = new Table(new float[] { 1, 3, 2, 3, 1 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tApoyos, new string[] { "ID", "Nombre / Entidad", "Cantidad", "Horario Agenda", "Est." }, grisOscuro, blanco);
            foreach (var item in apoyos)
            {
                tApoyos.AddCell(item.Id.ToString());
                tApoyos.AddCell(item.Nombre ?? "");
                tApoyos.AddCell(item.Cantidad.ToString());
                tApoyos.AddCell(item.Horario.ToString("dd/MM/yyyy"));
                tApoyos.AddCell(item.Estado ? "A" : "I");
            }
            doc.Add(tApoyos);

            // =========================================================================
            // --- BLOQUE 3: CONTROL DE SUMINISTROS Y MERCADEO ---
            // =========================================================================
            AgregarTituloSeccion(doc, "3. INVENTARIOS, PROVEEDORES Y PATROCINIO", rojoElementel);

            // Tabla: Inventarios
            var inventarios = iInventarios.Consultar() ?? new List<Inventarios>();
            var lblInventarios = new Paragraph("📦 Stock de Artículos (Inventarios)").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(5);
            doc.Add(lblInventarios);

            var tInventario = new Table(new float[] { 1, 4, 2, 2 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tInventario, new string[] { "ID", "Artículo", "Cantidad", "Estado Físico" }, grisOscuro, blanco);
            foreach (var item in inventarios)
            {
                tInventario.AddCell(item.Id.ToString());
                tInventario.AddCell(item.Nombre ?? "");
                tInventario.AddCell(item.Cantidad.ToString());
                tInventario.AddCell(item.EstadoProducto ? "Óptimo" : "Defectuoso");
            }
            doc.Add(tInventario);

            // Tabla: Proveedores
            var proveedores = iProveedores.Consultar() ?? new List<Proveedores>();
            var lblProveedores = new Paragraph("🏢 Directorio de Proveedores").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(10);
            doc.Add(lblProveedores);

            var tProv = new Table(new float[] { 1, 3, 2, 3, 2 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tProv, new string[] { "ID", "Proveedor", "Teléfono", "Correo", "Línea Producto" }, grisOscuro, blanco);
            foreach (var item in proveedores)
            {
                tProv.AddCell(item.Id.ToString());
                tProv.AddCell(item.Nombre ?? "");
                tProv.AddCell(item.Telefono ?? "");
                tProv.AddCell(item.Correo ?? "");
                tProv.AddCell(item.TipoProducto ?? "");
            }
            doc.Add(tProv);

            // Tabla: Patrocinadores
            var patrocinadores = iPatrocinadores.Consultar() ?? new List<Patrocinadores>();
            var lblPatrocinadores = new Paragraph("🏅 Patrocinadores Oficiales").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(10);
            doc.Add(lblPatrocinadores);

            var tPatrocinio = new Table(new float[] { 1, 3, 3, 2, 1 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tPatrocinio, new string[] { "ID", "Empresa", "Correo", "Teléfono", "Est." }, grisOscuro, blanco);
            foreach (var item in patrocinadores)
            {
                tPatrocinio.AddCell(item.Id.ToString());
                tPatrocinio.AddCell(item.Nombre ?? "");
                tPatrocinio.AddCell(item.Correo ?? "");
                tPatrocinio.AddCell(item.Telefono ?? "");
                tPatrocinio.AddCell(item.Estado ? "A" : "I");
            }
            doc.Add(tPatrocinio);

            // =========================================================================
            // --- BLOQUE 4: GESTIÓN COMERCIAL, OPERATIVA Y AUDITORÍA ---
            // =========================================================================
            AgregarTituloSeccion(doc, "4. HISTORIAL DE EVENTOS, FACTURACIÓN Y CONTROL", rojoElementel);

            // Tabla: Clientes
            var clientes = iClientes.Consultar() ?? new List<Clientes>();
            var lblClientes = new Paragraph("👥 Base de Clientes").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(5);
            doc.Add(lblClientes);

            var tClientes = new Table(new float[] { 1, 3, 2, 2, 3 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tClientes, new string[] { "ID", "Nombre", "Documento", "Teléfono", "Correo" }, grisOscuro, blanco);
            foreach (var item in clientes)
            {
                tClientes.AddCell(item.Id.ToString());
                tClientes.AddCell(item.Nombre ?? "");
                tClientes.AddCell(item.Documento ?? "");
                tClientes.AddCell(item.Telefono ?? "");
                tClientes.AddCell(item.Correo ?? "");
            }
            doc.Add(tClientes);

            // Tabla: Eventos
            var eventos = iEventos.Consultar() ?? new List<Eventos>();
            var lblEventos = new Paragraph("🗓️ Eventos Consolidados").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(10);
            doc.Add(lblEventos);

            var tEventos = new Table(new float[] { 1, 3, 2, 2, 1 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tEventos, new string[] { "ID", "Nombre del Evento", "Fecha", "Aforo Real", "Est." }, grisOscuro, blanco);
            foreach (var item in eventos)
            {
                tEventos.AddCell(item.Id.ToString());
                tEventos.AddCell(item.Nombre ?? "");
                tEventos.AddCell(item.Fecha.ToString("dd/MM/yyyy"));
                tEventos.AddCell(item.CantPersonas.ToString());
                tEventos.AddCell(item.Estado ? "A" : "I");
            }
            doc.Add(tEventos);

            // Tabla: Facturas
            var facturas = iFacturas.Consultar() ?? new List<Facturas>();
            var lblFacturas = new Paragraph("💳 Transacciones y Facturación").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(10);
            doc.Add(lblFacturas);

            var tFacturas = new Table(new float[] { 1, 3, 2, 3, 2 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tFacturas, new string[] { "ID", "Código Factura", "Emisión", "Monto Total", "Estado Pago" }, grisOscuro, blanco);
            foreach (var item in facturas)
            {
                tFacturas.AddCell(item.Id.ToString());
                tFacturas.AddCell(item.NumFactura ?? "");
                tFacturas.AddCell(item.FechaEmision.ToString("dd/MM/yyyy"));
                tFacturas.AddCell($"${item.Total:N0} COP");
                tFacturas.AddCell(item.EstadoPago ? "Liquidada" : "Pendiente");
            }
            doc.Add(tFacturas);

            // Tabla: Auditorías
            var auditorias = iAuditorias.Consultar() ?? new List<Auditorias>();
            var lblAuditorias = new Paragraph("🔒 Registro de Seguridad (Auditorías)").SetFontSize(10).SetFont(fuenteNegrita).SetMarginTop(10);
            doc.Add(lblAuditorias);

            var tAudit = new Table(new float[] { 1, 2, 4, 3 }).UseAllAvailableWidth();
            CrearCeldasCabecera(tAudit, new string[] { "ID", "Acción", "Descripción Log", "Fecha Transacción" }, grisOscuro, blanco);
            foreach (var item in auditorias.Take(20)) // Tomamos los últimos 20 logs de auditoría general
            {
                tAudit.AddCell(item.Id.ToString());
                tAudit.AddCell(item.TipoAccion ?? "");
                tAudit.AddCell(item.Descripcion ?? "");
                tAudit.AddCell(item.Fecha.ToString("dd/MM/yyyy HH:mm:ss"));
            }
            doc.Add(tAudit);

            doc.Close();

            // Nombre único para el reporte unificado corporativo
            string nombreArchivo = "Reporte_Total_Corporativo_Kinetic.pdf";

            return File(stream.ToArray(), "application/pdf", nombreArchivo);
        }

        private void AgregarTituloSeccion(Document doc, string texto, DeviceRgb color)
        {
            var p = new Paragraph(texto)
                .SetFontSize(12)
                .SetFontColor(color)
                .SetFont(fuenteNegrita)
                .SetMarginTop(18)
                .SetMarginBottom(4)
                .SetKeepWithNext(true);
            doc.Add(p);
        }

        private void CrearCeldasCabecera(Table tabla, string[] titulos, DeviceRgb fondo, Color textoColor)
        {
            foreach (var tit in titulos)
            {
                var p = new Paragraph(tit).SetFontSize(9).SetFont(fuenteNegrita);

                var celda = new Cell()
                    .Add(p)
                    .SetBackgroundColor(fondo)
                    .SetFontColor(textoColor)
                    .SetTextAlignment(TextAlignment.CENTER);

                tabla.AddHeaderCell(celda);
            }
        }
    }
}