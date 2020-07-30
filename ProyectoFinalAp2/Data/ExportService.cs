using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.IO;
using ProyectoFinalAp2.Models;

namespace ProyectoFinalAp2.Data
{
    public class ExportService
    {
        public static MemoryStream CreatePdfProductos(List<Productos> forecasts, string Fecha, decimal Total)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Courier, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Reporte de Productos", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.Courier, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión " + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;
                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                PdfTextElement text = new PdfTextElement("Total: " + Total, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(400, result.Bounds.Bottom * 5 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;
                }
            }
        }

        public static MemoryStream CreatePdfReorden(List<Productos> forecasts, string Fecha, int Total)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.Courier, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Reporte de Productos en Reorden", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.Courier, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión " + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;
                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                PdfTextElement text = new PdfTextElement("Total: " + Total, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(400, result.Bounds.Bottom * 5 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;
                }
            }
        }

        public static MemoryStream CreatePdfUsuarios(List<Usuarios> forecasts, string Fecha, int Cantidad)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Reporte de Usuarios", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión " + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;

                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                PdfTextElement text = new PdfTextElement("Cantidad: " + Cantidad, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(395, result.Bounds.Bottom * 5 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;

                }
            }
        }

        public static MemoryStream CreatePdfEntradaProductos(List<EntradaProductos> forecasts, string Fecha, int Cantidad)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Reporte de Entrada de Productos", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión " + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;

                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                PdfTextElement text = new PdfTextElement("Cantidad: " + Cantidad, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(395, result.Bounds.Bottom * 5 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;

                }
            }
        }

        public static MemoryStream CreatePdfMarcas(List<Marcas> forecasts, string Fecha, string cantidadMarcas)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Reporte de Marcas", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión:" + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;

                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                //Agregando cantidad de categorias
                PdfTextElement text = new PdfTextElement("Cantidad:" + cantidadMarcas, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(395, result.Bounds.Bottom * 5 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;

                }
            }
        }

        public static MemoryStream CreatePdfCategorias(List<Categorias> forecasts, string Fecha, string cantidadCategorias)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Reporte de Categorias", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión:" + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;

                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                //Agregando cantidad de categorias
                PdfTextElement text = new PdfTextElement("Cantidad:"+cantidadCategorias, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(395, result.Bounds.Bottom * 5 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;

                }
            }
        }
        public static MemoryStream CreatePdfClientes(List<Clientes> forecasts, string Fecha, string cantidadClientes)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Reporte de Clientes", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión " + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;

                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                //Agregando cantidad de clientes
                PdfTextElement text = new PdfTextElement("Cantidad:" +cantidadClientes, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(395, result.Bounds.Bottom * 5 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;

                }
            }
        }

        public static MemoryStream CreatePdfProveedores(List<Proveedor> forecasts, string Fecha, string cantidadProveedores)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Reporte de Proveedores", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión " + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;

                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                //Agregando cantidad de proveedores
                PdfTextElement text = new PdfTextElement("Cantidad:" + cantidadProveedores, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(395, result.Bounds.Bottom * 5 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;

                }
            }
        }

        public static MemoryStream CreatePdfFacturas(List<AuxFactura> forecasts, string Fecha, string total, string cantidad)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Reporte de Facturas", font, PdfBrushes.Black);
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));

                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión " + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;

                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                //Agregando cantidad y total a reporte
                PdfTextElement text = new PdfTextElement("Total:" + total, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(395, result.Bounds.Bottom * 5 + paragraphAfterSpacing));
                PdfTextElement text2 = new PdfTextElement("Cantidad:" +cantidad, font, PdfBrushes.Black);
                PdfLayoutResult result3 = text2.Draw(page, new PointF(395, result.Bounds.Bottom * 6 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;

                }
            }
        }

        public static MemoryStream CreatePdfFacturaFinal(List<AuxFacturaFinal> forecasts, string Fecha, string cliente, string total, string ID)
        {
            if (forecasts == null)
            {
                throw new ArgumentNullException("cannot be null");
            }
            //Create a new PDF document
            using (PdfDocument pdfDocument = new PdfDocument())
            {
                int paragraphAfterSpacing = 8;
                int cellMargin = 8;

                //Add page to the PDF document
                PdfPage page = pdfDocument.Pages.Add();

                //Create a new font
                PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);
                PdfStandardFont clienteFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);

                //Create a text element to draw a text in PDF page
                PdfTextElement title = new PdfTextElement("Factura a Consumidor", font, PdfBrushes.Black);
                //Creando el nombre del cliente
                PdfTextElement clienteTitle = new PdfTextElement("Cliente:"+cliente, clienteFont, PdfBrushes.Black);
                //creando el id de la factura
                PdfTextElement IDTitle = new PdfTextElement("Factura ID:" + ID, clienteFont, PdfBrushes.Black);
                //dibujando
                PdfLayoutResult result = title.Draw(page, new PointF(0, 0));
                //dibujando el cliente y el ID
                PdfLayoutResult resultCliente = clienteTitle.Draw(page, new PointF(395, 25));
                PdfLayoutResult resultID = IDTitle.Draw(page, new PointF(250, 25));



                PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
                PdfTextElement content = new PdfTextElement("Fecha de impresión " + Fecha, contentFont, PdfBrushes.Black);
                PdfLayoutFormat format = new PdfLayoutFormat();
                format.Layout = PdfLayoutType.Paginate;

                //Draw a text to the PDF document
                result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

                //Create a PdfGrid
                PdfGrid pdfGrid = new PdfGrid();
                pdfGrid.Style.CellPadding.Left = cellMargin;
                pdfGrid.Style.CellPadding.Right = cellMargin;

                //Applying built-in style to the PDF grid
                pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.ListTable7Colorful);

                //Assign data source
                pdfGrid.DataSource = forecasts;

                pdfGrid.Style.Font = contentFont;

                //Draw PDF grid into the PDF page
                pdfGrid.Draw(page, new PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

                //Agregando cantidad y total a reporte
                PdfTextElement text = new PdfTextElement("Total:$" + total, font, PdfBrushes.Black);
                PdfLayoutResult result1 = text.Draw(page, new PointF(395, result.Bounds.Bottom * 5 + paragraphAfterSpacing));

                using (MemoryStream stream = new MemoryStream())
                {
                    //Saving the PDF document into the stream
                    pdfDocument.Save(stream);
                    //Closing the PDF document
                    pdfDocument.Close(true);
                    return stream;

                }
            }
        }
    }
}
