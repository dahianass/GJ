using GestionJuridica.Models;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Web;
using System.Web.Mvc;


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

                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;

                    string IdFormulario = this.Request.QueryString["idformulario"];
                    string IdEstado = this.Request.QueryString["idestado"];


                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
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
                        // Get the complete folder path and store the file inside it. 
                        Documentos doc = new Documentos();
                        doc.IdFormulario = Convert.ToInt32(IdFormulario);
                        doc.IdEstadoFormulario = Convert.ToInt32(IdEstado);
                        doc.FechaGuardar = DateTime.Now;
                        doc.Url = urls;

                        result = GuardarBD(doc);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully! ");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
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
    }
}