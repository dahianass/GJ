using GestionJuridica.Models;
using GestionJuridica.Utilities;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;

namespace GestionDocument.Controllers
{

    public class FilesController : Controller
    {
        private ModelJuridica db = new ModelJuridica();
        // GET: Files
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recibe()
        {
            var urls = "";
            var result = "";
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;

                    string IdFormulario = this.Request.QueryString["idformulario"];
                    string IdEstado = this.Request.QueryString["idestado"];


                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
 
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;

                        }
                        urls = GuardarArchivo(IdFormulario, IdEstado, file); 
                        Documentos doc = new Documentos();
                        doc.IdFormulario = Convert.ToInt32(IdFormulario);
                        doc.IdEstadoFormulario = Convert.ToInt32(IdEstado);
                        doc.FechaGuardar = DateTime.Now;
                        doc.Url = urls;

                        result = GuardarBD(doc);
                    }

                    if (IdEstado == "-1")
                    {
                        int? idF = Convert.ToInt32(IdFormulario);
                        var listDocts = (from docs in db.Documentos
                                         where docs.IdFormulario == idF & docs.IdEstadoFormulario > 0
                                         select docs).ToList();
                        urls = CombineMultiplePDFs(listDocts, AppDomain.CurrentDomain.BaseDirectory + "Log\\Temp\\Resultado" + IdFormulario + "_"+ DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf", IdFormulario, "-2");
                        Documentos doc = new Documentos();
                        doc.IdFormulario = Convert.ToInt32(IdFormulario);
                        doc.IdEstadoFormulario = Convert.ToInt32(-2);
                        doc.FechaGuardar = DateTime.Now;
                        doc.Url = urls;

                        result = GuardarBD(doc);
                    }

                    return Json("File Uploaded Successfully! ");
                }
                catch (Exception ex)
                {
                    return Json(ex.Message);
                    throw;
                }
            }
            else
            {                
                return Json("No files selected.");
            }
        }

        private string GuardarBD(Documentos document)
        {
            try
            {
                // MÉTODO 1: Método Add – Versiones 4.1 y superiores
                db.Documentos.Add(document);

                // MÉTODO 2: AddObject (genérico)
                db.Set<Documentos>().Add(document);
                db.SaveChanges();

                return "Guardar ";
            }
            catch (Exception ex)
            {

                return "Error:" + ex.Message;
            }

        }

        public static string GuardarArchivo(string NombreCarpeta, string NombreArchivo, HttpPostedFileBase Archivo)
        {

            NombreArchivo = "E-" + NombreArchivo + "-" + String.Format("{0:s}", DateTime.Now);
            NombreCarpeta = "c-" + NombreCarpeta;
            string NombreArchivoReal = Archivo.FileName;
            string[] ArrayExtension = NombreArchivoReal.Split('.');
            string Extension = ArrayExtension[ArrayExtension.Length - 1];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(NombreCarpeta);
            container.CreateIfNotExists();
            container.SetPermissions(
            new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(NombreArchivo + "." + Extension);
            blockBlob.DeleteIfExists();
            blockBlob.UploadFromStream(Archivo.InputStream);
            return blockBlob.SnapshotQualifiedUri.AbsoluteUri;

        }

        public static string getNombreArchivoWeb(string RutaArchivo)
        {
            string[] vecRutaArchivo = RutaArchivo.Split('/');
            string NombreArchivoSinExtencion = "";
            if (vecRutaArchivo.Length > 0)
            {
                string NombreArvivo = vecRutaArchivo[vecRutaArchivo.Length - 1];
                string[] vecNombreArchivoSinExtencion = NombreArvivo.Split('.');
                if (vecNombreArchivoSinExtencion.Length > 0)
                {
                    NombreArchivoSinExtencion = vecNombreArchivoSinExtencion[vecNombreArchivoSinExtencion.Length - 1];
                }

            }
            return NombreArchivoSinExtencion;
        }

        public static string CombineMultiplePDFs(List<Documentos> fileNames, string outFile, string NombreCarpeta, string NombreArchivo)
        {
            try
            {
                Document document = new Document();
                PdfCopy writer = new PdfCopy(document, new FileStream(outFile, FileMode.Create));
                if (writer == null)
                {
                    return string.Empty;
                }
                document.Open();
                foreach (Documentos documentt in fileNames)
                {
                    var ext = Path.GetExtension(documentt.Url);

                    switch (ext.ToLower())
                    {
                        case ".pdf":
                            PdfReader reader = new PdfReader(documentt.Url);
                            reader.ConsolidateNamedDestinations();

                            // step 4: we add content
                            for (int i = 1; i <= reader.NumberOfPages; i++)
                            {
                                PdfImportedPage page = writer.GetImportedPage(reader, i);
                                writer.AddPage(page);
                            }

                            PRAcroForm form = reader.AcroForm;
                            if (form != null)
                            {
                                writer.CopyDocumentFields(reader);
                            }

                            reader.Close();
                            break;
                        case ".png":
                        case ".jpeg":
                        case ".jpg":
                        case ".gif":
                            Document doc = new Document();
                            string pdfFilePath = AppDomain.CurrentDomain.BaseDirectory + "Log\\Temp\\temp" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                            PdfWriter writers = PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));

                            doc.Open();
                            string imageURL = documentt.Url;
                            iTextSharp.text.Image jpg;
                            try
                            {
                                jpg = iTextSharp.text.Image.GetInstance(imageURL);
                            }
                            catch (Exception)
                            {
                                continue;
                            }                     
                           
                            jpg.ScalePercent(24f);
                            jpg.Alignment = Element.ALIGN_CENTER;

                            doc.Add(jpg);
                            doc.Close();

                            PdfReader readeri = new PdfReader(pdfFilePath);
                            readeri.ConsolidateNamedDestinations();

                            // step 4: we add content
                            for (int i = 1; i <= readeri.NumberOfPages; i++)
                            {
                                PdfImportedPage page = writer.GetImportedPage(readeri, i);
                                writer.AddPage(page);
                            }

                            PRAcroForm formi = readeri.AcroForm;
                            if (formi != null)
                            {
                                writer.CopyDocumentFields(readeri);
                            }

                            readeri.Close();
                            break;
                        default:
                            break;
                    }
                }
                writer.Close();
                document.Close();

                var Archivo = System.IO.File.OpenRead(outFile);


                NombreArchivo = "E-" + NombreArchivo + "-" + String.Format("{0:s}", DateTime.Now);
                NombreCarpeta = "c-" + NombreCarpeta;
                string NombreArchivoReal = Archivo.Name;
                string[] ArrayExtension = NombreArchivoReal.Split('.');
                string Extension = ArrayExtension[ArrayExtension.Length - 1];
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(NombreCarpeta);
                container.CreateIfNotExists();
                container.SetPermissions(
                new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(NombreArchivo + "." + Extension);
                blockBlob.DeleteIfExists();
                blockBlob.UploadFromStream(Archivo);                
                Archivo.Close();
                DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Log\\Temp");
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                return blockBlob.SnapshotQualifiedUri.AbsoluteUri;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}